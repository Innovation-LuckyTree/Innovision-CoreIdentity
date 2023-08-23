using CoreIdentity.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace CoreIdentity.Application.Requests.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly ICoreIdentityDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(ICoreIdentityDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Users.Where(o => o.Id == request.UserId)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
}