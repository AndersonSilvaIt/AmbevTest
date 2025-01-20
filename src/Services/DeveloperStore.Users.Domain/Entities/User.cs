using DeveloperStore.Users.Domain.Enums;
using DeveloperStore.Users.Domain.ValueObjects;

namespace DeveloperStore.Users.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }

        // EF
        private User() { }

        public User(int id, string email, string username, string password, Name name, Address address, string phone, UserStatus status, UserRole role)
        {
            Id = id;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Status = status;
            Role = role;
        }
    }
}