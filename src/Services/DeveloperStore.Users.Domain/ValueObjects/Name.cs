namespace DeveloperStore.Users.Domain.ValueObjects
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            if(string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First name and last name must not be empty.");

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
