using System.Windows.Forms;

namespace DirectumDSExtension
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.foreColorDialog = new System.Windows.Forms.ColorDialog();
            this.backColorDialog = new System.Windows.Forms.ColorDialog();
            this.ownSettingsGroup = new System.Windows.Forms.GroupBox();
            this.deleteThemeBttn = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.paramsGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.savePropertiesButton = new System.Windows.Forms.Button();
            this.backColorButton = new System.Windows.Forms.Button();
            this.codeExampleBox = new System.Windows.Forms.RichTextBox();
            this.backColorBox = new System.Windows.Forms.TextBox();
            this.foreColorBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.foreColorButton = new System.Windows.Forms.Button();
            this.italicBox = new System.Windows.Forms.CheckBox();
            this.boldBox = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.propertieChangesBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveThemeButton = new System.Windows.Forms.Button();
            this.newThemeNameBox = new System.Windows.Forms.TextBox();
            this.themesCollectionBox = new System.Windows.Forms.ListBox();
            this.applyUserThemeButton = new System.Windows.Forms.Button();
            this.langItems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PropertieNameBox = new System.Windows.Forms.ListBox();
            this.objectItems = new System.Windows.Forms.ComboBox();
            this.DirectumCodeBox = new System.Windows.Forms.RichTextBox();
            this.ThemeSettingsBox = new System.Windows.Forms.GroupBox();
            this.brightnessValue = new System.Windows.Forms.Label();
            this.brightnessBox = new System.Windows.Forms.PictureBox();
            this.brightnessBar = new System.Windows.Forms.ProgressBar();
            this.compactSizebttn = new System.Windows.Forms.Button();
            this.fullSizeBttn = new System.Windows.Forms.Button();
            this.logoImageBox = new System.Windows.Forms.PictureBox();
            this.ownSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.paramsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ThemeSettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ownSettingsGroup
            // 
            this.ownSettingsGroup.Controls.Add(this.deleteThemeBttn);
            this.ownSettingsGroup.Controls.Add(this.pictureBox6);
            this.ownSettingsGroup.Controls.Add(this.pictureBox2);
            this.ownSettingsGroup.Controls.Add(this.pictureBox5);
            this.ownSettingsGroup.Controls.Add(this.label9);
            this.ownSettingsGroup.Controls.Add(this.paramsGroup);
            this.ownSettingsGroup.Controls.Add(this.pictureBox4);
            this.ownSettingsGroup.Controls.Add(this.pictureBox3);
            this.ownSettingsGroup.Controls.Add(this.pictureBox1);
            this.ownSettingsGroup.Controls.Add(this.label7);
            this.ownSettingsGroup.Controls.Add(this.propertieChangesBox);
            this.ownSettingsGroup.Controls.Add(this.label5);
            this.ownSettingsGroup.Controls.Add(this.label6);
            this.ownSettingsGroup.Controls.Add(this.saveThemeButton);
            this.ownSettingsGroup.Controls.Add(this.newThemeNameBox);
            this.ownSettingsGroup.Controls.Add(this.themesCollectionBox);
            this.ownSettingsGroup.Controls.Add(this.applyUserThemeButton);
            this.ownSettingsGroup.Controls.Add(this.langItems);
            this.ownSettingsGroup.Controls.Add(this.label1);
            this.ownSettingsGroup.Controls.Add(this.PropertieNameBox);
            this.ownSettingsGroup.Controls.Add(this.objectItems);
            this.ownSettingsGroup.Location = new System.Drawing.Point(6, 413);
            this.ownSettingsGroup.Name = "ownSettingsGroup";
            this.ownSettingsGroup.Size = new System.Drawing.Size(728, 369);
            this.ownSettingsGroup.TabIndex = 9;
            this.ownSettingsGroup.TabStop = false;
            // 
            // deleteThemeBttn
            // 
            this.deleteThemeBttn.BackgroundImage = global::DirectumDSExtension.Properties.Resources.deleteButton;
            this.deleteThemeBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteThemeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteThemeBttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.deleteThemeBttn.Location = new System.Drawing.Point(197, 135);
            this.deleteThemeBttn.Name = "deleteThemeBttn";
            this.deleteThemeBttn.Size = new System.Drawing.Size(37, 37);
            this.deleteThemeBttn.TabIndex = 38;
            this.deleteThemeBttn.UseVisualStyleBackColor = true;
            this.deleteThemeBttn.Visible = false;
            this.deleteThemeBttn.Click += new System.EventHandler(this.deleteThemeBttn_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::DirectumDSExtension.Properties.Resources.logoDirectum;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(206, 319);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(28, 27);
            this.pictureBox6.TabIndex = 37;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::DirectumDSExtension.Properties.Resources.savedChanges;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(683, 227);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 39);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::DirectumDSExtension.Properties.Resources.parameters;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(580, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 47);
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(448, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 22);
            this.label9.TabIndex = 35;
            this.label9.Text = "Параметры";
            // 
            // paramsGroup
            // 
            this.paramsGroup.Controls.Add(this.label2);
            this.paramsGroup.Controls.Add(this.savePropertiesButton);
            this.paramsGroup.Controls.Add(this.backColorButton);
            this.paramsGroup.Controls.Add(this.codeExampleBox);
            this.paramsGroup.Controls.Add(this.backColorBox);
            this.paramsGroup.Controls.Add(this.foreColorBox);
            this.paramsGroup.Controls.Add(this.label3);
            this.paramsGroup.Controls.Add(this.label4);
            this.paramsGroup.Controls.Add(this.foreColorButton);
            this.paramsGroup.Controls.Add(this.italicBox);
            this.paramsGroup.Controls.Add(this.boldBox);
            this.paramsGroup.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paramsGroup.ForeColor = System.Drawing.Color.White;
            this.paramsGroup.Location = new System.Drawing.Point(445, 40);
            this.paramsGroup.Name = "paramsGroup";
            this.paramsGroup.Size = new System.Drawing.Size(277, 186);
            this.paramsGroup.TabIndex = 34;
            this.paramsGroup.TabStop = false;
            this.paramsGroup.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Цвет текста";
            // 
            // savePropertiesButton
            // 
            this.savePropertiesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("savePropertiesButton.BackgroundImage")));
            this.savePropertiesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.savePropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePropertiesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.savePropertiesButton.Location = new System.Drawing.Point(225, 82);
            this.savePropertiesButton.Name = "savePropertiesButton";
            this.savePropertiesButton.Size = new System.Drawing.Size(43, 50);
            this.savePropertiesButton.TabIndex = 22;
            this.savePropertiesButton.UseVisualStyleBackColor = true;
            this.savePropertiesButton.Visible = false;
            this.savePropertiesButton.Click += new System.EventHandler(this.savePropertiesButton_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.BackgroundImage = global::DirectumDSExtension.Properties.Resources.changeColor;
            this.backColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backColorButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backColorButton.Location = new System.Drawing.Point(239, 51);
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(29, 25);
            this.backColorButton.TabIndex = 21;
            this.backColorButton.UseVisualStyleBackColor = true;
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // codeExampleBox
            // 
            this.codeExampleBox.BackColor = System.Drawing.Color.White;
            this.codeExampleBox.Enabled = false;
            this.codeExampleBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeExampleBox.ForeColor = System.Drawing.Color.Black;
            this.codeExampleBox.Location = new System.Drawing.Point(5, 135);
            this.codeExampleBox.Name = "codeExampleBox";
            this.codeExampleBox.Size = new System.Drawing.Size(263, 46);
            this.codeExampleBox.TabIndex = 10;
            this.codeExampleBox.Text = "";
            // 
            // backColorBox
            // 
            this.backColorBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backColorBox.Location = new System.Drawing.Point(135, 51);
            this.backColorBox.Name = "backColorBox";
            this.backColorBox.Size = new System.Drawing.Size(96, 25);
            this.backColorBox.TabIndex = 19;
            this.backColorBox.TextChanged += new System.EventHandler(this.backColorBox_TextChanged);
            // 
            // foreColorBox
            // 
            this.foreColorBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foreColorBox.Location = new System.Drawing.Point(135, 15);
            this.foreColorBox.Name = "foreColorBox";
            this.foreColorBox.Size = new System.Drawing.Size(96, 25);
            this.foreColorBox.TabIndex = 18;
            this.foreColorBox.TextChanged += new System.EventHandler(this.foreColorBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Цвет фона";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 22);
            this.label4.TabIndex = 15;
            this.label4.Text = "Пример";
            // 
            // foreColorButton
            // 
            this.foreColorButton.BackgroundImage = global::DirectumDSExtension.Properties.Resources.changeColor;
            this.foreColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.foreColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.foreColorButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foreColorButton.Location = new System.Drawing.Point(237, 15);
            this.foreColorButton.Name = "foreColorButton";
            this.foreColorButton.Size = new System.Drawing.Size(31, 27);
            this.foreColorButton.TabIndex = 20;
            this.foreColorButton.UseVisualStyleBackColor = true;
            this.foreColorButton.Click += new System.EventHandler(this.foreColorButton_Click);
            // 
            // italicBox
            // 
            this.italicBox.AutoSize = true;
            this.italicBox.Font = new System.Drawing.Font("Skranji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.italicBox.ForeColor = System.Drawing.Color.White;
            this.italicBox.Location = new System.Drawing.Point(135, 82);
            this.italicBox.Name = "italicBox";
            this.italicBox.Size = new System.Drawing.Size(84, 25);
            this.italicBox.TabIndex = 14;
            this.italicBox.Text = "Курсив";
            this.italicBox.UseVisualStyleBackColor = true;
            this.italicBox.CheckedChanged += new System.EventHandler(this.italicBox_CheckedChanged);
            // 
            // boldBox
            // 
            this.boldBox.AutoSize = true;
            this.boldBox.Font = new System.Drawing.Font("Skranji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boldBox.ForeColor = System.Drawing.Color.White;
            this.boldBox.Location = new System.Drawing.Point(7, 82);
            this.boldBox.Name = "boldBox";
            this.boldBox.Size = new System.Drawing.Size(129, 25);
            this.boldBox.TabIndex = 13;
            this.boldBox.Text = "Полужирный";
            this.boldBox.UseVisualStyleBackColor = true;
            this.boldBox.CheckedChanged += new System.EventHandler(this.boldBox_CheckedChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::DirectumDSExtension.Properties.Resources.propertieCod;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(384, -6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 43);
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(154, 262);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 94);
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DirectumDSExtension.Properties.Resources.themeIco;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(156, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(236, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "Элемент кода";
            // 
            // propertieChangesBox
            // 
            this.propertieChangesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.propertieChangesBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.propertieChangesBox.ForeColor = System.Drawing.Color.White;
            this.propertieChangesBox.Location = new System.Drawing.Point(448, 254);
            this.propertieChangesBox.Name = "propertieChangesBox";
            this.propertieChangesBox.ReadOnly = true;
            this.propertieChangesBox.Size = new System.Drawing.Size(274, 108);
            this.propertieChangesBox.TabIndex = 28;
            this.propertieChangesBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(451, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 22);
            this.label5.TabIndex = 27;
            this.label5.Text = "Сохраненные изменения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 22);
            this.label6.TabIndex = 29;
            this.label6.Text = "Коллекция тем";
            // 
            // saveThemeButton
            // 
            this.saveThemeButton.BackgroundImage = global::DirectumDSExtension.Properties.Resources.save3d;
            this.saveThemeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveThemeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.saveThemeButton.Location = new System.Drawing.Point(197, 180);
            this.saveThemeButton.Name = "saveThemeButton";
            this.saveThemeButton.Size = new System.Drawing.Size(37, 43);
            this.saveThemeButton.TabIndex = 25;
            this.saveThemeButton.UseVisualStyleBackColor = true;
            this.saveThemeButton.Visible = false;
            this.saveThemeButton.Click += new System.EventHandler(this.saveThemeButton_Click);
            // 
            // newThemeNameBox
            // 
            this.newThemeNameBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newThemeNameBox.Location = new System.Drawing.Point(6, 165);
            this.newThemeNameBox.Name = "newThemeNameBox";
            this.newThemeNameBox.Size = new System.Drawing.Size(176, 25);
            this.newThemeNameBox.TabIndex = 24;
            this.newThemeNameBox.Visible = false;
            // 
            // themesCollectionBox
            // 
            this.themesCollectionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.themesCollectionBox.ForeColor = System.Drawing.Color.White;
            this.themesCollectionBox.FormattingEnabled = true;
            this.themesCollectionBox.ItemHeight = 21;
            this.themesCollectionBox.Location = new System.Drawing.Point(6, 43);
            this.themesCollectionBox.Name = "themesCollectionBox";
            this.themesCollectionBox.Size = new System.Drawing.Size(228, 109);
            this.themesCollectionBox.TabIndex = 23;
            this.themesCollectionBox.SelectedIndexChanged += new System.EventHandler(this.themesCollectionBox_SelectedIndexChanged);
            this.themesCollectionBox.EnabledChanged += new System.EventHandler(this.themesCollectionBox_EnabledChanged);
            // 
            // applyUserThemeButton
            // 
            this.applyUserThemeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("applyUserThemeButton.BackgroundImage")));
            this.applyUserThemeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.applyUserThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applyUserThemeButton.Font = new System.Drawing.Font("Skranji", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyUserThemeButton.ForeColor = System.Drawing.Color.White;
            this.applyUserThemeButton.Location = new System.Drawing.Point(6, 305);
            this.applyUserThemeButton.Name = "applyUserThemeButton";
            this.applyUserThemeButton.Size = new System.Drawing.Size(142, 51);
            this.applyUserThemeButton.TabIndex = 17;
            this.applyUserThemeButton.Text = "Применить тему";
            this.applyUserThemeButton.UseVisualStyleBackColor = true;
            this.applyUserThemeButton.Click += new System.EventHandler(this.applyUserThemeButton_Click);
            // 
            // langItems
            // 
            this.langItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langItems.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.langItems.FormattingEnabled = true;
            this.langItems.Items.AddRange(new object[] {
            "C#",
            "XML"});
            this.langItems.Location = new System.Drawing.Point(6, 262);
            this.langItems.Name = "langItems";
            this.langItems.Size = new System.Drawing.Size(142, 27);
            this.langItems.TabIndex = 10;
            this.langItems.Visible = false;
            this.langItems.SelectedIndexChanged += new System.EventHandler(this.langItems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Skranji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Объект";
            // 
            // PropertieNameBox
            // 
            this.PropertieNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PropertieNameBox.ForeColor = System.Drawing.Color.White;
            this.PropertieNameBox.FormattingEnabled = true;
            this.PropertieNameBox.ItemHeight = 21;
            this.PropertieNameBox.Location = new System.Drawing.Point(240, 43);
            this.PropertieNameBox.Name = "PropertieNameBox";
            this.PropertieNameBox.Size = new System.Drawing.Size(199, 319);
            this.PropertieNameBox.TabIndex = 7;
            this.PropertieNameBox.SelectedIndexChanged += new System.EventHandler(this.PropertieNameBox_SelectedIndexChanged);
            // 
            // objectItems
            // 
            this.objectItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectItems.Enabled = false;
            this.objectItems.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectItems.FormattingEnabled = true;
            this.objectItems.Items.AddRange(new object[] {
            "Специальные настройки",
            "Элемент синтаксиса языка"});
            this.objectItems.Location = new System.Drawing.Point(6, 229);
            this.objectItems.Name = "objectItems";
            this.objectItems.Size = new System.Drawing.Size(228, 27);
            this.objectItems.TabIndex = 8;
            this.objectItems.SelectedIndexChanged += new System.EventHandler(this.objectItems_SelectedIndexChanged);
            // 
            // DirectumCodeBox
            // 
            this.DirectumCodeBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirectumCodeBox.Location = new System.Drawing.Point(9, 46);
            this.DirectumCodeBox.Name = "DirectumCodeBox";
            this.DirectumCodeBox.ReadOnly = true;
            this.DirectumCodeBox.Size = new System.Drawing.Size(725, 355);
            this.DirectumCodeBox.TabIndex = 10;
            this.DirectumCodeBox.Text = resources.GetString("DirectumCodeBox.Text");
            // 
            // ThemeSettingsBox
            // 
            this.ThemeSettingsBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ThemeSettingsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ThemeSettingsBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ThemeSettingsBox.Controls.Add(this.brightnessValue);
            this.ThemeSettingsBox.Controls.Add(this.brightnessBox);
            this.ThemeSettingsBox.Controls.Add(this.brightnessBar);
            this.ThemeSettingsBox.Controls.Add(this.compactSizebttn);
            this.ThemeSettingsBox.Controls.Add(this.fullSizeBttn);
            this.ThemeSettingsBox.Controls.Add(this.logoImageBox);
            this.ThemeSettingsBox.Controls.Add(this.DirectumCodeBox);
            this.ThemeSettingsBox.Controls.Add(this.ownSettingsGroup);
            this.ThemeSettingsBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThemeSettingsBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeSettingsBox.ForeColor = System.Drawing.Color.White;
            this.ThemeSettingsBox.Location = new System.Drawing.Point(3, 0);
            this.ThemeSettingsBox.Name = "ThemeSettingsBox";
            this.ThemeSettingsBox.Size = new System.Drawing.Size(740, 801);
            this.ThemeSettingsBox.TabIndex = 0;
            this.ThemeSettingsBox.TabStop = false;
            this.ThemeSettingsBox.Text = "Конструктор тем⚙️";
            // 
            // brightnessValue
            // 
            this.brightnessValue.AutoSize = true;
            this.brightnessValue.Font = new System.Drawing.Font("Skranji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessValue.Location = new System.Drawing.Point(3, 25);
            this.brightnessValue.Name = "brightnessValue";
            this.brightnessValue.Size = new System.Drawing.Size(72, 18);
            this.brightnessValue.TabIndex = 30;
            this.brightnessValue.Text = "Яркость:";
            this.brightnessValue.Visible = false;
            // 
            // brightnessBox
            // 
            this.brightnessBox.BackgroundImage = global::DirectumDSExtension.Properties.Resources.brightness;
            this.brightnessBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.brightnessBox.Location = new System.Drawing.Point(142, 16);
            this.brightnessBox.Name = "brightnessBox";
            this.brightnessBox.Size = new System.Drawing.Size(47, 27);
            this.brightnessBox.TabIndex = 15;
            this.brightnessBox.TabStop = false;
            this.brightnessBox.Visible = false;
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(195, 28);
            this.brightnessBar.Maximum = 100000;
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(441, 12);
            this.brightnessBar.Step = 10000;
            this.brightnessBar.TabIndex = 14;
            this.brightnessBar.Visible = false;
            // 
            // compactSizebttn
            // 
            this.compactSizebttn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("compactSizebttn.BackgroundImage")));
            this.compactSizebttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.compactSizebttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.compactSizebttn.Location = new System.Drawing.Point(695, 6);
            this.compactSizebttn.Name = "compactSizebttn";
            this.compactSizebttn.Size = new System.Drawing.Size(33, 34);
            this.compactSizebttn.TabIndex = 13;
            this.compactSizebttn.UseVisualStyleBackColor = true;
            this.compactSizebttn.Click += new System.EventHandler(this.compactSizebttn_Click);
            // 
            // fullSizeBttn
            // 
            this.fullSizeBttn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fullSizeBttn.BackgroundImage")));
            this.fullSizeBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fullSizeBttn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fullSizeBttn.Location = new System.Drawing.Point(648, 6);
            this.fullSizeBttn.Name = "fullSizeBttn";
            this.fullSizeBttn.Size = new System.Drawing.Size(34, 34);
            this.fullSizeBttn.TabIndex = 12;
            this.fullSizeBttn.UseVisualStyleBackColor = true;
            this.fullSizeBttn.Click += new System.EventHandler(this.fullSizeBttn_Click);
            // 
            // logoImageBox
            // 
            this.logoImageBox.BackColor = System.Drawing.Color.White;
            this.logoImageBox.BackgroundImage = global::DirectumDSExtension.Properties.Resources.logo;
            this.logoImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logoImageBox.Location = new System.Drawing.Point(9, 46);
            this.logoImageBox.Name = "logoImageBox";
            this.logoImageBox.Size = new System.Drawing.Size(725, 355);
            this.logoImageBox.TabIndex = 11;
            this.logoImageBox.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 794);
            this.Controls.Add(this.ThemeSettingsBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(760, 833);
            this.MinimumSize = new System.Drawing.Size(760, 833);
            this.Name = "MainWindow";
            this.Text = "Directum Development Studio Extension";
            this.ownSettingsGroup.ResumeLayout(false);
            this.ownSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.paramsGroup.ResumeLayout(false);
            this.paramsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ThemeSettingsBox.ResumeLayout(false);
            this.ThemeSettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ColorDialog foreColorDialog;
        private ColorDialog backColorDialog;
        private GroupBox ownSettingsGroup;
        private GroupBox paramsGroup;
        private PictureBox pictureBox5;
        private Label label2;
        private Button savePropertiesButton;
        private Button backColorButton;
        private RichTextBox codeExampleBox;
        private TextBox backColorBox;
        private TextBox foreColorBox;
        private Label label3;
        private Label label4;
        private Button foreColorButton;
        private CheckBox italicBox;
        private CheckBox boldBox;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label6;
        private RichTextBox propertieChangesBox;
        private Label label5;
        private Button saveThemeButton;
        private TextBox newThemeNameBox;
        private ListBox themesCollectionBox;
        private Button applyUserThemeButton;
        private ComboBox langItems;
        private Label label1;
        private ListBox PropertieNameBox;
        private ComboBox objectItems;
        private RichTextBox DirectumCodeBox;
        private GroupBox ThemeSettingsBox;
        private Label label9;
        private PictureBox pictureBox2;
        private PictureBox logoImageBox;
        private PictureBox pictureBox6;
        private Button fullSizeBttn;
        private Button compactSizebttn;
        private Button deleteThemeBttn;
        private ProgressBar brightnessBar;
        private Label brightnessValue;
        private PictureBox brightnessBox;
    }
}

