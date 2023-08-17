using AutoMapper;
using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Requests.Tenants.Queries;

public class TenantDto : IMapFrom<Tenant>
{
    public Guid TenantId { get; set; }
    public string TenantName { get; set; }
    public int Type { get; set; }
    public string AdminUser { get; set; }
    public string DefaultPassword { get; set; }
    public string AppKey { get; set; }
    public string Issuer { get; set; }
    public string Domain { get; set; }

    public IEnumerable<string> TenantAudience { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tenant, TenantDto>()
            .ForMember(k => k.TenantId, f => f.MapFrom(m => m.Id))
            .ForMember(k => k.TenantName, f => f.MapFrom(m => m.TenantName))
            .ForMember(k => k.AdminUser, f => f.MapFrom(m => m.AdminUser.GetUserName()))
            .ForMember(k => k.DefaultPassword, f => f.MapFrom(m => m.DefaultPassword))
            .ForMember(k => k.AppKey, f => f.MapFrom(m => m.AppKey))
            .ForMember(k => k.Issuer, f => f.MapFrom(m => m.Issuer))
            .ForMember(k => k.Domain, f => f.MapFrom(m => m.Domain))
            .ForMember(k => k.TenantAudience, f => f.MapFrom(m => m.GetTenantAudiences()));
    }
}