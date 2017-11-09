namespace XmlParserProject
{
    internal class RegexStrings
    {
        public const string PatternForElement = @"(\<(\w+){1}(.*?)\>)?";
        public const string PatternForSameElements = @"(\<({0}){{1}}(.*?)\>)?";
        public const string PatternForEndOfElement = @"\<\/{0}\>";
        public const string PatternForAttributes = @"\s{1}(\w+)\={1}(\""\w+\"")";
    }
}
