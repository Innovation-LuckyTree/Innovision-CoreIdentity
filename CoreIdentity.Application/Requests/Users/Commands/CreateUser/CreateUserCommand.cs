using CoreIdentity.Application.Requests.Users.Queries;
using MediatR;

namespace CoreIdentity.Application.Requests.Users.Commands;

public record CreateUserCommand(string UserName, string Email, string MobileNumber,
    string Password, int RoleId, bool IsCompanyAdmin, Guid TenantId, Guid? CompanyId) : IRequest<UserDto>;
