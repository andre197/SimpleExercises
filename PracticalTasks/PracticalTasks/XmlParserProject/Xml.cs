namespace XmlParserProject
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Xml
    {
        private Element rootElement = new Element();
        private string toBeParsed;
        private string XmlStart;

        public Xml(string xml)
        {
            this.toBeParsed = xml;
        }

        public void Parse()
        {
            Match isValid = Regex.Match(this.toBeParsed, RegexStrings.PatternForValidXML);

            if (isValid.Success)
            {
                this.XmlStart = isValid.Groups[1].Value;

                this.rootElement.Parse(isValid.Groups[4].Value, this.rootElement);
            }
        }

        public Element Search(string elementName)
                => this.rootElement.Search(elementName);

        public void AddAttribute(string name, string value, Element toWhich)
                => toWhich.AddAttribute(new Attribute(name, value));

        public void RemoveAttribute(string name, string value, Element fromWhich)
                => fromWhich.RemoveAttribute(new Attribute(name, value));

        public void AddElement(Element elementToBeAdded, Element onWhich)
                => onWhich.AddElement(elementToBeAdded);

        public void RemoveElement(Element elementToBeRemoved, Element fromWhich)
                => fromWhich.RemoveElement(elementToBeRemoved);

        public override string ToString()
                => this.toBeParsed;

    }
}
