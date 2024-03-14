namespace FootballerCatalog.Contracts.Footballer;

public record UpsertFootballerRequest(
    string FirstName,
    string LastName,
    string Gender,
    DateTime DataTime,
    string TeamTitle,
    string Country
);