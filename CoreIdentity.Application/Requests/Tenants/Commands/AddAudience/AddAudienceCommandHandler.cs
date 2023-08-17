using CoreIdentity.Application.Common.Interfaces;
using CoreIdentity.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddAudience;

public class AddAudienceCommandHandler : IRequestHandler<AddAudienceCommand, Unit>
{
    private readonly ICoreIdentityDbContext _dbContext;

    public AddAudienceCommandHandler(ICoreIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(AddAudienceCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _dbContext.Tenants.Where(o => o.Id == request.TenantId)
            .SingleOrDefaultAsync(cancellationToken);

        _ = tenant ?? throw new Exception($"Unable to find tenant ID {request.TenantId}");

        request.Audiences.ToList().ForEach(o => tenant.TenantAudiences.Add(
            new TenantAudience {
                AudienceId = o
            }));
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
