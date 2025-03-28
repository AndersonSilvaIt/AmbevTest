﻿using DeveloperStore.Users.Application.DTOs;
using MediatR;

namespace DeveloperStore.Users.Application.Commands.UpdateUser
{
    public class UpdateUserCommand: IRequest<UserDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public NameDto Name { get; set; }
        public AddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; } // Enum: Active, Inactive, Suspended
        public string Role { get; set; }   // Enum: Customer, Manager, Admin
    }
}
