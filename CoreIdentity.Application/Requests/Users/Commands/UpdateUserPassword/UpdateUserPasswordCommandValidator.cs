using FluentValidation;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserPassword;

public class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
{
    public UpdateUserPasswordCommandValidator()
    {
        RuleFor(o => o.UserId)
            .NotEmpty();

        RuleFor(o => o.CurrentPassword)
            .NotEmpty()
            .Equal(o => o.ConfirmNewPassword);
    }
}
