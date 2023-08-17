using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.UpdateConfig;

public record UpdateConfigCommand(Guid TenantId, string DefaultPassword, string AppKey, string Issuer, string Domain) : IRequest<Unit>;
