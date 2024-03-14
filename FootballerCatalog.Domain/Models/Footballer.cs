namespace FootballerCatalog.Models;

public class Footballer
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Gender { get; }
    public DateOnly Birthday { get; }
    public string TeamTitle { get; }
    public string Country { get; }

    public Footballer(
        Guid id,
        string firstName,
        string lastName,
        string gender,
        DateOnly birthday,
        string teamTitle,
        string country)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Birthday = birthday;
        TeamTitle = teamTitle;
        Country = country;
    }
}