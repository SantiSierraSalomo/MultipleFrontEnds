using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Item")] // section name in Swagger UI
public class ItemsController(IItemService service) : ControllerBase
{
    [HttpGet]
    public Task<List<ItemDto>> GetAll() => service.GetAllAsync();

    [HttpGet("{itemId}")]
    public async Task<ActionResult<ItemDto>> GetById(string itemId)
    {
        var entity = await service.GetByIdAsync(itemId);
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> Create(ItemCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { itemId = created.ItemId }, created);
    }

    [HttpPut("{itemId}")]
    public async Task<ActionResult<ItemDto>> Update(string itemId, ItemUpdateDto dto)
    {
        var updated = await service.UpdateAsync(itemId, dto);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{itemId}")]
    public async Task<IActionResult> Delete(string itemId)
    {
        var deleted = await service.DeleteAsync(itemId);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
