using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Requests.Users.Queries;

public class UserDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public int IdNumber { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>().
            ForMember(f => f.Id, f => f.MapFrom(m => m.Id)).
            ForMember(f => f.UserName, f => f.MapFrom(m => m.UserName)).
            ForMember(f => f.Email, f => f.MapFrom(m => m.Email)).
            ForMember(f => f.MobileNumber, f => f.MapFrom(m => m.MobileNumber));
    }
}