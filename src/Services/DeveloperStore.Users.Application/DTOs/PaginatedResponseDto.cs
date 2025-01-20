namespace DeveloperStore.Users.Application.DTOs
{
    public class PaginatedResponseDto
    {
        public List<UserDto> Data { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

