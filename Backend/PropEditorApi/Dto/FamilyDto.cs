namespace PropEditorApi.Dto;

public record FamilyDto(string FamilyId, string? Description);
public record FamilyCreateDto(string FamilyId, string? Description);
public record FamilyUpdateDto(string? Description);
