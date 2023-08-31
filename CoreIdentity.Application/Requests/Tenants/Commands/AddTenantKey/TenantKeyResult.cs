namespace CoreIdentity.Application.Requests.Tenants.Commands.AddTenantKey;

public record TenantKeyResult(Guid Resource, Guid ClientId, string TenantKey, string AccessType);
