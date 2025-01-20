namespace DeveloperStore.Users.Domain.ValueObjects
{
    public class Geolocation
    {
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public Geolocation(string latitude, string longitude)
        {
            Latitude = latitude ?? throw new ArgumentNullException(nameof(latitude));
            Longitude = longitude ?? throw new ArgumentNullException(nameof(longitude));
        }
    }
}
