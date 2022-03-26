namespace AwesomeLibrary
{
    public class Site
    {
        public Site(in string name, in Language language)
        {
            Name = name;
            Language = language;
        }

        public string Name { get; }
        public Language Language { get; }
    }
}
