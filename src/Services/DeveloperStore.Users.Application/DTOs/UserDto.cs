﻿namespace DeveloperStore.Users.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public NameDto Name { get; set; }
        public AddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}