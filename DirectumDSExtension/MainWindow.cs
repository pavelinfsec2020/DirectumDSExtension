using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectumDSExtension.Models;

namespace DirectumDSExtension
{
     /// <summary>
     /// Главная и единственная вьюшка
     /// </summary>
    public partial class MainWindow : Form
    {
        private ThemeChanger _themeChanger;
        private List<HighlightingColorBase> _selectedObjProperties;
        private Color _selectedForeColorElement;
        private Color _selectedBackColorElement;
        private ColorCode _selectedColorCode;
        private HighlightingColorBase _beforeChangeProperties;
        private List<string> _themesCollection;
        public static Form _mainForm;
        public static  RichTextBox _propertieChangesBox;
        public MainWindow()
        {
            InitializeComponent();
            InitializeModels();
            _selectedObjProperties = new List<HighlightingColorBase>();
            _selectedForeColorElement = Color.White;
            _selectedBackColorElement = Color.Black;
            _mainForm = this;
            _propertieChangesBox = this.propertieChangesBox;
        }
        private void InitializeModels()
        { 
           _themeChanger = new ThemeChanger();
            GetUserThemesCollection();
        }
        private async void GetUserThemesCollection()
        {
            themesCollectionBox.Items.Clear();
            _themesCollection = await Task<List<string>>.Run(() => { return _themeChanger.InitializeUserThemes(); });
            themesCollectionBox.Items.AddRange(_themesCollection.ToArray());
        }
        private void SetDirectumRxTheme(ThemeStyle themeStyle)
        {
            _themeChanger.SetTheme(themeStyle);
        }
        private void ShowSpecialSettingsProperties(List<SpecialSettingsLightColor> propertiesList)
        {
            PropertieNameBox.Items.Clear();
           
            foreach (var property in propertiesList)
                PropertieNameBox.Items.Add(property.Name);
        }
        private void ShowLangSettingsProperties(List<LanguageLightColor> filteredProperties)
        {
            PropertieNameBox.Items.Clear();

            foreach (var propertie in filteredProperties)
                PropertieNameBox.Items.Add(propertie.Name);
        }
        private void objectItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedObjProperties.Clear();
            ClearProperties();
            paramsGroup.Visible = false;

            if (objectItems.SelectedIndex == 0)
            {          
                ShowSpecialSettingsProperties(_themeChanger.SpecialSettingsColorsCollection);
                _selectedObjProperties.AddRange(_themeChanger.SpecialSettingsColorsCollection);
                langItems.Visible = false;
                langItems.SelectedIndex = -1;
            }
            else if (objectItems.SelectedIndex == 1 )
            {
                PropertieNameBox.Items.Clear();
                langItems.Visible = true;
            }
        }
        private void langItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearProperties();

            if (langItems.SelectedIndex == -1)
                return;

            _selectedObjProperties.Clear();
            paramsGroup.Visible = false;

            if (langItems.SelectedIndex == 0)
            {
                var csharpColors = _themeChanger.LangColorsCollection.Where(l => Equals(l.LanguageName, "C#")).ToList();
                ShowLangSettingsProperties(csharpColors);
                _selectedObjProperties.AddRange(csharpColors);
            }
            else if (langItems.SelectedIndex == 1)
            {
                var xmlColors = _themeChanger.LangColorsCollection.Where(l => Equals(l.LanguageName, "XML")).ToList();
                ShowLangSettingsProperties(xmlColors);
                _selectedObjProperties.AddRange(xmlColors);
            }
                
        }

        private void foreColorButton_Click(object sender, EventArgs e)
        {
            if (foreColorDialog.ShowDialog() == DialogResult.OK)
            {
                foreColorBox.Text = foreColorDialog.Color.ToArgb().ToString("x").ToUpper();
            }
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            if (backColorDialog.ShowDialog() == DialogResult.OK)
            {
                backColorBox.Text = backColorDialog.Color.ToArgb().ToString("x").ToUpper();
            }
        }
        private void SetColorsInTextBox(TextBox textBox, ColorType colorType)
        {
            var newValue = 0;

            if (Int32.TryParse(textBox.Text, System.Globalization.NumberStyles.HexNumber, new CultureInfo("ru-RU"), out newValue))
            {
                if (newValue == 0)
                {
                    textBox.BackColor = Color.Black;
                    return;
                } 
                var color = Color.FromArgb(newValue);
                try
                {
                    textBox.BackColor = color;
                }
                catch(Exception) 
                {
                    textBox.ForeColor = Color.Black;
                    textBox.BackColor = Color.White;
                    return;
                }
               
                textBox.ForeColor = color.GetBrightness() > 0.4 ? Color.Black : Color.White;

                if (colorType == ColorType.ForeColor)
                    _selectedForeColorElement = color;
                else _selectedBackColorElement = color;
            }
        }
        private void foreColorBox_TextChanged(object sender, EventArgs e)
        {
            SetColorsInTextBox(foreColorBox, ColorType.ForeColor);
            UpdateCodeColors(foreColorBox.BackColor, backColorBox.BackColor);
            savePropertiesButton.Visible = true;
        }

        private void backColorBox_TextChanged(object sender, EventArgs e)
        {
            SetColorsInTextBox(backColorBox, ColorType.BackColor);
            UpdateCodeColors(foreColorBox.BackColor, backColorBox.BackColor);
            savePropertiesButton.Visible = true;
        }
        private void GetColorCodeBySelectedItem(int index)
        {
            var propertie = _selectedObjProperties[index];
            var colorCodes = _themeChanger.ThemeGenerator
                            .ColorCodesCollecton.Where(c =>
                             Equals(propertie.Name, c.ObjectName));

            if (!colorCodes.Any())
                return;
            
            _selectedColorCode = colorCodes.FirstOrDefault();

            if (propertie.HasBackColor)
                UpdateCodeColors(propertie.ForeColor, propertie.BackColor.Value);
            else
                UpdateCodeColors(propertie.ForeColor);
        }
        private void UpdateCodeColors(Color foreColor, Color backColor)
        {
            if (_selectedColorCode.CodeLine == null)
                return;

            codeExampleBox.Clear();
            _selectedColorCode.ForeColor = foreColor;
            _selectedColorCode.BackColor = backColor;
            codeExampleBox.AddColorCode(_selectedColorCode);
        }
        private void UpdateCodeColors(Color foreColor)
        {
            if (_selectedColorCode.CodeLine == null)
                return;

            codeExampleBox.Clear();
            _selectedColorCode.ForeColor = foreColor;
            codeExampleBox.AddColorCode(_selectedColorCode);
        }
        private void ClearProperties()
        {
            foreColorBox.Text = string.Empty;
            backColorBox.Text = string.Empty;
            foreColorBox.BackColor = Color.White;
            backColorBox.BackColor = Color.White;
            codeExampleBox.Clear();
        }
        private void PropertieNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = PropertieNameBox.SelectedIndex;

            if (index == -1)
            {
                paramsGroup.Visible = false;

                return;
            }

            paramsGroup.Visible = true;
            var properties = _selectedObjProperties[index];
            codeExampleBox.Clear();
            boldBox.Checked = properties.IsBold;
            italicBox.Checked = properties.IsItalic;
            foreColorBox.Text = properties.ForeColor.ToArgb().ToString("x").ToUpper();
            GetColorCodeBySelectedItem(index);

            if (properties.HasBackColor)
            {
                backColorBox.Text = properties.BackColor.Value.ToArgb().ToString("x").ToUpper();
                backColorBox.Enabled = true;
                backColorButton.Enabled = true;
            }
            else
            { 
                backColorBox.Text = String.Empty;
                backColorBox.Enabled = false;
                backColorButton.Enabled = false;
            }

           _beforeChangeProperties = new HighlightingColorBase(_selectedObjProperties[index].Name,
                                                           boldBox.Checked ? true : false, italicBox.Checked,
                                                           _selectedForeColorElement, _selectedBackColorElement);
            savePropertiesButton.Visible = false;
        }

        private void savePropertiesButton_Click(object sender, EventArgs e)
        {
            if (PropertieNameBox.SelectedIndex == -1)
                return;

            var savedElement = _selectedObjProperties[PropertieNameBox.SelectedIndex];
            var elementType = savedElement is LanguageLightColor ? ElementType.LanguageElement : ElementType.SpecialElement;
            _themeChanger.ThemeGenerator.SavePropertiesInObject(elementType, savedElement.Name,
                                                                   boldBox.Checked, italicBox.Checked, 
                                                                   _selectedForeColorElement, _selectedBackColorElement);
           
            var differents = savedElement.GetPropertieDifferents(_beforeChangeProperties);

            foreach (var different in differents)
            {
                var length = propertieChangesBox.Text.Length;

                propertieChangesBox.AppendText(different.Key + "\n");

                foreach (var colors in different.Value)
                {
                    

                    if (colors.Key == 0)
                        continue;

                    propertieChangesBox.SelectionStart = length + colors.Key;
                    propertieChangesBox.SelectionLength = propertieChangesBox.Text.Length - colors.Key;
                    propertieChangesBox.SelectionColor = colors.Value.Value;
                }
            }

            _beforeChangeProperties = savedElement;
            savePropertiesButton.Visible = false;
            SetEnableFormElements(true, false);
            newThemeNameBox.Text = "Новая тема...";
            ShowSelectedTheme();
        }
        private void SetEnableFormElements(bool isVisible, bool isEnabled)
        {
            saveThemeButton.Visible = isVisible;
            newThemeNameBox.Visible = isVisible;
            themesCollectionBox.Enabled = isEnabled;
            applyUserThemeButton.Enabled = isEnabled;
            objectItems.Enabled = !isEnabled;
        }
        private async void applyUserThemeButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => _themeChanger.ReplaceThemeToDirectumRxFolder());
        }
        private void ClearSettingBoxes()
        {
            objectItems.SelectedIndex = -1;
            langItems.SelectedIndex = -1;
            PropertieNameBox.Items.Clear();
            savePropertiesButton.Visible = false;
            objectItems.Enabled = true;
        }
        private void themesCollectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themesCollectionBox.SelectedIndex == -1)
            {
                applyUserThemeButton.Visible = false;
                logoImageBox.Visible = true;
                deleteThemeBttn.Visible = false;
                
                return;
            }

            if (logoImageBox.Visible)
                logoImageBox.Visible = false;

            deleteThemeBttn.Visible = true;
            applyUserThemeButton.Visible = true;
            ClearSettingBoxes();
            _themeChanger.ThemeGenerator.ReadSelectedTheme(themesCollectionBox.SelectedIndex);
            ShowSelectedTheme();
            objectItems.Enabled = true;
        }
        private void ShowSelectedTheme()
        {
            new ThemeViewer(this.DirectumCodeBox,
                           _themeChanger.ThemeGenerator.SpecialSettingsColorsCollection,
                           _themeChanger.ThemeGenerator.LangColorsCollection)
                           .ColorizeTheme();
        }
        private void boldBox_CheckedChanged(object sender, EventArgs e)
        {
            savePropertiesButton.Visible = true;
        }

        private void italicBox_CheckedChanged(object sender, EventArgs e)
        {
            savePropertiesButton.Visible = true;
        }
        private bool CheckNewThemeName()
        {
            if (_themesCollection.Contains(newThemeNameBox.Text))
            {
                var dialogResult = MessageBox.Show("Тема с данными именем уже существует! Перезаписать тему?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.No)
                {
                    newThemeNameBox.Text = "Новая тема...";
                    return false;
                }
                else return true;
            }

            return true;
        }
        private async void saveThemeButton_Click(object sender, EventArgs e)
        {
            if (!CheckNewThemeName())
                return;
            
            _themeChanger.ThemeGenerator.WriteColorsToXML(newThemeNameBox.Text + ".xml");
            SetEnableFormElements(false, true);
            propertieChangesBox.Clear();
            themesCollectionBox.Items.Clear();
            var themes = await Task<List<string>>.Run(() => { return _themeChanger.InitializeUserThemes(); });
            themesCollectionBox.Items.AddRange(themes.ToArray());
            themesCollectionBox.SelectedIndex = -1;
            ClearSettingBoxes();
            applyUserThemeButton.Visible = false;
            logoImageBox.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", _themeChanger.ConfigFolderPath);
        }
        private void SetEnableResizeButtons(bool isFullSizeChecked)
        { 
           this.fullSizeBttn.Enabled = !isFullSizeChecked;
           this.compactSizebttn.Enabled = isFullSizeChecked;
        }
        private void SetBrightnessControls(bool isVisible)
        {
            brightnessValue.Visible = isVisible;
            brightnessBar.Visible = isVisible;
            brightnessBox.Visible = isVisible;
        }
        private void SizeAction(bool isVisible, int height)
        {
            if (logoImageBox.Visible)
                return;

            SetBrightnessControls(isVisible);
            DirectumCodeBox.Height = height;
            SetEnableResizeButtons(isVisible);
            brightnessBar.Value = 0;
        }
        private async void fullSizeBttn_Click(object sender, EventArgs e)
        {
            SizeAction(true, 730);
            await Task.Run(() => Thread.Sleep(300));
            var brightness = BrightnessTool.CalculateAverageLightness(DirectumCodeBox);
            this.brightnessBar.Value = (int)(brightness * 100000.0f);
            brightnessValue.Text = "Яркость: " + brightness;
        }

        private void compactSizebttn_Click(object sender, EventArgs e)
        {
            SizeAction(false, 334);
        }

        private void deleteThemeBttn_Click(object sender, EventArgs e)
        {
            if (saveThemeButton.Visible)
            {
                themesCollectionBox.SelectedIndex = -1;
                themesCollectionBox.Enabled = true;
                ClearSettingBoxes();
                applyUserThemeButton.Visible = false;
                logoImageBox.Visible = true;
                saveThemeButton.Visible = false;
                newThemeNameBox.Visible = false; 
                
                return;
            }

            _themeChanger.ThemeGenerator.DeleteSelectedTheme(themesCollectionBox.SelectedIndex);
            GetUserThemesCollection();
            logoImageBox.Visible = true;
        }

        private void themesCollectionBox_EnabledChanged(object sender, EventArgs e)
        {
            if (themesCollectionBox.Enabled)
                applyUserThemeButton.Enabled = true;
        }
    }
}
