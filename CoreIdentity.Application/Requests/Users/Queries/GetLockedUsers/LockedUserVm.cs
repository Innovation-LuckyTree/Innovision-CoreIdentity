namespace CoreIdentity.Application.Requests.Users.Queries.GetLockedUsers
{
    public class LockedUserVm
    {
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public List<LockedUserDto> Results { get; set; }
    }
}
