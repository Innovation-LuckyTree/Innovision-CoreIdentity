using AutoMapper;
using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Queries;

public class RolesDto : IRequest<Domain.Entity.Roles>
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entity.Roles, RolesDto>()
            .ForMember(k => k.RoleId, f => f.MapFrom(m => m.Id))
            .ForMember(k => k.RoleName, f => f.MapFrom(m => m.RoleName));
    }
}