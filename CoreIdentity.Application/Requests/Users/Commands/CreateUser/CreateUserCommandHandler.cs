using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Requests.Tenants.Commands.AddUsers;
using CoreIdentity.Application.Requests.Users.Commands.AddUserRole;
using CoreIdentity.Application.Requests.Users.Queries;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

namespace CoreIdentity.Application.Requests.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(ICoreIdentityDbContext dbContext, IMapper mapper, IMediator mediator)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isTempPassword = false;

        var tenant = await _dbContext.Tenants.Where(o => o.Id == request.TenantId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find Tenant with TenantId {request.TenantId}");

        var existingUserCheck = await TryCheckExistingUser(request, cancellationToken);

        if (existingUserCheck.IsExitingUser)
            return existingUserCheck.User;

        var role = await _dbContext.Roles.Where(o => o.Id == request.RoleId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find Role with RoleId {request.RoleId}");

        var password = request.Password;

        if (string.IsNullOrWhiteSpace(password))
        {
            password = tenant.DefaultPassword;
            isTempPassword = true;
        }

        var passwordHash = CreatePassword(password);

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            Password = passwordHash.Password,
            PasswordSalt = passwordHash.Salt,
            ChangePassword = isTempPassword,
            UserRoles = new[] { new UserRoles
                {
                    RoleId = role.Id
                }
            },
            TenantUsers = new[] {
                new TenantUser {
                    TenantId = tenant.Id
                }
            }
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserDto>(user);
    }

    private async Task<(bool IsExitingUser, UserDto User)> TryCheckExistingUser(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _dbContext.Users
            .Include(o => o.TenantUsers)
            .Include(o => o.UserRoles)
            .Where(o => o.UserName == request.UserName || o.MobileNumber == request.MobileNumber)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser == null)
            return (false, null);

        try
        {
            // if user is already exist, should return the current user and add the tenant and role
            if (!existingUser.TenantUsers.Select(o => o.TenantId).Contains(request.TenantId))
            {
                var tenantRequest = new AddUsersCommand(request.TenantId, new[] { existingUser.Id });
                await _mediator.Send(tenantRequest, cancellationToken);
            }

            if (!existingUser.UserRoles.Select(o => o.RoleId).Contains(request.RoleId))
            {
                var roleRequest = new AddUserRoleCommand(existingUser.Id, request.RoleId);
                await _mediator.Send(roleRequest, cancellationToken);
            }

            return (true, _mapper.Map<UserDto>(existingUser));
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update User {request.MobileNumber} because of this error!", ex);
        }
    }
}