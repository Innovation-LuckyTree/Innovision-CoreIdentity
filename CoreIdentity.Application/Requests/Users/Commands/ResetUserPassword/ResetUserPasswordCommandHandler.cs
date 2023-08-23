using CoreIdentity.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandHandler : IRequestHandler<ResetUserPasswordCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public ResetUserPasswordCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(o => o.UserName == request.UserName || o.MobileNumber == request.UserName)
            .FirstOrDefaultAsync(cancellationToken);

        _ = user ?? throw new Exception($"Unable to find user with User Name {request.UserName}");

        // Send email if user exist
        return Unit.Value;
    }
}
