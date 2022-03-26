namespace AwesomeLibrary
{
    public class User
    {
        public User(in string firstName, in string lastName, in string userName, in Language language)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Language = language;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string UserName { get; }
        public Language Language { get; private set; }

        public void ChangeLanguage(in Language newLanguage) => Language = newLanguage;
    }
}
