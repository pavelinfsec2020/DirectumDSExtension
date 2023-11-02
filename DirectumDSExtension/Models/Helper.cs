using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Вспомогательный класс
    /// </summary>
    internal static class Helper
    {
        private static Graphics _graphics;
        private static Logger _logger;
        static  Helper()
        {
            _logger = new Logger();
        }
        /// <summary>
        /// Читает содержимое ярлыка и определяет путь до exe файла DDS
        /// </summary>
        /// <param name="linkName"></param>
        /// <param name="studioPath"></param>
        /// <returns></returns>
        public static bool TryGetLinkPathFromDesktop(string linkName, ref string studioPath)
        { 
           try
           {
 
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var files = Directory.GetFiles(desktopPath);
                var links = files.Where(f => f.EndsWith(".lnk") && f.Contains(linkName));

                if (!links.Any())
                    return false;

                using (var fstream = File.Open(links.FirstOrDefault(), FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(fstream))
                    {
                        fstream.Seek(0x14, SeekOrigin.Begin);
                        var flags = reader.ReadUInt32();
                       
                        if ((flags & 0x01) == 1)
                        {
                            fstream.Seek(0x4c, SeekOrigin.Begin);
                            var itemIdLength = reader.ReadUInt16();
                            fstream.Seek(itemIdLength, SeekOrigin.Current);
                        }
                        
                        var start = fstream.Position;
                        var length = reader.ReadUInt32();
                        fstream.Seek(0x0c, SeekOrigin.Current);
                        var offset = reader.ReadUInt32();
                        fstream.Seek(start + offset, SeekOrigin.Begin);
                        studioPath = new string(reader.ReadChars((int)(start + length - fstream.Position)));
                    }
                }
               
                return true;
           }
           catch (Exception e)
           {
                _logger.AddAsync(e.Message);
                return false;
           }
        }

       /// <summary>
       /// Вызывает диалогове окно, чтобы указать путь к dds, если не найден ярлык на рабочем столе
       /// </summary>
       /// <param name="studioPath"></param>
       /// <returns></returns>
        public static bool TryGetPathByDialog(ref string studioPath)
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.Title = "Не удалось найти ярлык Directum Development Studio. Укажите путь к DirectumLauncher.exe вручную";
                dialog.Filter = "Исполняемые файлы (*.exe) | *.exe";
                if (dialog.ShowDialog() == DialogResult.OK)
                   studioPath = dialog.FileName;
               
                return true;
            }
            catch (Exception e)
            {
                _logger.AddAsync(e.Message);
                return false;
            }
        }

        /// <summary>
        /// Дополняет нижним подчеркиванием имя свойства в заголовке сохраненных изменений
        /// </summary>
        /// <param name="propertieName"></param>
        /// <returns></returns>
        public static string GetHeadChangedName(string propertieName)
        {
            var formatName = String.Format("| {0} |", propertieName);
            var changeName = new StringBuilder(formatName);
            var value = GetWithOfName("__");
           
            while (GetWithOfName(changeName.ToString()) + value  < MainWindow._propertieChangesBox.Width)
            {
                changeName.Insert(0, "_");
                
                if (GetWithOfName(changeName.ToString()) + value < MainWindow._propertieChangesBox.Width)
                changeName.Append("_");
            }

            return changeName.ToString();
        }
        
        /// <summary>
        /// Вспомогательный метод, определяет длину строки в пикселях с определенным шрифтом
        /// </summary>
        /// <param name="propertieName"></param>
        /// <returns></returns>
        private static float GetWithOfName(string propertieName)
        {
            _graphics = MainWindow._mainForm.CreateGraphics();

            return _graphics.MeasureString(propertieName, MainWindow._propertieChangesBox.Font).Width;        
        }
    }
}
