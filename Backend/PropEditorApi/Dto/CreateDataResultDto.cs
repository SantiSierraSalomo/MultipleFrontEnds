namespace PropEditorApi.Dto;

public record CreateMasterdataResultDto(
    int FamiliesCreated,
    int SuppliersCreated,
    int ItemsCreated,
    int WarehousesCreated,
    string Message);

public record CreateProposalsResultDto(
    int DaysCreated,
    int ProposalsCreated,
    string Message);
