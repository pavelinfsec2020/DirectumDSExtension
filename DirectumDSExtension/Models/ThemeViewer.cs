using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Класс, отображающий в главном окне отображение темы
    /// </summary>
    internal class ThemeViewer
    {
        #region Индексы определенных свойств в коллекциях цветов
        private const ushort BRACKETS_INDEX = 0;
        private const ushort DEFAULT_TEXT_INDEX = 1;
        private const ushort SELECTED_TEXT_INDEX = 2;
        private const ushort LINE_NUMBERS_INDEX = 3;
        private const ushort GET_SET_INDEX = 9;
        private const ushort NAMESPACE_INDEX = 10;
        private const ushort VISIBILITY_INDEX = 11;
        private const ushort MODIFY_INDEX = 12;
        private const ushort VALUE_TYPE_INDEX = 22;
        private const ushort TRUE_FALSE_INDEX = 30;
        private const ushort IF_ELSE_INDEX = 18;
        private const ushort GOTO_KEYWORDS_INDEX = 17;
        private const ushort NUMBER_LITERAL_INDEX = 19;
        private const ushort METHOD_CALL_INDEX = 20;
        private const ushort REFERENCE_TYPE_INDEX = 21;
        private const ushort CONTEXT_KEYWORDS_INDEX = 16;
        private const ushort PUNCTUATION_INDEX = 23;
        private const ushort PARAMETERS_INDEX = 13;
        private const ushort NULL_VALUE_INDEX = 29;
        private const ushort COMMENT_INDEX = 28;
        private const ushort EXCEPTION_KEYWORDS_INDEX = 15;
        private const ushort STRING_VALUE_INDEX = 27;
        private const ushort CHAR_VALUE_INDEX = 26;
        private const ushort PREPROCESSOR_VALUE_INDEX = 25;
        #endregion
        private readonly char[] _punctuations;
        private readonly RichTextBox _themeViewWindow;
        private readonly List<LanguageLightColor> _languageColors;
        private readonly List<SpecialSettingsLightColor> _specialSetsColors;
        private readonly string[] _codeLines;

        public ThemeViewer(RichTextBox themeViewWindow, List<SpecialSettingsLightColor> specialSetsColors, List<LanguageLightColor> languageLightColor)
        {
            _themeViewWindow = themeViewWindow;
            _specialSetsColors = specialSetsColors;
            _languageColors = languageLightColor;
            _codeLines = _themeViewWindow.Lines;
            _punctuations = new char[] { ';', ',', '.', ':', '<', '>', '(', ')', '|', '&', '{', '}', '?', '!', '[', ']' };
        }
        /// <summary>
        /// Вспомогательный метод, устанавливает цвет и шрифт подстроке
        /// </summary>
        /// <param name="startIndx"></param>
        /// <param name="length"></param>
        /// <param name="foreColor"></param>
        /// <param name="backColor"></param>
        /// <param name="font"></param>
        private void SetColorToSubStr(int startIndx, int length, Color foreColor, Color? backColor, Font font)
        {
            _themeViewWindow.SelectionStart = startIndx;
            _themeViewWindow.SelectionLength = length;
            _themeViewWindow.SelectionColor = foreColor;

            if (backColor.HasValue)
                _themeViewWindow.SelectionBackColor = backColor.Value;

            if (font != null)
                _themeViewWindow.SelectionFont = font;
        }
        /// <summary>
        /// Вспомогательный метод, создает шрифт с заданными параметрами
        /// </summary>
        /// <param name="isItalic"></param>
        /// <param name="isBold"></param>
        /// <returns></returns>
        private Font CreateFont(bool isItalic, bool isBold)
        {
            if (isItalic && isBold)
                return new Font(_themeViewWindow.Font, FontStyle.Bold | FontStyle.Italic);
            
            if (!isItalic && isBold)
                return new Font(_themeViewWindow.Font, FontStyle.Bold);

            if (isItalic && !isBold)
                return new Font(_themeViewWindow.Font, FontStyle.Italic);
            
            else
                return new Font(_themeViewWindow.Font, FontStyle.Regular);
        }
        
        /// <summary>
        /// Определяет позицию в строке по номеру строки и отступу от ее начала слева
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="lastLineStart"></param>
        /// <returns></returns>
        private int GetStartIndex(int lineNumber, int lastLineStart)
        {
            var startIndex = 0;

            for (int i = 0; i < lineNumber-1; i++)
            {
                startIndex += _codeLines[i].Length + 1;
            }

            return startIndex + lastLineStart;
        }
        
        /// <summary>
        /// Главный метод, Для каждого свойства, разделенных регионами, задает их цвета
        /// </summary>
        public void ColorizeTheme()
        {
            if (!(_specialSetsColors?.Count > 0 && _languageColors?.Count > 0))
                return;
            
            var lines = _themeViewWindow.Lines;
            #region Цвет текста и фона по-умолчанию
            _themeViewWindow.BackColor = _specialSetsColors[DEFAULT_TEXT_INDEX].BackColor.Value;
            _themeViewWindow.ForeColor = _specialSetsColors[DEFAULT_TEXT_INDEX].ForeColor;
            #endregion
            #region Номера строк
            var startIndex = 0;
            
            for (int i = 0; i < lines.Length; i++)
            {
                SetColorToSubStr(startIndex, 5, _specialSetsColors[LINE_NUMBERS_INDEX].ForeColor, null, null);
                startIndex += lines[i].Length + 1;
            }
            #endregion
            #region Namespace 
            startIndex = 6;
            var namspace = _languageColors[NAMESPACE_INDEX];
            var font = CreateFont(namspace.IsItalic, namspace.IsBold);

            for (int i = 0; i < 6; i++)
            {
                if (i == 4)
                    continue;

                if (i == 5)
                {
                    SetColorToSubStr(startIndex + 6, 9, namspace.ForeColor, null, font);
                    break;
                }

                SetColorToSubStr(startIndex, 5, namspace.ForeColor, null, font);
                startIndex += lines[i].Length + 1;
            }
            #endregion
            #region Выделенный текст
            var selectedColor = _specialSetsColors[SELECTED_TEXT_INDEX];
            startIndex = GetStartIndex(10,0);
            SetColorToSubStr(startIndex, 26, selectedColor.ForeColor, selectedColor.BackColor.Value,null);
            #endregion
            #region Круглые скобки
            selectedColor = _specialSetsColors[BRACKETS_INDEX];
            startIndex = GetStartIndex(11, 46);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            startIndex = GetStartIndex(11, 103);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            startIndex = GetStartIndex(13, 16);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            startIndex = GetStartIndex(13, 49);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            startIndex = GetStartIndex(14, 33);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            startIndex = GetStartIndex(15, 69);
            SetColorToSubStr(startIndex, 1, selectedColor.ForeColor, null, null);
            #endregion
            #region Get;Set;
            var getSetColor = _languageColors[GET_SET_INDEX];
            font = CreateFont(getSetColor.IsItalic, getSetColor.IsBold);
            startIndex = GetStartIndex(21, 13);
            SetColorToSubStr(startIndex, 3, getSetColor.ForeColor, null, font);
            startIndex = GetStartIndex(21, 40);
            SetColorToSubStr(startIndex, 3, getSetColor.ForeColor, null, font);
            #endregion
            #region Модификаторы доступа
            var visibilityColor = _languageColors[VISIBILITY_INDEX];
            font = CreateFont(visibilityColor.IsItalic, visibilityColor.IsBold);
            startIndex = GetStartIndex(11, 7);
            SetColorToSubStr(startIndex, 6, visibilityColor.ForeColor, null, font);
            startIndex = GetStartIndex(19, 8);
            SetColorToSubStr(startIndex, 6, visibilityColor.ForeColor, null, font);
            startIndex = GetStartIndex(21, 32);
            SetColorToSubStr(startIndex, 7, visibilityColor.ForeColor, null, font);
            startIndex = GetStartIndex(23, 8);
            SetColorToSubStr(startIndex, 9, visibilityColor.ForeColor, null, font);
            startIndex = GetStartIndex(25, 8);
            SetColorToSubStr(startIndex, 8, visibilityColor.ForeColor, null, font);
            #endregion
            #region Модификаторы static, readonly, virtual, override
            var modifyColor = _languageColors[MODIFY_INDEX];
            font = CreateFont(modifyColor.IsItalic, modifyColor.IsBold);
            startIndex = GetStartIndex(23, 18);
            SetColorToSubStr(startIndex, 6, modifyColor.ForeColor, null, font);
            startIndex = GetStartIndex(23, 25);
            SetColorToSubStr(startIndex, 8, modifyColor.ForeColor, null, font);
            startIndex = GetStartIndex(11, 14);
            SetColorToSubStr(startIndex, 8, modifyColor.ForeColor, null, font);
            #endregion
            #region Значимые типы
            var valueType = _languageColors[VALUE_TYPE_INDEX];
            font = CreateFont(valueType.IsItalic, valueType.IsBold);
            startIndex = GetStartIndex(19, 15);
            SetColorToSubStr(startIndex, 3, valueType.ForeColor, null, font);
            startIndex = GetStartIndex(23, 34);
            SetColorToSubStr(startIndex, 4, valueType.ForeColor, null, font);
            startIndex = GetStartIndex(25, 40);
            SetColorToSubStr(startIndex, 3, valueType.ForeColor, null, font);
            startIndex = GetStartIndex(34, 20);
            SetColorToSubStr(startIndex, 4, valueType.ForeColor, null, font);
            #endregion
            #region Значения типа bool
            var trueFalse = _languageColors[TRUE_FALSE_INDEX];
            font = CreateFont(trueFalse.IsItalic, trueFalse.IsBold);
            startIndex = GetStartIndex(23, 51);
            SetColorToSubStr(startIndex, 4, trueFalse.ForeColor, null, font);
            #endregion
            #region if else for foreach while do in
            var ifElse = _languageColors[IF_ELSE_INDEX];
            font = CreateFont(ifElse.IsItalic, ifElse.IsBold);
            startIndex = GetStartIndex(13, 13);
            SetColorToSubStr(startIndex, 2, ifElse.ForeColor, null, font);
            startIndex = GetStartIndex(16, 13);
            SetColorToSubStr(startIndex, 4, ifElse.ForeColor, null, font);
            startIndex = GetStartIndex(27, 16);
            SetColorToSubStr(startIndex, 2, ifElse.ForeColor, null, font);
            startIndex = GetStartIndex(33, 47);
            SetColorToSubStr(startIndex, 2, ifElse.ForeColor, null, font);
            #endregion
            #region Goto keywords
            var goToWords = _languageColors[GOTO_KEYWORDS_INDEX];
            font = CreateFont(goToWords.IsItalic, goToWords.IsBold);
            startIndex = GetStartIndex(14, 15);
            SetColorToSubStr(startIndex, 6, goToWords.ForeColor, null, font);
            startIndex = GetStartIndex(16, 19);
            SetColorToSubStr(startIndex, 6, goToWords.ForeColor, null, font);
            startIndex = GetStartIndex(21, 18);
            SetColorToSubStr(startIndex, 6, goToWords.ForeColor, null, font);
            startIndex = GetStartIndex(28, 19);
            SetColorToSubStr(startIndex, 6, goToWords.ForeColor, null, font);
            #endregion
            #region Числовые значения
            var numberLiteral = _languageColors[NUMBER_LITERAL_INDEX];
            font = CreateFont(numberLiteral.IsItalic, numberLiteral.IsBold);
            startIndex = GetStartIndex(21, 25);
            SetColorToSubStr(startIndex, 4, numberLiteral.ForeColor, null, font);
            #endregion
            #region Вызов метода
            var methodCall = _languageColors[METHOD_CALL_INDEX];
            font = CreateFont(methodCall.IsItalic, methodCall.IsBold);
            startIndex = GetStartIndex(11, 37);
            SetColorToSubStr(startIndex, 9, methodCall.ForeColor, null, font);
            startIndex = GetStartIndex(14, 28);
            SetColorToSubStr(startIndex, 5, methodCall.ForeColor, null, font);
            startIndex = GetStartIndex(25, 22);
            SetColorToSubStr(startIndex, 13, methodCall.ForeColor, null, font);
            startIndex = GetStartIndex(34, 43);
            SetColorToSubStr(startIndex, 12, methodCall.ForeColor, null, font);
            #endregion
            #region Ссылочные типы
            var refType = _languageColors[REFERENCE_TYPE_INDEX];
            font = CreateFont(refType.IsItalic, refType.IsBold);
            startIndex = GetStartIndex(8, 15);
            SetColorToSubStr(startIndex, 5, refType.ForeColor, null, font);
            startIndex = GetStartIndex(25, 17);
            SetColorToSubStr(startIndex, 4, refType.ForeColor, null, font);
            startIndex = GetStartIndex(25, 58);
            SetColorToSubStr(startIndex, 6, refType.ForeColor, null, font);
            #endregion
            #region ContextKeywords
            var contextWords = _languageColors[CONTEXT_KEYWORDS_INDEX];
            font = CreateFont(contextWords.IsItalic, contextWords.IsBold);
            startIndex = GetStartIndex(8, 7);
            SetColorToSubStr(startIndex, 7, contextWords.ForeColor, null, font);
            startIndex = GetStartIndex(33, 20);
            SetColorToSubStr(startIndex, 3, contextWords.ForeColor, null, font);
            startIndex = GetStartIndex(33, 40);
            SetColorToSubStr(startIndex, 4, contextWords.ForeColor, null, font);
            startIndex = GetStartIndex(33, 56);
            SetColorToSubStr(startIndex, 6, contextWords.ForeColor, null, font);
            #endregion
            #region Parameters
            var parameters = _languageColors[PARAMETERS_INDEX];
            font = CreateFont(parameters.IsItalic, parameters.IsBold);
            startIndex = GetStartIndex(25, 36);
            SetColorToSubStr(startIndex, 3, parameters.ForeColor, null, font);
            startIndex = GetStartIndex(25, 51);
            SetColorToSubStr(startIndex, 6, parameters.ForeColor, null, font);
            #endregion
            #region Значение null
            var nullValue = _languageColors[NULL_VALUE_INDEX];
            font = CreateFont(nullValue.IsItalic, nullValue.IsBold);
            startIndex = GetStartIndex(27, 29);
            SetColorToSubStr(startIndex, 4, nullValue.ForeColor, null, font);
            #endregion
            #region  Комментарий
            var comment = _languageColors[COMMENT_INDEX];
            font = CreateFont(comment.IsItalic, comment.IsBold);
            startIndex = GetStartIndex(38, 19);
            SetColorToSubStr(startIndex, 22, comment.ForeColor, null, font);
            #endregion
            #region  Обработка исключений try catch finally
            var exceptionWords = _languageColors[EXCEPTION_KEYWORDS_INDEX];
            font = CreateFont(exceptionWords.IsItalic, exceptionWords.IsBold);
            startIndex = GetStartIndex(31, 16);
            SetColorToSubStr(startIndex, 3, exceptionWords.ForeColor, null, font);
            startIndex = GetStartIndex(37, 15);
            SetColorToSubStr(startIndex, 5, exceptionWords.ForeColor, null, font);
            #endregion
            #region  Значение строки
            var stringValue = _languageColors[STRING_VALUE_INDEX];
            font = CreateFont(stringValue.IsItalic, stringValue.IsBold);
            startIndex = GetStartIndex(34, 32);
            SetColorToSubStr(startIndex, 10, stringValue.ForeColor, null, font);
            #endregion
            #region  Значение символа
            var charValue = _languageColors[CHAR_VALUE_INDEX];
            font = CreateFont(charValue.IsItalic, charValue.IsBold);
            startIndex = GetStartIndex(35, 30);
            SetColorToSubStr(startIndex, 3, charValue.ForeColor, null, font);
            #endregion
            #region  Команды препроцессора
            var preprocessorCommand = _languageColors[PREPROCESSOR_VALUE_INDEX];
            font = CreateFont(preprocessorCommand.IsItalic, preprocessorCommand.IsBold);
            startIndex = GetStartIndex(30, 15);
            SetColorToSubStr(startIndex, 16, preprocessorCommand.ForeColor, null, font);
            startIndex = GetStartIndex(39, 15);
            SetColorToSubStr(startIndex, 10, preprocessorCommand.ForeColor, null, font);
            #endregion
            #region Punctuations
            var punctuatins = _languageColors[PUNCTUATION_INDEX];
            var text = _themeViewWindow.Text;

            for (int i = 0; i < text.Length; i++)
            {
                if (_punctuations.Contains(text[i]))
                {
                    startIndex = i;
                    SetColorToSubStr(startIndex, 1, punctuatins.ForeColor, null, null);
                }
            }
            #endregion
        }
    }
}
