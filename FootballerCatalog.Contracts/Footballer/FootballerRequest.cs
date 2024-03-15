using System.ComponentModel.DataAnnotations;

namespace FootballerCatalog.Contracts.Footballer;

public record FootballerRequest(
    string FirstName,
    string LastName,
    string Gender,
    DateOnly Birthday,
    string TeamTitle,
    string Country
);