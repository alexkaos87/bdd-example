namespace AwesomeLibrary
{
    public class Language
    {
        public Language(in string name, in string culture)
        {
            Name = name;
            Culture = culture;
        }

        public string Name { get; }
        public string Culture { get; }
    }
}
