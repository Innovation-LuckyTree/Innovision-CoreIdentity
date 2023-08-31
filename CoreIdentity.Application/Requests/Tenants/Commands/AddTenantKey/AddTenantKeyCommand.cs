using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddTenantKey;

public record AddTenantKeyCommand(Guid TenantId, DateTime StartDate, DateTime ExpirationDate) : IRequest<TenantKeyResult>;
