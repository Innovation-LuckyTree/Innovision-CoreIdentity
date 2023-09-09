using FluentValidation;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetAuthToken;

public class GetAuthTokenQueryValidator : AbstractValidator<GetAuthTokenQuery>
{
    public GetAuthTokenQueryValidator()
    {
        RuleFor(o => o.ClientId)
            .NotEmpty();
        
        RuleFor(o => o.Key)
            .NotEmpty();

        RuleFor(o => o.ResourceId)
            .NotEmpty();
    }
}
