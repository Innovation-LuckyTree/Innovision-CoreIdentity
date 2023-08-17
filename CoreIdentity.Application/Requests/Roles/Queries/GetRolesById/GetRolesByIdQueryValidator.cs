using FluentValidation;

namespace CoreIdentity.Application.Requests.Roles.Queries.GetRolesId;

public class GetRolesByIdQueryValidator : AbstractValidator<GetRolesByIdQuery>
{
    public GetRolesByIdQueryValidator()
    {
        RuleFor(o => o.RoleId)
            .NotEmpty();
    }
}
