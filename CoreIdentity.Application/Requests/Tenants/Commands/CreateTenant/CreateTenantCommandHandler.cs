using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;

namespace CoreIdentity.Application.Requests.Tenants.Commands.CreateTenant;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public CreateTenantCommandHandler(ICoreIdentityDbContext dbContext, IAppConfig appConfig)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = new Tenant
        {
            Id = request.CompanyId,
            TenantName = request.TenantName,
            AdminUserId = request.AdminUserId,
            Type = request.Type,
            DefaultPassword = request.DefaultPassword,
            AppKey = request.AppKey,
            Issuer = request.Issuer,
            Domain = request.Domain
        };

        _dbContext.Tenants.Add(tenant);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
