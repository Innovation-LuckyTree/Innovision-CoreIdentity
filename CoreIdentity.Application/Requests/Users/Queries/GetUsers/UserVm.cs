namespace CoreIdentity.Application.Requests.Users.Queries.Getusers;

public record UserVm(IEnumerable<UserDto> Users)
{
    public int TotalCount
    {
        get
        {
            return Users.Count();
        }
    }
}
