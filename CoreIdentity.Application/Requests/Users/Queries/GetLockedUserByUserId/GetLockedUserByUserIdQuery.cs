using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Queries.GetLockedUserByUserId
{
    public record GetLockedUserByUserIdQuery(Guid UserId) : IRequest<bool>;
    public class GetLockedUserByUserIdQueryHandler(ICoreIdentityDbContext dbContext) : IRequestHandler<GetLockedUserByUserIdQuery, bool>
    {
        private readonly ICoreIdentityDbContext _dbContext = dbContext;

        public async Task<bool> Handle(GetLockedUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.Where(o => o.Id == request.UserId && o.Locked).AnyAsync();
        }
    }
}
