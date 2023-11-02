using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Данный класс применяется для вычисления яркости темы
    /// </summary>
    internal class BrightnessTool
    {
        /// <summary>
        /// Используется для вычисления суммарной яркости всех пиксехей. Принимает область отображения темы на форму- richtextbox
        /// </summary>
        /// <param name="themeViewer"></param>
        /// <returns></returns>
        public static double CalculateAverageLightness(RichTextBox themeViewer)
        {
            double lum = 0;
            var bm = GetImage(themeViewer);
            var tmpBmp = new Bitmap(bm);
            var width = bm.Width;
            var height = bm.Height;
            var bppModifier = bm.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4;
            var srcData = tmpBmp.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
            var stride = srcData.Stride;
            var scan0 = srcData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int idx = (y * stride) + x * bppModifier;
                        lum += (0.299 * p[idx + 2] + 0.587 * p[idx + 1] + 0.114 * p[idx]);
                    }
                }
            }

            tmpBmp.UnlockBits(srcData);
            tmpBmp.Dispose();
            var avgLum = lum / (width * height);

            return Math.Round(avgLum / 255.0, 5);
        }
        
        /// <summary>
        /// Делает скриншот части формы, где находится область отображения темы
        /// </summary>
        /// <param name="themeViewer"></param>
        /// <returns></returns>
        private static Bitmap GetImage(RichTextBox themeViewer)
        {
            var location = themeViewer.PointToScreen(Point.Empty);
            Rectangle rect = new Rectangle(0, 0, 725, 730);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(location.X, location.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            return bmp;
        }
    }
}
