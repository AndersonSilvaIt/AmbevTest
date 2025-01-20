using AutoMapper;
using DeveloperStore.Core.Exceptions;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Interfaces;
using MediatR;

namespace DeveloperStore.Users.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if(user == null) throw new NotFoundException($"User with ID {request.Id} not found.");

            _mapper.Map(request, user);
            await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
