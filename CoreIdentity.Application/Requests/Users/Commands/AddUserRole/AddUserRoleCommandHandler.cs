using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Commands.AddUserRole;

public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public AddUserRoleCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(o => o.Id == request.UserId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = user ?? throw new Exception($"Unable to find User with UserId : {request.UserId}");

        var role = await _dbContext.Roles.Where(o => o.Id == request.RoleId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = role ?? throw new Exception($"Unable to find Role with RoleId : {request.RoleId}");

        user.UserRoles.Add(new UserRoles()
        {
            RoleId = role.Id
        });

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}