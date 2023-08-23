using CoreIdentity.Application.Common.Extensions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public UpdateUserPasswordCommandHandler(ICoreIdentityDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(o => o.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);
        _ = user ?? throw new Exception($"Unable to find User with UserID: {request.UserId}");

        if (!IsValidUserCredential(user, request.CurrentPassword))
        {
            throw new Exception("Current Password does not match to loggedin user!");
        }

        var newUserPassword = CreatePassword(request.NewPassword);

        user.Password = newUserPassword.Password;
        user.PasswordSalt = newUserPassword.Salt;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private bool IsValidUserCredential(User user, string currentPassword)
    {
        var currentPasswordHash = currentPassword.GetPasswordHash(user.PasswordSalt);

        if (!user.Password.Equals(currentPasswordHash))
        {
            return false;
        }

        return true;
    }
}