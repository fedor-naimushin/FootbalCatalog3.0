using FluentValidation;
using FootballerCatalog.Common;
using FootballerCatalog.Contracts.Footballer;

namespace FootballerCatalog.Application.Validations;

public class CreateFootballerRequestValidator : AbstractValidator<FootballerRequest>, IAssemblyMarker
{
    public CreateFootballerRequestValidator()
    {
        RuleFor(x => x.FirstName).Length(3, 30);
        RuleFor(x => x.LastName).Length(3, 30);
        RuleFor(x => x.TeamTitle).Length(3, 30);
        RuleFor(x => x.Birthday).Must(x => x < DateOnly.FromDateTime(DateTime.UtcNow));
    }
}