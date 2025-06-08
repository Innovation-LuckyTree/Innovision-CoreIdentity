using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

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


        if (userLog == null)
            return await CreateUserAccessToken(request.UserId, request.LogId, cancellationToken);

        if (DateTime.UtcNow.AddMinutes(-2) > userLog.Expiration)
        {
            return new UserAccessTokenVm(new UserAccessTokenDto())
            {
                Sucess = false
            };
        }


        return new UserAccessTokenVm(userLog)
        {
            Sucess = true
        };
    }

    private async Task<UserAccessTokenVm> CreateUserAccessToken(Guid userId, Guid logId, CancellationToken cancellationToken)
    {
        var userLog = await _dbContext.UserLogs
            .Where(o => o.LogId == logId && o.UserId == userId)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (userLog == null || DateTime.UtcNow.AddMinutes(-2) > userLog.ExpiryTime)
        {
            return new UserAccessTokenVm(new UserAccessTokenDto())
            {
                Sucess = false,
            };
        }

        var token = CreatePassword(logId.ToString());

        var userAccessToken = new UserAccessToken
        {
            UserId = userId,
            UserLogId = userLog.UserLogId,
            AccessToken = token.Password,
            AccessTokenKey = token.Salt
        };

        _dbContext.UserAccessTokens.Add(userAccessToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var userAccessTokenDto = await _dbContext.UserAccessTokens
            .Include(o => o.UserLog)
            .Where(o => o.UserAccessTokenId == userAccessToken.UserAccessTokenId)
            .ProjectTo<UserAccessTokenDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return new UserAccessTokenVm(userAccessTokenDto)
        {
            Sucess = true
        };
    }
}
