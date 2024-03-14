namespace FootballerCatalog.DataBase.Entities;

public class FootballerEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; }
    public DateOnly Birthday { get; set; }
    public string TeamTitle { get; set; } = string.Empty;
    public string Country { get; set; }
}