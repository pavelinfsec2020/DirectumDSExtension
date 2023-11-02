using DirectumDSExtension.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

 /// <summary>
 /// Базовый класс опеределяет сущность, 
 /// которая представляет из себя имя, шрифт, цвет текста и фона,
 /// который может отстутствовать
 /// </summary>
internal class HighlightingColorBase
{
    private string _name;
    private bool _bold;
    private bool _italic;
    private Color _foreColor;
    private Color? _backColor;
    private readonly bool _hasBackColor;
    private XElement _xmlColorBody;

    public HighlightingColorBase(string name, bool bold, bool italic, 
                                 Color foreColor, Color? backColor)
    {
        _name = name;
        _bold = bold;
        _italic = italic;
        _foreColor = foreColor;
        _backColor = backColor;
        _hasBackColor = backColor.HasValue ? true : false;
    }
    public string Name
    {
        get { return _name; }
    }
    public bool HasBackColor
    {
        get { return _hasBackColor; }
    }
    public bool IsBold
    { get { return _bold; } 
      set { _bold = value; }
    }
    public bool IsItalic
    {
        get { return _italic; }
        set { _italic = value; }
    }
    public Color ForeColor
    {
        get { return _foreColor; }
        set { _foreColor = value; }
    }
    public Color? BackColor
    {
        get { return _backColor; }
        set { _backColor = HasBackColor ? value : null; }
    }
    
    /// <summary>
    /// Создает тело настроек сущности в xml
    /// </summary>
    /// <returns></returns>
    public virtual XElement GenerateHighlightingBody()
    {
        _xmlColorBody.RemoveAll();
   
        _xmlColorBody = new XElement(
                        Tag.HEAD_TAG,
                        new XElement(Tag.HEAD_TAG, _name),
                        new XElement(Tag.BOLD_TAG, _bold),
                        new XElement(Tag.ITALIC_TAG, _italic),
                        new XElement(Tag.FOREGROUND_TAG, GetXmlFromColor(_foreColor)));
        
        if (HasBackColor)
        _xmlColorBody.Add(new XElement(Tag.BACKGROUND_TAG, GetXmlFromColor(_backColor.Value)));

        return _xmlColorBody;
    }
    /// <summary>
    /// Преобразует цвет в Xml
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    private XElement[] GetXmlFromColor(Color color)
    {
        return new XElement[]
        {
           new XElement("A", color.A),
           new XElement("R", color.R),
           new XElement("G", color.G),
           new XElement("B", color.B)
        };
    }
    
    /// <summary>
    /// Вычисляет изменения и возвращает словарь изменений для каждого измененного свойства
    /// для отображения в поле "Сохраненные изменения " на форме
    /// </summary>
    /// <param name="olderElement"></param>
    /// <returns></returns>
    public Dictionary<string, Dictionary<int, Color?>> GetPropertieDifferents(HighlightingColorBase olderElement)
    {
        var result = new Dictionary<string, Dictionary<int, Color?>>();
        result.Add(Helper.GetHeadChangedName(this.Name), 
                   new Dictionary<int, Color?>() { { 0, Color.White } });

        if (this.ForeColor != olderElement.ForeColor)
        {
            var oldValue = olderElement.ForeColor;
            var newValue = this.ForeColor;
            result.Add(String.Format("Цвет текста изменен с {0} -> {1}", oldValue.Name, newValue.Name),
                       new Dictionary<int, Color?>() { { 22, oldValue }, { 26 + oldValue.Name.Length, newValue } });
        }

        if (this.HasBackColor && this.BackColor != olderElement.BackColor)
        {
            var oldValue = olderElement.BackColor.Value;
            var newValue = this.BackColor.Value;
            result.Add(String.Format("Цвет фона изменен с {0} -> {1}", oldValue.Name, newValue.Name),
                       new Dictionary<int, Color?>() { { 20, oldValue }, { 24 + oldValue.Name.Length, newValue } });
        }

        if (this.IsBold != olderElement.IsBold)
        {
            var font = this.IsBold ? "Добавлен" : "Убран";
            result.Add(String.Format("{0} полужирный шрифт", font), 
                       new Dictionary<int, Color?>() { { 0, null } });
        }

        if (this.IsItalic != olderElement.IsItalic)
        {
            var font = this.IsItalic ? "Добавлен" : "Убран";
            result.Add(String.Format("{0} курсивный шрифт", font), 
                       new Dictionary<int, Color?>() { { 0, null } });
        }

      //  result.Add(" ________________________________", 
        //           new Dictionary<int, Color?>() { { 1, Color.Blue } });

        return result;
    }
}

