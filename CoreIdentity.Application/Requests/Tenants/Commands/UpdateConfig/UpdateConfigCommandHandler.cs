using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Tenants.Commands.UpdateConfig;

public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public UpdateConfigCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _dbContext.Tenants.Where(o => o.Id == request.TenantId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find tenant ID {request.TenantId}");

        tenant.DefaultPassword = request.DefaultPassword;
        tenant.AppKey = request.AppKey;
        tenant.Issuer = request.Issuer;
        tenant.Domain = request.Domain;
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}