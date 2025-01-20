using AutoMapper;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Interfaces;
using MediatR;

namespace DeveloperStore.Users.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(request.Id));
        }
    }
}
