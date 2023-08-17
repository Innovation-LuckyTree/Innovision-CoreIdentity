using FluentValidation;

namespace CoreIdentity.Application.Requests.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(o => o.RoleName)
            .NotEmpty();
    }
}
