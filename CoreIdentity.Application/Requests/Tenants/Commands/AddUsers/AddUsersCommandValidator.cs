using FluentValidation;

namespace CoreIdentity.Application.Requests.Tenants.Commands.AddUsers;

public class AddUsersCommandValidator : AbstractValidator<AddUsersCommand>
{
    public AddUsersCommandValidator()
    {
        RuleFor(o => o.TenantId)
            .NotEmpty();

        // RuleFor(o => o.UserIds)
        //     .Must(o => o.Any(i => i.));
    }
}
