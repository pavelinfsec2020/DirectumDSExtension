using System.Drawing;
using System.Xml.Linq;

namespace DirectumDSExtension.Models
{
   /// <summary>
   /// Класс, определяющий цвет сущности, относящейся к языку программирования
   /// </summary>
    internal class LanguageLightColor:HighlightingColorBase
    {
        private readonly string _languageName;
        public LanguageLightColor(string name, bool bold, bool italic, Color foreColor, Color? backColor, string languageName) 
                            :base(name, bold,  italic,  foreColor,  backColor)
        {
            _languageName = languageName;
        }
        public string LanguageName
        {
            get { return _languageName; }
        }
        public override XElement GenerateHighlightingBody()
        {
            var langugeXmlBody = base.GenerateHighlightingBody();
            langugeXmlBody.AddFirst(new XElement(Tag.LANGUAGE_TAG, _languageName));

            return langugeXmlBody; 
        } 
    }
}
