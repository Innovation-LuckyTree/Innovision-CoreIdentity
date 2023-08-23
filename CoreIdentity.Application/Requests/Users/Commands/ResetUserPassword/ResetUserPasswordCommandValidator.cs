using FluentValidation;

namespace CoreIdentity.Application.Requests.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandValidator : AbstractValidator<ResetUserPasswordCommand>
{
    public ResetUserPasswordCommandValidator()
    {
        RuleFor(o => o.UserName)
            .NotEmpty();
    }
}
