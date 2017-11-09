namespace XmlParserProject
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Xml
    {
        private const string PatternForElement = @"(\<(\w+){1}(.*?)\>)?";
        private const string PatternForEndOfElement = @"\<\/{0}\>";
        private const string PatternForAttributes = @"\s{1}(\w+)\={1}(\""\w+\"")";

        private Element element = new Element();
        private string toBeParsed;

        public Xml(string xml)
        {
            this.toBeParsed = xml;
        }

        public void Parse()
        {
            Regex regexToFindElementStart = new Regex(PatternForElement);
            Match firstElement = regexToFindElementStart.Match(this.toBeParsed);

            if (firstElement.Success)
            {
                ParseElements(firstElement);
            }

            MatchCollection matches = regexToFindElementStart.Matches(this.toBeParsed);

            if (matches.Count > 0)
            {
                foreach (Match match in matches.Skip(1))
                {
                    string elementName = match.Groups[2].Value;

                    Regex regextForEnd = new Regex(string.Format(PatternForEndOfElement, elementName));
                    Match end = regextForEnd.Match(this.toBeParsed);

                    if (end.Success)
                    {
                        ParseElements(match);
                    }
                }
            }

        }

        private void ParseElements(Match firstElement)
        {
            string elementName = firstElement.Groups[2].Value;

            Regex regextForEnd = new Regex(string.Format(PatternForEndOfElement, elementName));
            Match end = regextForEnd.Match(this.toBeParsed);

            if (end.Success)
            {
                if (this.element.Name == null)
                {
                    this.element.Name = firstElement.Groups[2].Value;
                    ParseAttributes(firstElement);
                }
                else
                {
                    this.element.Elements.Add(new Element() { Name = firstElement.Groups[2].Value });
                    ParseAttributes(firstElement);
                }
            }
        }

        private void ParseAttributes(Match firstElement)
        {
            Regex regexForAttributes = new Regex(PatternForAttributes);
            MatchCollection attributes = regexForAttributes.Matches(firstElement.Groups[3].Value);

            if (attributes.Count > 0)
            {
                foreach (Match attribute in attributes)
                {
                    if (this.element.Name == null)
                    {
                        this.element
                        .Attributes
                        .Add(new Attribute(attribute.Groups[1].Value,
                                            attribute.Groups[2].Value));
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.element.Name);

            Stack<Element> elements = new Stack<Element>(this.element.Elements);

            while (elements.Count > 0)
            {
                Element current = elements.Pop();
                sb.AppendLine(current.Name);

                foreach (var el in current.Elements)
                {
                    elements.Push(el);
                }
            }

            return sb.ToString();
        }

    }
}
