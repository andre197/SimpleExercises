using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XmlParserProject
{
    public class Element
    {
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; } = new List<Attribute>();

        public List<Element> Elements { get; set; } = new List<Element>();
    }
}
