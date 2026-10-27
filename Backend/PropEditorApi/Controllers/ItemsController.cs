using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Item")] // section name in Swagger UI
public class ItemsController(IItemService service, ILogger<ItemsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<List<ItemDto>> GetAll()
    {
        logger.LogInformation("Fetching all items");
        return await service.GetAllAsync();
    }

    [HttpGet("{itemId}")]
    public async Task<ActionResult<ItemDto>> GetById(string itemId)
    {
        logger.LogInformation("Fetching item {ItemId}", itemId);
        var entity = await service.GetByIdAsync(itemId);
        if (entity is null)
        {
            logger.LogWarning("Item {ItemId} not found", itemId);
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> Create(ItemCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        logger.LogInformation("Created item {ItemId}", created.ItemId);
        return CreatedAtAction(nameof(GetById), new { itemId = created.ItemId }, created);
    }

    [HttpPut("{itemId}")]
    public async Task<ActionResult<ItemDto>> Update(string itemId, ItemUpdateDto dto)
    {
        var updated = await service.UpdateAsync(itemId, dto);
        if (updated is null)
        {
            logger.LogWarning("Item {ItemId} not found for update", itemId);
            return NotFound();
        }

        logger.LogInformation("Updated item {ItemId}", itemId);
        return Ok(updated);
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> Delete(string itemId)
    {
        var deleted = await service.DeleteAsync(itemId);
        if (!deleted)
        {
            logger.LogWarning("Item {ItemId} not found for delete", itemId);
            return NotFound();
        }

        logger.LogInformation("Deleted item {ItemId}", itemId);
        return NoContent();
    }
}
