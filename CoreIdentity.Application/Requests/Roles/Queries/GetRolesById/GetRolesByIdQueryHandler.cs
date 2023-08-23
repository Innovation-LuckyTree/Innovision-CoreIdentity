using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Roles.Queries.GetRolesId;

public class GetRolesByIdQueryHandler : IRequestHandler<GetRolesByIdQuery, RolesDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetRolesByIdQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<RolesDto> Handle(GetRolesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles
            .Where(o => o.Id == request.RoleId)
            .ProjectTo<RolesDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);
    }
}