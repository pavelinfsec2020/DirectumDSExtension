using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Основной класс, реализующий применение выбранной темы
    /// </summary>
    internal class ThemeChanger : DirectumExtension
    {
        private const string THEME_SETTINGS_NAME = "DevelopmentStudioProperties.xml";
        private readonly string _themeSettingsFilePath;
        private Process _studioProcess;
        private ThemeGenerator _themesGenerator;
        private Logger _logger;
        public ThemeChanger()
        {
            _themeSettingsFilePath = Path.Combine(base.ConfigFolderPath, THEME_SETTINGS_NAME);
            _logger = new Logger();
            _themesGenerator = new ThemeGenerator();
        }
        public List<LanguageLightColor> LangColorsCollection
        {
            get { return _themesGenerator.LangColorsCollection; }
        }
        public List<SpecialSettingsLightColor> SpecialSettingsColorsCollection
        {
            get { return _themesGenerator.SpecialSettingsColorsCollection; }
        }
        public ThemeGenerator ThemeGenerator
        {
            get { return _themesGenerator; }
        }

        public void SetTheme(ThemeStyle selectedColor)
        {
            _logger.AddAsync(
                AbortDirectumDSProcess());
            _logger.AddAsync(
                ReplaceThemeSettingsFile(selectedColor));
            _logger.AddAsync(
                RestartDirectumDSProcess());
        }

        public string ReplaceThemeSettingsFile(ThemeStyle selectedTheme)
        {
            try
            {
                var result = String.Empty;

                switch (selectedTheme)
                {
                    case ThemeStyle.White:
                        File.WriteAllText(_themeSettingsFilePath, Properties.Resources.DevelopmentStudioProperties_white);
                        return "White theme was installed";
                    case ThemeStyle.Black:
                        File.WriteAllText(_themeSettingsFilePath, Properties.Resources.DevelopmentStudioProperties_black);
                        return "Black theme was installed";
                }

                return result;
            }
            catch (DirectoryNotFoundException dirEx)
            {
                return dirEx.Message;
            }
            catch (FileNotFoundException fileEx)
            {
                return String.Format($"{fileEx.Message} \n Путь: {fileEx.FileName}");
            }
            catch (UnauthorizedAccessException accessException)
            {
                return accessException.Message;
            }
            catch (IOException inputException)
            {
                return inputException.Message;
            }
            catch (Exception otherException)
            {
                return otherException.Message;
            }
        }
        /// <summary>
        /// Получает список имеющихся пользовательских тем
        /// </summary>
        /// <returns></returns>
        public List<string> InitializeUserThemes()
        {
            _themesGenerator.GetUserThemeNames();
            var themesList = _themesGenerator.UserThemeNames.Count > 0 ? _themesGenerator.UserThemeNames : new List<string>() {"No themes"};

            return themesList;
        }
       
        /// <summary>
        /// Убивает процесс DDS, если есть, записывает содержимое выбранной темы,
        /// Запускает заново DDS
        /// </summary>
        public void ReplaceThemeToDirectumRxFolder()
        {
            if (_themesGenerator.AllSettignsBody == String.Empty)
                return;

            try 
            {
                _logger.AddAsync(AbortDirectumDSProcess());
                File.WriteAllText(_themeSettingsFilePath, _themesGenerator.AllSettignsBody);
                _logger.AddAsync("Selected theme was saved");
                _logger.AddAsync(RestartDirectumDSProcess());
            }      
            catch (DirectoryNotFoundException dirEx)
            {
                _logger.AddAsync(dirEx.Message);
            }
            catch (FileNotFoundException fileEx)
            {
                _logger.AddAsync(String.Format($"{fileEx.Message} \n Путь: {fileEx.FileName}"));
            }
            catch (Exception otherException)
            {
                _logger.AddAsync(otherException.Message);
            }
        }
        /// <summary>
        /// Убивает DDS, если есть
        /// </summary>
        /// <returns></returns>
        private string AbortDirectumDSProcess()
        {          
            var studioProcess =  Process.GetProcessesByName(base.StudioProcessName)
                                .FirstOrDefault();
            
            if (studioProcess != null) 
            {
                try
                {
                    studioProcess.Kill();
                    studioProcess.WaitForExit();
                    studioProcess.Dispose();

                    return "DirectumStudio killed";
                }
                catch (UnauthorizedAccessException accessException)
                {
                    return accessException.Message;
                }
                catch (Exception otherException)
                {
                    return otherException.Message;
                }
            }

            return "Process not found";
        }
        
        /// <summary>
        /// Перезапускает DDS
        /// </summary>
        /// <returns></returns>
        private string RestartDirectumDSProcess()
        {
            var studioProcess = Process.GetProcessesByName(base.StudioProcessName);

            if (studioProcess.Any())
                return "Directum Studio already running";

            try
            {
               var startedProcess =  Process.Start(String.Concat(base.StudioFileName));
               var result = startedProcess != null ? "DirectumStudio started" : "DirectumStudio not started";

                return result;
            }
            catch (UnauthorizedAccessException accessException)
            {
                return accessException.Message;
            }
            catch (Exception otherException)
            {
                return otherException.Message;
            }
        }

    }
    enum ThemeStyle
    {
        White,
        Black,
        Own
    }
    enum ElementType
    { 
       LanguageElement,
       SpecialElement
    }
    enum ColorType
    { 
       ForeColor,
       BackColor
    }
}
