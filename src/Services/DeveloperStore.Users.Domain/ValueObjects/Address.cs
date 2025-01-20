namespace DeveloperStore.Users.Domain.ValueObjects
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string ZipCode { get; private set; }
        public Geolocation Geolocation { get; private set; }

        // EF
        private Address() { }
        public Address(string city, string street, int number, string zipCode, Geolocation geolocation)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            Street = street ?? throw new ArgumentNullException(nameof(street));
            Number = number;
            ZipCode = zipCode ?? throw new ArgumentNullException(nameof(zipCode));
            Geolocation = geolocation ?? throw new ArgumentNullException(nameof(geolocation));
        }
    }
}
