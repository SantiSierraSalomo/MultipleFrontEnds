namespace PropEditorApi.Exceptions;

public sealed class DomainNotFoundException(string message) : DomainException(message);
