using FluentValidation;

namespace CoreIdentity.Application.Requests.Tenants.Commands.UpdateConfig;

public class UpdateConfigCommandValidator : AbstractValidator<UpdateConfigCommand>
{
    public UpdateConfigCommandValidator()
    {
        RuleFor(o => o.TenantId)
            .NotEmpty();

        RuleFor(o => o.AppKey)
            .NotEmpty();

        RuleFor(o => o.DefaultPassword)
            .NotEmpty();

        RuleFor(o => o.Issuer)
            .NotEmpty();
    }
}
