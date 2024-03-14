namespace FootballerCatalog.Contracts.Footballer;

public record FootballerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Gender,
    DateOnly Birthday,
    string TeamTitle,
    string Country
);