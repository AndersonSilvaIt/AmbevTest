using AutoMapper;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Entities;
using DeveloperStore.Users.Domain.Interfaces;
using MediatR;

namespace DeveloperStore.Users.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _userRepository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
