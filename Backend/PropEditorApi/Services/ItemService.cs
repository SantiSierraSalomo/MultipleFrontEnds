using PropEditorApi.Dto;
using PropEditorApi.Mapping;
using PropEditorApi.Repository;

namespace PropEditorApi.Services;

public class ItemService(IItemRepository repository, ILogger<ItemService> logger) : IItemService
{
    public async Task<List<ItemDto>> GetAllAsync() =>
        (await repository.GetAllAsync()).Select(x => x.ToDto()).ToList();

    public async Task<ItemDto?> GetByIdAsync(string itemId) =>
        (await repository.GetByIdAsync(itemId))?.ToDto();

    public async Task<ItemDto> CreateAsync(ItemCreateDto dto)
    {
        var created = await repository.AddAsync(dto.ToEntity());
        logger.LogInformation("Service created item {ItemId}", created.ItemId);
        return created.ToDto();
    }

    public async Task<ItemDto?> UpdateAsync(string itemId, ItemUpdateDto dto)
    {
        var current = await repository.GetByIdAsync(itemId);
        if (current is null)
        {
            logger.LogWarning("Service could not find item {ItemId} for update", itemId);
            return null;
        }

        current.ApplyUpdate(dto);
        await repository.UpdateAsync(current);
        logger.LogInformation("Service updated item {ItemId}", itemId);
        return current.ToDto();
    }

    public async Task<bool> DeleteAsync(string itemId)
    {
        var current = await repository.GetByIdAsync(itemId);
        if (current is null)
        {
            logger.LogWarning("Service could not find item {ItemId} for delete", itemId);
            return false;
        }

        await repository.DeleteAsync(current);
        logger.LogInformation("Service deleted item {ItemId}", itemId);
        return true;
    }
}
