using System.Collections.Generic;

namespace DirectumDSExtension.Models
{
    /// <summary>
    /// Класс, генерирующий примеры кода каждой сущности
    /// </summary>
    internal static class ColorCodeGenerator
    {
       /// <summary>
       /// Инициализирует массив структур, содержащих полы:Имя сущности, сам код, словарь содержит ключ-начало подстроки и
       /// значение-длина подстроки, которую необходимо раскрасить нужным цветом
       /// </summary>
       /// <returns></returns>
        public static ColorCode[] GetColorCodes()
        {
            var colorCodesCollection = new ColorCode[]
            {
                new ColorCode("BrokenEntity", " index.aspx?a=1&b=2", new Dictionary<uint, uint>(){ {15,2} }),
                new ColorCode("Entity", " index.aspx?a=1&amp;b=2", new Dictionary<uint, uint>(){ {15,4} }),
                new ColorCode("AttributeValue", " <tag attribute=\"value\" />", new Dictionary<uint, uint>(){ {16,7} }),
                new ColorCode("AttributeName", " <tag attribute=\"value\" />", new Dictionary<uint, uint>(){ {6,9} }),
                new ColorCode("XmlTag", " <tag attribute=\"value\" />", new Dictionary<uint, uint>(){ {2,3} }),
                new ColorCode("XmlDeclaration", " <?xml version=\"1.0\"?>", new Dictionary<uint, uint>(){ {1,23} }),
                new ColorCode("DocType", " <!DOCTYPE rootElement>", new Dictionary<uint, uint>(){ {1,22} }),
                new ColorCode("CData", " <![CDATA[data]]>", new Dictionary<uint, uint>(){ {1,16} }),
                new ColorCode("Comment", " <!-- comment -->", new Dictionary<uint, uint>(){ {1,16} }),
                new ColorCode("GetSetAddRemove", " int Prop { get; set; }", new Dictionary<uint, uint>(){ {12,3}, { 17,3} }),
                new ColorCode("NamespaceKeywords", " namespace A.B { using System; }", new Dictionary<uint, uint>(){ {1,9}, {17,5 } }),
                new ColorCode("Visibility", " public override void;", new Dictionary<uint, uint>(){ {1,6} }),
                new ColorCode("Modifiers", " static readonly int a;", new Dictionary<uint, uint>(){ {1,6}, {8, 8} }),
                new ColorCode("ParameterModifiers", " (ref int a, params int[] b)", new Dictionary<uint, uint>(){ {2,3}, {13,6} }),
                new ColorCode("UnsafeKeywords", " unsafe { fixed (..) {} }", new Dictionary<uint, uint>(){ {1,6}, {10,5} }),
                new ColorCode("ExceptionKeywords", " try {} catch {} finally {}", new Dictionary<uint, uint>(){ {1,3}, {8,5}, {17,7} }),
                new ColorCode("ContextKeywords", " var a = from x in y select z;", new Dictionary<uint, uint>(){ {1,3}, {9,4}, {21,6} }),
                new ColorCode("GotoKeywords", " continue; return; break;", new Dictionary<uint, uint>(){ {1,8}, {11,6}, {19,5} }),
                new ColorCode("Keywords", " if (a) {} else {}", new Dictionary<uint, uint>(){ {1,2}, {11,4} }),
                new ColorCode("NumberLiteral", " 3.1415f", new Dictionary<uint, uint>(){ {1,6} }),
                new ColorCode("Keywords", " if (a) {} else {}", new Dictionary<uint, uint>(){ {1,2}, {11,4} }),
                new ColorCode("MethodCall", " _obj.Age.ToString()", new Dictionary<uint, uint>(){ {10,8} }),
                new ColorCode("ReferenceTypes", " object o;", new Dictionary<uint, uint>(){ {1,6} }),
                new ColorCode("ValueTypes", " bool b = true;", new Dictionary<uint, uint>(){ {1,4} }),
                new ColorCode("Punctuation", " a(b.c);", new Dictionary<uint, uint>(){ {2,1}, {4,1} , {6,2} }),
                new ColorCode("Line numbers", " 1 | int firstLine; \n 2 | string secondLine;", new Dictionary<uint, uint>(){ {1,1}, {22,1} }),
                new ColorCode("Preprocessor", " #region Title", new Dictionary<uint, uint>(){ {1,13} }),
                new ColorCode("Char", " char a = 'a';", new Dictionary<uint, uint>(){ {10,3} }),
                new ColorCode("String", " string text = \"DirectumRX\";", new Dictionary<uint, uint>(){ {15,13} }),
                new ColorCode("Bracket highlight", " (string) example", new Dictionary<uint, uint>(){ {1,1}, {8,1} }),
                new ColorCode("Default text/background", " Normal text", new Dictionary<uint, uint>(){ {0,12} }),
                new ColorCode("Selected text", " Selected text", new Dictionary<uint, uint>(){ {1,13} }),
                new ColorCode("NullOrValueKeywords", " if (value == null)", new Dictionary<uint, uint>(){ {5,5}, {14,4} }),
                new ColorCode("TrueFalse", " b = false; a = true;", new Dictionary<uint, uint>(){ {5,5}, {16, 4} })
            };

            return colorCodesCollection;
        }
    }
}
