namespace XmlParserProject
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Xml
    {
        private Element element = new Element();
        private string toBeParsed;

        public Xml(string xml)
        {
            this.toBeParsed = xml;
        }

        public void Parse()
        {
            Match match = Regex.Match(this.toBeParsed, PatternForElement);

            if (match.Success)
            {
                string element = match.Groups[2].Value;

                Match end = Regex.Match(this.toBeParsed, string.Format(PatternForEndOfElement, element));

                if (end.Success)
                {
                    this.element.Name = match.Groups[1].Value;

                    ParseAttributes(match);

                    int startingIndex = this.toBeParsed.IndexOf(this.element.Name) + this.element.Name.Length;

                    string nextXmlToBeParsed = this.toBeParsed.Substring(startingIndex, this.toBeParsed.Length - end.Value.Length - startingIndex);

                    Element subElement = new Element();

                    subElement.Parse(nextXmlToBeParsed);

                    this.element.Elements.Add(subElement);
                }
            }
        }

        private void ParseAttributes(Match element)
        {
            Regex regexForAttributes = new Regex(RegexStrings.PatternForAttributes);
            MatchCollection attributes = regexForAttributes.Matches(element.Groups[3].Value);

            if (attributes.Count > 0)
            {
                foreach (Match attribute in attributes)
                {
                    this.element
                        .Attributes
                        .Add(new Attribute(attribute.Groups[1].Value,
                                            attribute.Groups[2].Value));

                }
            }
        }

        public Element Search(string elementName)
                => this.element.Search(elementName);

        public int NestedElementsCount()
                => this.element.ElementsCount;

        public void AddAttribute(string name, string value,Element toWhich)
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
