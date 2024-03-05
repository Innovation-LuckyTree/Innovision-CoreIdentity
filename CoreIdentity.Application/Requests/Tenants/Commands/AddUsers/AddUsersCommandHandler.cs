using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddUsers;

public class AddUsersCommandHandler : IRequestHandler<AddUsersCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public AddUsersCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddUsersCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _dbContext.Tenants.Where(o => o.Id == request.TenantId)
            .FirstOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find tenant with tenantId : {request.TenantId}");

        var users = await _dbContext.Users.Where(o => request.UserIds.Contains(o.Id))
            .ToListAsync(cancellationToken);

        if ((users?.Count ?? 0) == 0)
        {
            throw new Exception($"Unable to find user/s with userIds : {string.Join(",", request.UserIds)}");
        }

        var userTenants = users.Select(o =>
            new TenantUser
            {
                TenantId = request.TenantId,
                UserId = o.Id
            }
        );

        _dbContext.TenantUsers.AddRange(userTenants);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}