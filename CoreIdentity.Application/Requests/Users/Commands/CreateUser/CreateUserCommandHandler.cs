using AutoMapper;
using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Application.Requests.Users.Queries;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static CoreIdentity.Application.Common.Extensions.CryptographyExtensions;

namespace CoreIdentity.Application.Requests.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(ICoreIdentityDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExist = await _dbContext.Users
            .Where(o => o.UserName == request.UserName || o.MobileNumber == request.MobileNumber)
            .AnyAsync(cancellationToken);
        
        if (userExist)
            throw new Exception($"UserName or Mobile Number is already exist!");

        var tenant = await _dbContext.Tenants.Where(o => o.Id == request.TenantId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find Tenant with TenantId {request.TenantId}");

        var role = await _dbContext.Roles.Where(o => o.Id == request.RoleId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find Role with RoleId {request.RoleId}");
        
        var password = request.Password;

        if (string.IsNullOrWhiteSpace(password))
        {
            password = tenant.DefaultPassword;
        }

        var passwordHash = CreatePassword(password);

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            Password = passwordHash.Password,
            PasswordSalt = passwordHash.Salt,
            UserRoles = new [] { new UserRoles
                {
                    RoleId = role.Id
                }
            }
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserDto>(user);
    }
}