namespace XmlParserProject
{
    internal class RegexStrings
    {
        public const string PatternForValidXML = @"^(\<\?xml(\s{1}(\w+)={1}\"".+?\"")*\?\>)?((\<(\w+){1}(.*?)\>)(.*)\<(\/\6)\>)$";
        public const string PatternForElements = @"(\<(\w+)(\s{1}\w+\={1}\"".*?\"")*\>)(.*)(\<\/\2\>)";
        public const string PatternForSameElements = @"(\<({0}){{1}}(.*?)\>)?";
        public const string PatternForEndOfElement = @"\<\/{0}\>";
        public const string PatternForAttributes = @"\s{1}(\w+)\={1}(\""\w+\"")";
    }
}
