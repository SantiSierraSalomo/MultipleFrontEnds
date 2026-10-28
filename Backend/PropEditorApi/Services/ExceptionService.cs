using PropEditorApi.Exceptions;

namespace PropEditorApi.Services;

public class ExceptionService : IExceptionService
{
    public void ThrowNotFound() =>
        throw new DomainNotFoundException("Sample not found exception for handler validation.");

    public void ThrowValidation() =>
        throw new DomainValidationException("Sample validation exception for handler validation.");

    public void ThrowConflict() =>
        throw new DomainConflictException("Sample conflict exception for handler validation.");

    public void ThrowUnexpected() =>
        throw new Exception("Sample unhandled exception for handler validation.");
}
