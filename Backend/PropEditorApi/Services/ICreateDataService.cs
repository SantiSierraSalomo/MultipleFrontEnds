using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface ICreateDataService
{
    Task<CreateMasterdataResultDto> CreateMasterdataAsync();
    Task<CreateProposalsResultDto> CreateProposalsAsync();
}
