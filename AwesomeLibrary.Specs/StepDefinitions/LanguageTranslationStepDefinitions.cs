#nullable disable
namespace AwesomeLibrary.Specs.StepDefinitions
{
    [Binding]
    public class LanguageTranslationStepDefinitions
    {
        List<Language> _availableLanguagesList = new();
        List<Translation> _availableTranslationsList = new();
        List<Site> _sitesList = new();
        List<User> _usersList = new();

        [Given(@"the following languages exist:")]
        public void GivenTheFollowingLanguagesExist(Table table)
        {
            _availableLanguagesList = table.Rows.
                Select(row => new Language(row[0].ToString(), row[1].ToString())).
                ToList();
        }

        [Given(@"the following translations exist:")]
        public void GivenTheFollowingTranslationsExist(Table table)
        {
            foreach (var row in table.Rows)
            {
                var language = _availableLanguagesList.FirstOrDefault(x => x.Name == row[0].ToString());
                if (language == default)
                    continue;

                var translationKey = row[1].ToString();
                var translationValue = row[2].ToString();
                if (!_availableTranslationsList.Any(translation => translation.Key == translationKey))
                {
                    _availableTranslationsList.Add(new Translation(language, translationKey, translationValue));
                }
                else
                {
                    _availableTranslationsList.
                        First(translation => translation.Key == translationKey).
                        AddTranslation(language, translationValue);
                }
            }
        }

        [Given(@"the following sites exist:")]
        public void GivenTheFollowingSitesExist(Table table)
        {
            foreach (var row in table.Rows)
            {
                var language = _availableLanguagesList.FirstOrDefault(x => x.Name == row[1].ToString());
                if (language == default)
                    continue;

                _sitesList.Add(new Site(row[0].ToString(), language));
            }
        }

        [Given(@"the following users exist:")]
        public void GivenTheFollowingUsersExist(Table table)
        {
            foreach (var row in table.Rows)
            {
                var language = _availableLanguagesList.FirstOrDefault(x => x.Name == row[3].ToString());
                if (language == default)
                    continue; 
                
                _usersList.Add(new User(row[0].ToString(), row[1].ToString(), row[2].ToString(), language));
            }
        }

        private User _currentUser;

        [Given(@"I am the user ""([^""]*)""")]
        public void GivenIAmTheUser(string userName)
        {
            _currentUser = _usersList.
                FirstOrDefault(user => user.UserName == userName);
            _currentUser.Should().NotBeNull();
        }

        private Translation _currentTranslation;

        [When(@"the system sends the message ""([^""]*)""")]
        public void WhenTheSystemSendsTheMessage(string message)
        {
            _currentTranslation = _availableTranslationsList.
                FirstOrDefault(translation => translation.Key == message);
            _currentTranslation.Should().NotBeNull();
        }

        [Then(@"I should see the error message ""([^""]*)""")]
        public void ThenIShouldSeeTheErrorMessage(string expectedMessage)
        {
            var requiredLanguage = _currentLanguage ?? _currentUser.Language;

            var actualMessage = _currentTranslation.GetTranslation(requiredLanguage);
            actualMessage.Should().Be(expectedMessage);
        }

        private Language _currentLanguage;

        [Given(@"my site language is set to ""([^""]*)""")]
        public void GivenMySiteLanguageIsSetTo(string languageName)
        {
            _currentLanguage = _availableLanguagesList.
                FirstOrDefault(language => language.Name == languageName);
            _currentLanguage.Should().NotBeNull();
        }

        [When(@"I set my my language to ""([^""]*)""")]
        public void WhenISetMyMyLanguageTo(string newLanguageName)
        {
            var newLanguage = _availableLanguagesList.
                FirstOrDefault(language => language.Name == newLanguageName);
            newLanguage.Should().NotBeNull();

            _currentUser.ChangeLanguage(newLanguage);
        }

        [Then(@"my language should be equal to ""([^""]*)""")]
        public void ThenMyLanguageShouldBeEqualTo(string expectedLanguage) => 
            _currentUser.Language.Name.Should().Be(expectedLanguage);
    }
}
