using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Queries.GetLockedUsers
{
    public record GetLockedUsersQuery(Guid CompanyObjectId, int? PageNumber = null, int? PageSize = null) : IRequest<LockedUserVm>;
    public class GetLockedUsersQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper) : IRequestHandler<GetLockedUsersQuery, LockedUserVm>
    {
        private readonly ICoreIdentityDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<LockedUserVm> Handle(GetLockedUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Users.Where(o => o.CompanyId == request.CompanyObjectId && o.Locked)
                    .OrderByDescending(m => m.LockTime)
                    .AsQueryable();

            var total = await query.CountAsync();

            if (request.PageNumber.HasValue && request.PageSize.HasValue)
            {
                query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                              .Take(request.PageSize.Value);
            }

            var userslist = await query
                    .ProjectTo<LockedUserDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new LockedUserVm
            {
                Results = userslist,
                Total = total,
                PageNumber = request.PageNumber ?? 1,
                PageSize = request.PageSize ?? total
            };
        }
    }
}
