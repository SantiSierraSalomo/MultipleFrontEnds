using PropEditorApi.Dto;

namespace PropEditorApi.Services;

public interface IItemService
{
    Task<List<ItemDto>> GetAllAsync();
    Task<ItemDto?> GetByIdAsync(string itemId);
    Task<ItemDto> CreateAsync(ItemCreateDto dto);
    Task<ItemDto?> UpdateAsync(string itemId, ItemUpdateDto dto);
    Task<bool> DeleteAsync(string itemId);
}
