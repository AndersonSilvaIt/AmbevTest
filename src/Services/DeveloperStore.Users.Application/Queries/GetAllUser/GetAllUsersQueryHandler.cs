using AutoMapper;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Interfaces;
using MediatR;

namespace DeveloperStore.Users.Application.Queries.GetAllUser
{
    public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, PaginatedResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponseDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var (users, totalItems) = await _userRepository.GetAllAsync(request.PageIndex, request.PageSize, request.OrderBy);

            var userDtos = _mapper.Map<List<UserDto>>(users);

            var totalPages = (int)Math.Ceiling((double)totalItems / request.PageSize);

            return new PaginatedResponseDto
            {
                Data = userDtos,
                TotalItems = totalItems,
                CurrentPage = request.PageIndex,
                TotalPages = totalPages
            };
        }
    }
}
