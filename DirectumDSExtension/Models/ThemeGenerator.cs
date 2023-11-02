using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Класс, генерирующий содержимое темы
    /// </summary>
    internal class ThemeGenerator
    {
        private const string FOLDER_THEMES_NAME = "UserThemes";
        private const string DARK_THEME_NAME = "Темная тема.xml";
        private const string LIGHT_THEME_NAME = "Светлая тема.xml";
        private readonly string _userThemesFolderPath;
        private string _selectedThemePath;
        private List<LanguageLightColor> _languageColors;
        private List<SpecialSettingsLightColor> _specialSettingsColors;
        private string[] _userThemeNames;
        private readonly ColorCode[] _colorCodesCollection;
        private string _allSettingsBody;
        private Logger _logger;
        public ThemeGenerator()
        {
            var currentDir = Path.GetDirectoryName(
            Assembly.GetEntryAssembly().Location
            );
            _userThemesFolderPath = Path.Combine(currentDir, FOLDER_THEMES_NAME);
            _logger = new Logger();
            _languageColors = new List<LanguageLightColor>();
            _specialSettingsColors = new List<SpecialSettingsLightColor>();
            _colorCodesCollection = ColorCodeGenerator.GetColorCodes();
        }
        public List<LanguageLightColor> LangColorsCollection
        {
            get { return _languageColors; }
        }
        public List<SpecialSettingsLightColor> SpecialSettingsColorsCollection
        {
            get { return _specialSettingsColors; }
        }
        public ColorCode[] ColorCodesCollecton
        {
            get { return _colorCodesCollection; }
        }
        public List<string> UserThemeNames
        {
            get
            {
                var onlyNames = new List<string>();

                foreach (var item in _userThemeNames)
                    onlyNames.Add(Path.GetFileNameWithoutExtension(item));

                return onlyNames;
            }
        }
        public string SelectedThemePath
        {
            get { return _selectedThemePath; }
        }
        public string AllSettignsBody
        {
            get { return _allSettingsBody != null ? _allSettingsBody : String.Empty; }
        }

       /// <summary>
       /// Получает все темы, которые есть в папке UserThemes, если папки нет, и там меньше 2 тем, 
       /// то создает папку, и в ней светлую и темную темы
       /// </summary>
        public void GetUserThemeNames()
        {
            if (!Directory.Exists(_userThemesFolderPath) || Directory.GetFiles(_userThemesFolderPath).Length < 2)
            {
                Directory.CreateDirectory(_userThemesFolderPath);
                File.WriteAllText(Path.Combine(_userThemesFolderPath, DARK_THEME_NAME), Properties.Resources.blackBody);
                File.WriteAllText(Path.Combine(_userThemesFolderPath, LIGHT_THEME_NAME), Properties.Resources.whiteBody);
            }

            _userThemeNames = Directory.GetFiles(_userThemesFolderPath);          
        }
        /// <summary>
        /// Удаляет выбранную пользовательскую тему
        /// </summary>
        /// <param name="themeIndex"></param>
        public void DeleteSelectedTheme(int themeIndex)
        {
            try
            {
                File.Delete(_userThemeNames[themeIndex]);
                GetUserThemeNames();
                _logger.AddAsync(String.Format("Тема {0} удалена", 
                                               Path.GetFileName(_userThemeNames[themeIndex])));
            }
            catch (FileNotFoundException e)
            {
                _logger.AddAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.AddAsync(e.Message);
            }
        }
        public void ReadSelectedTheme(int themeIndex)
        {
            _specialSettingsColors.Clear();
            _languageColors.Clear();
            try
            {
                if (themeIndex > _userThemeNames.Length - 1 || themeIndex < 0)
                    themeIndex = 0;

                _selectedThemePath = _userThemeNames[themeIndex];
                ReadColorsFromXML();
                _logger.AddAsync("User theme was parsed!");
            }
            catch (FileNotFoundException e)
            {
                _logger.AddAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.AddAsync(e.Message);
            }

        }
        
        /// <summary>
        /// С помощью Linq по тегам ищет содержимое свойств
        /// Передает значения в конструктор сущностей свойств цветов
        /// </summary>
        private void ReadColorsFromXML()
        {
            var xmlFile = XDocument.Load(_selectedThemePath);
            var colorBodyXml = xmlFile.Element(Tag.DEVELOPMENT_STUDIO_TAG).Elements(Tag.SERIALIZED_VALUE_TAG);
            colorBodyXml = colorBodyXml.Where(x => x.Attribute("name").Value == Tag.HIGHLIGHTING_RULES_ATTRIBUTE);

            if (!colorBodyXml.Any())
                return;
            var colorsList = colorBodyXml.FirstOrDefault()
                                         .Element(Tag.ARRAY_COLORS_TAG)?
                                         .Elements(Tag.HIGHLIGHTING_COLOR_TAG);

            if (colorsList == null)
                return;

            Color? noBackColor = null;
            var languageColors = colorsList.Where(c => c.Element(Tag.LANGUAGE_TAG) != null)
                                           .Select(l => new LanguageLightColor(
                                               l.Element(Tag.NAME_TAG)?.Value,
                                               Boolean.Parse(l.Element(Tag.BOLD_TAG)?.Value),
                                               Boolean.Parse(l.Element(Tag.ITALIC_TAG)?.Value),
                                               GetColorFromXML(l.Element(Tag.FOREGROUND_TAG)),
                                               l.Element(Tag.BACKGROUND_TAG) != null ? GetColorFromXML(l.Element(Tag.BACKGROUND_TAG)) : noBackColor,
                                               l.Element(Tag.LANGUAGE_TAG)?.Value
                                               ));
            
            var specialSettingsColors = colorsList.Where(c => c.Element(Tag.LANGUAGE_TAG) == null)
                                           .Select(l => new SpecialSettingsLightColor(
                                               l.Element(Tag.NAME_TAG)?.Value,
                                               Boolean.Parse(l.Element(Tag.BOLD_TAG)?.Value),
                                               Boolean.Parse(l.Element(Tag.ITALIC_TAG)?.Value),
                                               GetColorFromXML(l.Element(Tag.FOREGROUND_TAG)),
                                               l.Element(Tag.BACKGROUND_TAG) != null ? GetColorFromXML(l.Element(Tag.BACKGROUND_TAG)) : noBackColor
                                               ));
           
            _languageColors.AddRange(languageColors);
            _specialSettingsColors.AddRange(specialSettingsColors);
            CreateXmlBody();
        }
     
        public void SavePropertiesInObject(ElementType elementType, string objectName, bool isBold, 
                                           bool isItalic, Color foreColor, Color backColor)
        {
           int index = 0;
           
           switch (elementType) 
           {
                case ElementType.LanguageElement:
                    index = _languageColors.FindIndex(l => Equals(l.Name, objectName));
                    _languageColors[index].IsBold = isBold;
                    _languageColors[index].IsItalic = isItalic;
                    _languageColors[index].ForeColor = foreColor;
                    _languageColors[index].BackColor = backColor;
                    break;
                case ElementType.SpecialElement:
                    index = _specialSettingsColors.FindIndex(l => Equals(l.Name, objectName));
                    _specialSettingsColors[index].IsBold = isBold;
                    _specialSettingsColors[index].IsItalic = isItalic;
                    _specialSettingsColors[index].ForeColor = foreColor;
                    _specialSettingsColors[index].BackColor = backColor;
                    break;                  
            }
        }
        
        /// <summary>
        /// Создает тело документа на основе содержимого верхнеуровневых тегов,
        /// затем подставляет в них значения тегов, отвечающих за цвета сущностей кода
        /// </summary>
        private void CreateXmlBody()
        {
            var xmlDoc = XDocument.Parse(Properties.Resources.colorsContainer);

            foreach (var langColor in _languageColors)
            {
                var xmlLangElement = new XElement(Tag.HIGHLIGHTING_COLOR_TAG,
                    new XElement(Tag.LANGUAGE_TAG, langColor.LanguageName),
                    new XElement(Tag.NAME_TAG, langColor.Name),
                    new XElement(Tag.BOLD_TAG, langColor.IsBold),
                    new XElement(Tag.ITALIC_TAG, langColor.IsItalic),
                    GeXMLFromColor(Tag.FOREGROUND_TAG, langColor.ForeColor)
                    );

                if (langColor.HasBackColor)
                    xmlLangElement.Add(GeXMLFromColor(Tag.BACKGROUND_TAG, langColor.BackColor.Value));

                xmlDoc.Element(Tag.SERIALIZED_VALUE_TAG)?
                      .Element(Tag.ARRAY_COLORS_TAG)?.Add(
                                     xmlLangElement);
            }

            foreach (var specialSettingsColor in _specialSettingsColors)
            {
                var xmlSpecialElement = new XElement(Tag.HIGHLIGHTING_COLOR_TAG,
                    new XElement(Tag.NAME_TAG, specialSettingsColor.Name),
                    new XElement(Tag.BOLD_TAG, specialSettingsColor.IsBold),
                    new XElement(Tag.ITALIC_TAG, specialSettingsColor.IsItalic),
                    GeXMLFromColor(Tag.FOREGROUND_TAG, specialSettingsColor.ForeColor)
                    );

                if (specialSettingsColor.HasBackColor)
                    xmlSpecialElement.Add(GeXMLFromColor(Tag.BACKGROUND_TAG, specialSettingsColor.BackColor.Value));

                xmlDoc.Element(Tag.SERIALIZED_VALUE_TAG)?
                                   .Element(Tag.ARRAY_COLORS_TAG)?
                                   .Add(xmlSpecialElement);
            }

            _allSettingsBody = CreateAllSettingsBody(xmlDoc).Replace(Tag.XML_INFO_TAG, String.Empty);
        }
        public void WriteColorsToXML(string themeName)
        { 

            try
            {
                CreateXmlBody();
                var path = Path.Combine(_userThemesFolderPath, themeName);
                File.WriteAllText(path, _allSettingsBody);
                _logger.AddAsync(String.Format("{0} theme was saved", themeName));
            }
            catch (FileNotFoundException e)
            {
                _logger.AddAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.AddAsync(e.Message);
            }
        }
        private Color GetColorFromXML(XElement colorXML)
        {
            var A = Int32.Parse(colorXML.Element("A")?.Value);
            var R = Int32.Parse(colorXML.Element("R")?.Value);
            var G = Int32.Parse(colorXML.Element("G")?.Value);
            var B = Int32.Parse(colorXML.Element("B")?.Value);

            return Color.FromArgb(A, R, G, B);
        }
        private XElement GeXMLFromColor(string tag, Color color)
        {
            var colorXml = new XElement(tag,
                new XElement("A", color.A),
                new XElement("R", color.R),
                new XElement("G", color.G),
                new XElement("B", color.B)
                );

            return colorXml;
        }
        private string CreateAllSettingsBody(string themeBody)
        {
            var allSettingsBody = new StringBuilder();
            allSettingsBody.Append(Properties.Resources.firstSettings);
            allSettingsBody.Append(themeBody);
            allSettingsBody.Append(Properties.Resources.lastSettings);
            
            return allSettingsBody.ToString();
        }
        private string CreateAllSettingsBody(XDocument themeBody)
        {
            var allSettingsBody = new StringBuilder();
            allSettingsBody.Append(Properties.Resources.firstSettings);          
            var memory = new MemoryStream();
            themeBody.Save(memory);
            memory.Close();
            memory.Dispose();
            string themeBodyText = Encoding.UTF8.GetString(memory.ToArray());
            allSettingsBody.Append(themeBodyText);
            allSettingsBody.Append(Properties.Resources.lastSettings);

            return allSettingsBody.ToString();
        }
    }
}
