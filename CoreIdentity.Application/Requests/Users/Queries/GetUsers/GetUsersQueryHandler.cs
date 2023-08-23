using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreIdentity.Application.Requests.Users.Queries.Getusers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserVm>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        return new UserVm(users);
    }
}
