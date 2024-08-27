using CoreIdentity.Application.Common.Exceptions;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Commands.UnlockUserAccount;

public class UnlockUserAccountCommandHandler(ICoreIdentityDbContext coreIdentityDbContext) : IRequestHandler<UnlockUserAccountCommand, Unit>
{
    private readonly ICoreIdentityDbContext _coreIdentityDbContext = coreIdentityDbContext;

    public async Task<Unit> Handle(UnlockUserAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _coreIdentityDbContext.Users.Where(o => o.Id == request.AccountId).FirstOrDefaultAsync(cancellationToken);

        _ = account ?? throw new EntityNotFoundException(typeof(User).Name, request.AccountId);

        account.Locked = false;
        account.Attempts = 0;

        await _coreIdentityDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
