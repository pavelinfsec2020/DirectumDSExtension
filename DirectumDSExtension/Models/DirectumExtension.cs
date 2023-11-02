using System;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Базовый класс, используемый генератором тем, в котором указаны и вычисляются пути к системной папке с темами и т д
    /// </summary>
    class DirectumExtension
    {
        private const string DDS_LINK_NAME = "Development studio";
        private const string CONFIG_FOLDER_PATH = @"\Directum Company\DirectumRX\Sungero Development Studio";
        private const string STUDIO_PROCESS_NAME = "DevelopmentStudio";
        private string _studioProcessName = String.Concat(STUDIO_PROCESS_NAME, ".exe");
        public DirectumExtension()
        {
             if (!Helper.TryGetLinkPathFromDesktop(DDS_LINK_NAME, ref _studioProcessName))
                Helper.TryGetPathByDialog(ref _studioProcessName); 
        }
       protected string StudioFileName
       {
            get 
            {         
                return _studioProcessName;
            }  
       }
       
       public string ConfigFolderPath
       {
            get 
            {
                var configFolderPath = String.Concat(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), CONFIG_FOLDER_PATH);

                return configFolderPath;
            }  
       }
       protected string StudioProcessName
       {
            get { return STUDIO_PROCESS_NAME;}
       }
    }
}
