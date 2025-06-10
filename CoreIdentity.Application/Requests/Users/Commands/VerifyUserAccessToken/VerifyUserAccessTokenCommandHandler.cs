using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Requests.Users.Queries.CreateUserJwtToken;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Commands.VerifyUserAccessToken;

public class VerifyUserAccessTokenCommandHandler(ICoreIdentityDbContext context, IMediator mediator) : IRequestHandler<VerifyUserAccessTokenCommand, UserAccessTokenVm>
{
    private readonly ICoreIdentityDbContext _context = context;
    private readonly IMediator _mediator = mediator;

    public async Task<UserAccessTokenVm> Handle(VerifyUserAccessTokenCommand request, CancellationToken cancellationToken)
    {
        var userLog = await _context.UserLogs
            .Include(o => o.UserAccessTokens)
                .ThenInclude(e => e.UserAccessTokenLogs)
            .FirstOrDefaultAsync(x => x.LogId == request.LogId, cancellationToken);

        _ = userLog ?? throw new Exception("Unable to find user log!");

        if (DateTime.UtcNow > userLog.ExpiryTime)
            throw new Exception("Refresh Token is already expire!");

        if (userLog.UserAccessTokens.AccessToken != request.AccessToken)
            throw new Exception("Failed to validate user access token!");

        var user = await _context.Users.Where(o => o.Id == userLog.UserId)
            .Include(o => o.TenantUsers)
            .Include(o => o.UserRoles)
                .ThenInclude(e => e.Roles)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new Exception("Unable to find user!");

        var tokenLog = userLog.UserAccessTokens
            .UserAccessTokenLogs
            .OrderByDescending(o => o.LogDate)
            .FirstOrDefault();

        var userToken = await _mediator.Send(new CreateUserJwtTokenQuery(user, userLog.TenantId.ToString(), userLog.RefreshToken, userLog.LogId), cancellationToken);

        var result = new UserAccessTokenVm(userToken)
        {
            UserId = user.Id,
            Used = userLog.UserAccessTokens.Used,
            PreviousGameAccess = tokenLog?.GameName ?? "",
            CurrentGameAccess = request.GameName,
        };

        await ProcessUserAccessTokenAsync(userLog.UserAccessTokens, request.GameName, cancellationToken);

        return result;
    }

    private async Task ProcessUserAccessTokenAsync(UserAccessToken userAccessToken, string GameName, CancellationToken cancellationToken)
    {
        userAccessToken.Used = true;
        userAccessToken.UserAccessTokenLogs.Add(new UserAccessTokenLog
        {
            GameName = GameName
        });

        _context.UserAccessTokens.Update(userAccessToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}