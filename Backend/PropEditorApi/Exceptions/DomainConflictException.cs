namespace PropEditorApi.Exceptions;

public sealed class DomainConflictException(string message) : DomainException(message);
