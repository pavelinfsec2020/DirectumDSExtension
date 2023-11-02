using System.Drawing;
using System.Xml.Linq;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Сущность специальных строек, наследуется от HighkightingColorBase,
    /// не имеет дополнительных методов, свойств
    /// </summary>
    internal class SpecialSettingsLightColor:HighlightingColorBase
    {
        public SpecialSettingsLightColor(string name, bool bold, bool italic, Color foreColor, Color? backColor) 
                                  : base(name, bold, italic, foreColor, backColor)
        { 
        
        }
        public override XElement GenerateHighlightingBody()
        {
            return base.GenerateHighlightingBody();
        }
    }
}
