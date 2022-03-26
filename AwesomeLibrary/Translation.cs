namespace AwesomeLibrary
{
    public class Translation
    {
        public Translation(in string key)
        {
            Key = key;
        }


        public Translation(in Language language, in string key, in string translation)
        {
            Key = key;
            AddTranslation(language, translation);
        }

        public void AddTranslation(in Language language, in string translation)
        {
            _translation.Add(language, translation);
        }

        public string Key { get; }

        private IDictionary<Language, string> _translation = new Dictionary<Language, string>();

        public string GetTranslation(in Language language)
        {
            if (_translation.TryGetValue(language, out var translation))
            {
                return translation;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
