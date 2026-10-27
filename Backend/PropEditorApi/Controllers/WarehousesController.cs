using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Warehouse")] // section name in Swagger UI
public class WarehousesController(IWarehouseService service, ILogger<WarehousesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<List<WarehouseDto>> GetAll()
    {
        logger.LogInformation("Fetching all warehouses");
        return await service.GetAllAsync();
    }

    [HttpGet("{warehouseId}")]
    public async Task<ActionResult<WarehouseDto>> GetById(string warehouseId)
    {
        logger.LogInformation("Fetching warehouse {WarehouseId}", warehouseId);
        var entity = await service.GetByIdAsync(warehouseId);
        if (entity is null)
        {
            logger.LogWarning("Warehouse {WarehouseId} not found", warehouseId);
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<WarehouseDto>> Create(WarehouseCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        logger.LogInformation("Created warehouse {WarehouseId}", created.WarehouseId);
        return CreatedAtAction(nameof(GetById), new { warehouseId = created.WarehouseId }, created);
    }

    [HttpPut("{warehouseId}")]
    public async Task<ActionResult<WarehouseDto>> Update(string warehouseId, WarehouseUpdateDto dto)
    {
        var updated = await service.UpdateAsync(warehouseId, dto);
        if (updated is null)
        {
            logger.LogWarning("Warehouse {WarehouseId} not found for update", warehouseId);
            return NotFound();
        }

        logger.LogInformation("Updated warehouse {WarehouseId}", warehouseId);
        return Ok(updated);
    }

    [HttpDelete("{warehouseId}")]
    public async Task<IActionResult> Delete(string warehouseId)
    {
        var deleted = await service.DeleteAsync(warehouseId);
        if (!deleted)
        {
            logger.LogWarning("Warehouse {WarehouseId} not found for delete", warehouseId);
            return NotFound();
        }

        logger.LogInformation("Deleted warehouse {WarehouseId}", warehouseId);
        return NoContent();
    }
}
