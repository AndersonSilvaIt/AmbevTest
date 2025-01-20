using AutoMapper;
using DeveloperStore.Core.Exceptions;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Interfaces;
using MediatR;

namespace DeveloperStore.Users.Application.Commands.DeleteUserCommand
{
    public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ExistsAsync(request.Id);

            if(!user) throw new NotFoundException($"User with ID {request.Id} not found.");

            await _userRepository.DeleteAsync(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
