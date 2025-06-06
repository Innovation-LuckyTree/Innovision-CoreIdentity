using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Commands.GetUserAccessToken;

public class GetUserAccessTokenQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper) : IRequestHandler<GetUserAccessTokenQuery, UserAccessTokenVm>
{
    private readonly ICoreIdentityDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<UserAccessTokenVm> Handle(GetUserAccessTokenQuery request, CancellationToken cancellationToken)
    {
        var userLog = await _dbContext.UserAccessTokens
            .Include(o => o.UserLog)
            .Where(o => o.UserLog.LogId == request.LogId && o.UserId == request.UserId)
            .ProjectTo<UserAccessTokenDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        var dNow = DateTime.Now;

        if (userLog == null || dNow.AddMinutes(-2) > userLog.Expiration)
        {
            return new UserAccessTokenVm(new UserAccessTokenDto()) { Sucess = false };
        }

        return new UserAccessTokenVm(userLog)
        {
            Sucess = true
        };
    }
}
