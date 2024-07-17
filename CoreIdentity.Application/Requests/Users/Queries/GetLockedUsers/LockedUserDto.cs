using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Requests.Users.Queries.GetLockedUsers
{
    public class LockedUserDto : IMapFrom<User>
    {
        public Guid UserId { get; set; }
        public int Attempts { get; set; }
        public DateTime LockTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, LockedUserDto>().
                ForMember(f => f.UserId, f => f.MapFrom(m => m.Id)).
                ForMember(f => f.Attempts, f => f.MapFrom(m => m.Attempts)).
                ForMember(f => f.LockTime, f => f.MapFrom(m => m.LockTime));
        }
    }
}