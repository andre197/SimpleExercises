using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace XmlParserProject
{
    public class Element
    {
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; } = new List<Attribute>();

        public List<Element> Elements { get; set; } = new List<Element>();

        public int ElementsCount => this.Elements.Count;

        public void Parse(string xml, Element element)
        {
            MatchCollection matches = Regex.Matches(xml, RegexStrings.PatternForElements);

            if (matches.Count > 0)
            {
                foreach (Match match in matches.Where(m => m.Length > 0))
                {
                    if (element.Name == null)
                    {
                        element.Name = match.Groups[1].Value;
                    }

                    ParseAttributes(match);

                    int startingIndex = xml.IndexOf(match.Groups[1].Value) + match.Groups[1].Value.Length;
                    int endingIndex = xml.IndexOf(match.Groups[5].Value);

                    string nextXmlToBeParsed = string.Empty;

                    if (endingIndex - startingIndex > 0)
                    {
                        nextXmlToBeParsed = xml.Substring(startingIndex, endingIndex - startingIndex);

                        AddSubs(nextXmlToBeParsed, element);
                    }
                }
            }
        }

        private void AddSubs(string nextXmlToBeParsed, Element element)
        {
            MatchCollection matches = Regex.Matches(nextXmlToBeParsed, RegexStrings.PatternForElements);

            if (matches.Count > 0)
            {
                foreach (Match match in matches.Where(m => m.Length > 0))
                {
                    Element subElement = new Element();

                    subElement.Name = match.Groups[1].Value;

                    subElement.Parse(match.Groups[4].Value, this);

                    element.Elements.Add(subElement);
                }
            }
        }

        public void ParseAttributes(Match element)
        {
            Regex regexForAttributes = new Regex(RegexStrings.PatternForAttributes);
            MatchCollection attributes = regexForAttributes.Matches(element.Groups[3].Value);

            if (attributes.Count > 0)
            {
                foreach (Match attribute in attributes)
                {
                    this.Attributes
                        .Add(new Attribute(attribute.Groups[1].Value,
                                            attribute.Groups[2].Value));

                }
            }
        }

        public Element Search(string elementName)
        {
            string pattern = $@"\<{elementName}.*\>";

            Match match = Regex.Match(this.Name, pattern);

            if (match.Success)
            {
                return this;
            }

            Element element;

            foreach (var item in this.Elements)
            {
                element = item.Search(elementName);

                if (element != null)
                {
                    return element;
                }
            }

            return null;
        }

        public Attribute SearchAttribute(string key)
        {
            foreach (var item in this.Attributes)
            {
                if (item.Name == key)
                {
                    return item;
                }
            }

            return null;
        }

        public void AddAttribute(Attribute attribute)
            => this.Attributes.Add(attribute);

        public void RemoveAttribute(Attribute attribute)
            => this.Attributes.Remove(attribute);

        public void AddElement(Element element)
            => this.Elements.Add(element);

        public void RemoveElement(Element element)
            => this.Elements.Remove(element);
    }
}
