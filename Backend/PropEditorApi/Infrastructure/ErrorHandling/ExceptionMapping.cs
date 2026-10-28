using PropEditorApi.Exceptions;

namespace PropEditorApi.Infrastructure.ErrorHandling;

public static class ExceptionMapping
{
    public static (int StatusCode, string Type, string Title) Map(Exception exception)
    {
        return exception switch
        {
            DomainNotFoundException => (StatusCodes.Status404NotFound, "https://httpstatuses.com/404", "Not Found"),
            DomainValidationException => (StatusCodes.Status400BadRequest, "https://httpstatuses.com/400", "Bad Request"),
            DomainConflictException => (StatusCodes.Status409Conflict, "https://httpstatuses.com/409", "Conflict"),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "https://httpstatuses.com/404", "Not Found"),
            ArgumentException => (StatusCodes.Status400BadRequest, "https://httpstatuses.com/400", "Bad Request"),
            InvalidOperationException => (StatusCodes.Status409Conflict, "https://httpstatuses.com/409", "Conflict"),
            _ => (StatusCodes.Status500InternalServerError, "https://httpstatuses.com/500", "Internal Server Error")
        };
    }
}
