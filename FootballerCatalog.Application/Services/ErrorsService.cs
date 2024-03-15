using ErrorOr;

namespace FootballerCatalog.Application.Services;

public static class ErrorsService
{
    public static class Footballer
    {
        public static Error NotFound => Error.NotFound(
            code: "Footballer.NotFound",
            description: "Footballer not found"
        );
    }
}