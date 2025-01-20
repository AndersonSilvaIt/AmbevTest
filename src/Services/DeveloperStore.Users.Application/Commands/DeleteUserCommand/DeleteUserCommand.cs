using DeveloperStore.Users.Application.DTOs;
using MediatR;

namespace DeveloperStore.Users.Application.Commands.DeleteUserCommand
{
    public class DeleteUserCommand: IRequest<UserDto>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
