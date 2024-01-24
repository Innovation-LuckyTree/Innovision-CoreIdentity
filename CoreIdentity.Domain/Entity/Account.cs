using CoreIdentity.Domain.Common;

namespace CoreIdentity.Domain.Entity
{
    public class Account : AuditableEntity
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public string BloodType { get; set; }
        public string Nationality { get; set; }
        public string NatureOfWork { get; set; }
        public string SourceOfIncome { get; set; }
        public string BirthDate { get; set; }
        public string MobileNumber { get; set; }
        public decimal Commision { get; set; }
        public int UserTypeId { get; set; }
        public int BranchId { get; set; }
        public bool IsMain { get; set; }
        public string RefferralKey { get; set; }
        public bool IsActive { get; set; }
        public int AccountStatusId { get; set; }
        public string RefferralCode { get; set; }
        public string ValidId { get; set; }
        public string Signature { get; set; }
        public string ProfilePicture { get; set; }
        public string AccountCommission { get; set; }
        public bool IsVerified { get; set; }
    }
}