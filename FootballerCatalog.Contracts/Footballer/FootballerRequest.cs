namespace FootballerCatalog.Contracts.Footballer;

public record FootballerRequest(
    string FirstName,
    string LastName,
    string Gender,
    DateTime DataTime,
    string TeamTitle,
    string Country
);