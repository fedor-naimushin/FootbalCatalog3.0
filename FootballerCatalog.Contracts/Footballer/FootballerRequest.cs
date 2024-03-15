using System.ComponentModel.DataAnnotations;

namespace FootballerCatalog.Contracts.Footballer;

public record FootballerRequest(
    [Required]
    [MaxLength(5)]
    [MinLength(2)]
    string FirstName,
    string LastName,
    string Gender,
    DateOnly Birthday,
    string TeamTitle,
    string Country
);