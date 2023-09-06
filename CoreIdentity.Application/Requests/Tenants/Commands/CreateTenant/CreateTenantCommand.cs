using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.CreateTenant;

public record CreateTenantCommand(Guid CompanyId, string TenantName, int Type, Guid? AdminUserId, string DefaultPassword, string AppKey, string Issuer, string Domain) : IRequest<Unit>;
