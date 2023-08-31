using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;

namespace CoreIdentity.Application.Requests.Roles.Queries;

public class RolesDto : IMapFrom<Domain.Entity.Roles>
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entity.Roles, RolesDto>()
            .ForMember(k => k.RoleId, f => f.MapFrom(m => m.Id))
            .ForMember(k => k.RoleName, f => f.MapFrom(m => m.RoleName));
    }
}