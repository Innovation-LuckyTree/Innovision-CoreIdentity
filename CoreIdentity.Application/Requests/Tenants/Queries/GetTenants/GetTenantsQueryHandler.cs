using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetTenants;

public class GetTenantsQueryHandler : IRequestHandler<GetTenantsQuery, TenantVm>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTenantsQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TenantVm> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        var results = await _dbContext.Tenants
            .ProjectTo<TenantDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TenantVm(results);
    }
} 