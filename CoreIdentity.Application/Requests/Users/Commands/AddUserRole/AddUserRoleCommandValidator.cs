using FluentValidation;

namespace CoreIdentity.Application.Requests.Users.Commands.AddUserRole;

public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
{
    public AddUserRoleCommandValidator()
    {
        RuleFor(o => o.UserId)
            .Empty();

        RuleFor(o => o.RoleId)
            .GreaterThanOrEqualTo(0);
    }
}
