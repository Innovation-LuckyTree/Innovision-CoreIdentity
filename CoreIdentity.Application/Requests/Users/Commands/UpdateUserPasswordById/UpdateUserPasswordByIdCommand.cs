using MediatR;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserPasswordById;

public record UpdateUserPasswordByIdCommand(Guid UserId, string NewPassword, string ConfirmNewPassword) : IRequest<Unit>
{
}

public class UpdateUserPasswordByIdCommandHandler : IRequestHandler<UpdateUserPasswordByIdCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public UpdateUserPasswordByIdCommandHandler(ICoreIdentityDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(o => o.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);
        _ = user ?? throw new Exception($"Unable to find User with UserID: {request.UserId}");

        var newUserPassword = CreatePassword(request.NewPassword);

        user.Password = newUserPassword.Password;
        user.PasswordSalt = newUserPassword.Salt;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}