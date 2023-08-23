using FluentValidation;

namespace CoreIdentity.Application.Requests.Users.Queries.UpdateUserInfo;

public class UpdateUserInfoCommandValidator : AbstractValidator<UpdateUserInfoCommand>
{
    public UpdateUserInfoCommandValidator()
    {
        RuleFor(o => o.MobileNumber)
            .NotEmpty();
    }
}
