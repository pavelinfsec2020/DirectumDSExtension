using System.Collections.Generic;
using System.Drawing;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Данная структура содержит инфофрмацию о цвете примера строки конкретной сущности кода, 
    /// Используется в ColorCodeGenerator
    /// </summary>
    internal struct ColorCode
    {
        private readonly string _objectName;
        private readonly string _codeLine;
        private readonly Dictionary<uint, uint> _selectedText;
        private Color? _backColor;
        private Color _foreColor;
        public ColorCode(string objectName, string codeLine, Dictionary<uint, uint> selectedText) 
                            
        {
            _objectName = objectName;
            _codeLine = codeLine;
            _selectedText = selectedText;
            _backColor = Color.White;
            _foreColor = Color.Black;
            int a = 3;
        }
        public string ObjectName { get { return _objectName; } }  
        public string CodeLine { get { return _codeLine;} }
        public Dictionary<uint, uint> SelectedText { get {  return _selectedText;} }
        public Color BackColor
        { 
            get { return _backColor.Value; } set { _backColor = value; }
        }
        public Color ForeColor
        {
            get { return _foreColor; } set { _foreColor = value; }
        }

    }
}
