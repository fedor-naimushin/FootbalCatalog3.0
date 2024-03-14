namespace FootballerCatalog.Contracts.Footballer;

public record FootballerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Gender,
    DateTime DataTime,
    string TeamTitle,
    string Country
);