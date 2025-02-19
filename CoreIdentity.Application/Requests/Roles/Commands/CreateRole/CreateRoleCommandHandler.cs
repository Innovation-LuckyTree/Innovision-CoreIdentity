using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler(ICoreIdentityDbContext dbContext) : IRequestHandler<CreateRoleCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext = dbContext;

    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Domain.Entity.Roles { Id = request.Id, RoleName = request.RoleName };
        
        await _dbContext.Database.ExecuteSqlInterpolatedAsync($@"SET IDENTITY_INSERT dbo.Roles ON
            INSERT INTO dbo.Roles (Id, RoleName, CreatedOn) VALUES ({role.Id}, {role.RoleName}, GETDATE())
            SET IDENTITY_INSERT dbo.Roles OFF        
        ", cancellationToken);

        return Unit.Value;
    }
}