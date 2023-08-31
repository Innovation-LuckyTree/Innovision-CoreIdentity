using FluentValidation;

namespace CoreIdentity.Application.Requests.Tenants.Queries.GetAuthToken;

public class GetAuthQueryValidator : AbstractValidator<GetAuthTokenQuery>
{
    public GetAuthQueryValidator()
    {
        RuleFor(o => o.ClientId)
            .NotEmpty();
        
        RuleFor(o => o.Key)
            .NotEmpty();

        RuleFor(o => o.ResourceId)
            .NotEmpty();
    }
}
