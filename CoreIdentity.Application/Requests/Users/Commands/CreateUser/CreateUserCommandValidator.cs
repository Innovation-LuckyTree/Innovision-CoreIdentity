using FluentValidation;

namespace CoreIdentity.Application.Requests.Users.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(o => o.MobileNumber)
            .NotEmpty()
            .MinimumLength(10);

        RuleFor(o => o.UserName)
            .NotEmpty();

        RuleFor(o => o.TenantId)
            .NotEmpty();
    }
}
