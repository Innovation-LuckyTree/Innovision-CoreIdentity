using CoreIdentity.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

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

        var tempPassword = CreateTempPassword();

        var passwordHash = CreatePassword(tempPassword);

        user.Password = passwordHash.Password;
        user.PasswordSalt = passwordHash.Salt;

        await _dbContext.SaveChangesAsync(cancellationToken);
        // Send email if user exist
        return Unit.Value;
    }
}
