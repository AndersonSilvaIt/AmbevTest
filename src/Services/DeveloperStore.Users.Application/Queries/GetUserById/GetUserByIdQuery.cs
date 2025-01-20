using DeveloperStore.Users.Application.DTOs;
using MediatR;

namespace DeveloperStore.Users.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
