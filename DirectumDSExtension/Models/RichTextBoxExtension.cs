using System.Windows.Forms;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Расщирение для RichTextBox
    /// </summary>
    internal static class RichTextBoxExtension
    {
        /// <summary>
        /// Раскрашивает подстроку в RichTextBox, берет данные из ColorCode структуры
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="colorCode"></param>
        public static void AddColorCode(this RichTextBox richTextBox, ColorCode colorCode)
        {
            richTextBox.Clear();
            richTextBox.AppendText(colorCode.CodeLine);

            foreach (var selected in colorCode.SelectedText)
            {
                richTextBox.SelectionStart = (int) selected.Key;
                richTextBox.SelectionLength =(int) selected.Value;
                richTextBox.SelectionBackColor = colorCode.BackColor;
                richTextBox.SelectionColor = colorCode.ForeColor;
            }
        }
    }
}
