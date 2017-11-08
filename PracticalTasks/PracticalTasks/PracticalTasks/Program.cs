namespace PracticalTasks
{
    using System;
    using XmlParserProject;

    public class Program
    {
        public static void Main()
        {
            string xml = Console.ReadLine();

            Xml xmlParser = new Xml(xml);

            xmlParser.Parse();
        }
    }
}
