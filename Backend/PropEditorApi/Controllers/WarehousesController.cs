using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Warehouse")] // section name in Swagger UI
public class WarehousesController(IWarehouseService service) : ControllerBase
{
    [HttpGet]
    public Task<List<WarehouseDto>> GetAll() => service.GetAllAsync();

    [HttpGet("{warehouseId}")]
    public async Task<ActionResult<WarehouseDto>> GetById(string warehouseId)
    {
        var entity = await service.GetByIdAsync(warehouseId);
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<WarehouseDto>> Create(WarehouseCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { warehouseId = created.WarehouseId }, created);
    }

    [HttpPut("{warehouseId}")]
    public async Task<ActionResult<WarehouseDto>> Update(string warehouseId, WarehouseUpdateDto dto)
    {
        var updated = await service.UpdateAsync(warehouseId, dto);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{warehouseId}")]
    public async Task<IActionResult> Delete(string warehouseId)
    {
        var deleted = await service.DeleteAsync(warehouseId);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
