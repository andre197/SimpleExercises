namespace XmlParserProject
{
    public class Attribute
    {
        public Attribute(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }

        public string Value { get; private set; }


    }
}
