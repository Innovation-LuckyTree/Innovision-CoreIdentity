using FluentValidation;

namespace CoreIdentity.Application.Requests.Tenants.Commands.CreateTenant;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(o => o.CompanyId)
            .NotEmpty();

        RuleFor(o => o.Type)
            .NotEmpty();
    }
}
