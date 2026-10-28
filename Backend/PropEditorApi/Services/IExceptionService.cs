namespace PropEditorApi.Services;

public interface IExceptionService
{
    void ThrowNotFound();
    void ThrowValidation();
    void ThrowConflict();
    void ThrowUnexpected();
}
