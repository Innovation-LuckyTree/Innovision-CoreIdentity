using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;

namespace CoreIdentity.Application.Requests.Users.Commands.GetUserAccessToken;

public class UserAccessTokenDto : IMapFrom<UserAccessToken>
{
    public long UserAccessTokenId { get; set; }
    public Guid UserId { get; set; }
    public long UserLogId { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public Guid LogId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserAccessToken, UserAccessTokenDto>().
            ForMember(f => f.UserId, f => f.MapFrom(m => m.UserId)).
            ForMember(f => f.UserAccessTokenId, f => f.MapFrom(m => m.UserAccessTokenId)).
            ForMember(f => f.UserLogId, f => f.MapFrom(m => m.UserLogId)).
            ForMember(f => f.AccessToken, f => f.MapFrom(m => m.AccessToken)).
            ForMember(f => f.RefreshToken, f => f.MapFrom(m => m.UserLog.RefreshToken)).
            ForMember(f => f.Expiration, f => f.MapFrom(m => m.UserLog.ExpiryTime)).
            ForMember(f => f.LogId, f => f.MapFrom(m => m.UserLog.LogId));
    }
}