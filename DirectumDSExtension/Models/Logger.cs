using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;


namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Фиксирует все события и ошибки в работе программы
    /// </summary>
    internal  class Logger
    {
        private readonly string _logFileName;
        private const string LOG_FILE_NAME = "EventsMessages.log";
        public Logger()
        {
           var currentDir =  Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location
                );
           _logFileName = Path.Combine(currentDir, LOG_FILE_NAME);
        }
        
        /// <summary>
        /// Асинхронно добавляет запись в лог событий
        /// </summary>
        /// <param name="eventText"></param>
        public async void AddAsync(string eventText)
        {
            try
            {
                if (!File.Exists(_logFileName))
                {
                    using (var stream = File.Create(_logFileName))
                    {
                        stream.Close();
                    }
                }
                
                using (var sw = new StreamWriter(_logFileName, true))
                {
                    var text = String.Format($"{DateTime.Now}  :  {eventText}");
                    await Task.Run(() => sw.WriteLine(text)); 
                    sw.Close();
                }
            }
            catch (Exception e)
            { 
            
            }       
        }
    }
}
