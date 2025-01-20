namespace DeveloperStore.Users.Application.DTOs
{
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string ZipCode { get; set; }
        public GeolocationDto Geolocation { get; set; }
    }
}

