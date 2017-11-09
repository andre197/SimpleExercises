namespace PracticalTasks
{
    using Generics;
    using Generics.ExtensionMethods;
    using System;
    using XmlParserProject;

    public class Program
    {
        public static void Main()
        {
            string xmlText = Console.ReadLine();

            Xml xml = new Xml(xmlText);

            xml.Parse();
        }
    }
}
