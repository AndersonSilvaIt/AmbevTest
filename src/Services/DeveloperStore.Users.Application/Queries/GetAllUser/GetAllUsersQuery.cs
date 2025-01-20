using DeveloperStore.Users.Application.DTOs;
using MediatR;

namespace DeveloperStore.Users.Application.Queries.GetAllUser
{
    public class GetAllUsersQuery: IRequest<PaginatedResponseDto>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }

        public GetAllUsersQuery(int pageIndex, int pageSize, string orderBy)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderBy = orderBy;
        }
    }
}
