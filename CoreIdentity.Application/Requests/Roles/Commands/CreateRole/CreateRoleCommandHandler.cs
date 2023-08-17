using CoreIdentity.Application.Common.Interfaces;
using MediatR;

namespace CoreIdentity.Application.Requests.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public CreateRoleCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Domain.Entity.Roles { RoleName = request.RoleName };

        _dbContext.Roles.Add(role);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}