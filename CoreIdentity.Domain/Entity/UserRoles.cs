namespace CoreIdentity.Domain.Entity
{
    public class UserRoles
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Roles Roles { get; set; }
    }
}