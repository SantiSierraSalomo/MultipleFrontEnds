namespace PropEditorApi.Exceptions;

public sealed class DomainValidationException(string message) : DomainException(message);
