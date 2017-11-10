namespace PracticalTasks
{
    using System;
    using System.Reflection;
    using XmlParserProject;

    public class Program
    {
        private static Xml xml;

        public static void Main()
        {
            string xmlText = Console.ReadLine();

            xml = new Xml(xmlText);

            xml.Parse();

            while (true)
            {
                string method = Console.ReadLine();

                if (method == "end")
                {
                    break;
                }

                if (method == "search")
                {
                    Search();
                }
                else if (method == "nested elements count")
                {
                    NestedElementsCount();
                }
                else if (method == "add attribute")
                {
                    AddAttribute();
                }
                else if (method == "remove attribute")
                {
                    RemoveAttribute();
                }
                else if (method == "add element")
                {
                    AddElement();
                }
                else if (method == "remove element")
                {
                    RemoveElement();
                }

            }
        }

        private static Element Search()
        {
            string elementName = Console.ReadLine();

            Element element = xml.Search(elementName);

            Console.WriteLine($"{element.Name} has element:{Environment.NewLine}{string.Join(" ", element.Elements)}{Environment.NewLine}with attributes:{Environment.NewLine}{string.Join(" ", element.Attributes)}{Environment.NewLine}");

            return element;
        }

        private static int NestedElementsCount()
        {
            Element element = Search();

            return element.ElementsCount;
        }

        private static void AddAttribute()
        {
            string name = Console.ReadLine();
            string value = Console.ReadLine();

            Element element = Search();

            xml.AddAttribute(name, value, element);
        }

        private static void RemoveAttribute()
        {
            string name = Console.ReadLine();
            string value = Console.ReadLine();

            Element element = Search();

            xml.RemoveAttribute(name, value, element);
        }

        private static void AddElement()
        {
            Element toBeAdded = new Element()
            {
                Name = Console.ReadLine()
            };
            Element onWhich = Search();

            xml.AddElement(toBeAdded, onWhich);
        }

        private static void RemoveElement()
        {
            Element toBeRemoved = Search();
            Element fromWhich = Search();

            xml.AddElement(toBeRemoved, fromWhich);
        }
    }
}
