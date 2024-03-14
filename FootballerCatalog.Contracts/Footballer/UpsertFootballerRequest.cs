namespace FootballerCatalog.Contracts.Footballer;

public record UpsertFootballerRequest(
    string FirstName,
    string LastName,
    string Gender,
    DateOnly Birthday,
    string TeamTitle,
    string Country
);