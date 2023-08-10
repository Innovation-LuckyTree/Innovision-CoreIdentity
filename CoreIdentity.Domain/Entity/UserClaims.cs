namespace CoreIdentity.Domain.Entity
{
    public class UserClaims
    {
        public Guid UserId { get; set; }
        public Guid ClaimId { get; set; }

        public User User { get; set; }
        public Claims Claims { get; set; }
    }
}