using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Supplier")] // section name in Swagger UI
public class SuppliersController(ISupplierService service, ILogger<SuppliersController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<List<SupplierDto>> GetAll()
    {
        logger.LogInformation("Fetching all suppliers");
        return await service.GetAllAsync();
    }

    [HttpGet("{supplierId}")]
    public async Task<ActionResult<SupplierDto>> GetById(string supplierId)
    {
        logger.LogInformation("Fetching supplier {SupplierId}", supplierId);
        var entity = await service.GetByIdAsync(supplierId);
        if (entity is null)
        {
            logger.LogWarning("Supplier {SupplierId} not found", supplierId);
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<SupplierDto>> Create(SupplierCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        logger.LogInformation("Created supplier {SupplierId}", created.SupplierId);
        return CreatedAtAction(nameof(GetById), new { supplierId = created.SupplierId }, created);
    }

    [HttpPut("{supplierId}")]
    public async Task<ActionResult<SupplierDto>> Update(string supplierId, SupplierUpdateDto dto)
    {
        var updated = await service.UpdateAsync(supplierId, dto);
        if (updated is null)
        {
            logger.LogWarning("Supplier {SupplierId} not found for update", supplierId);
            return NotFound();
        }

        logger.LogInformation("Updated supplier {SupplierId}", supplierId);
        return Ok(updated);
    }

    [HttpDelete("{supplierId}")]
    public async Task<IActionResult> Delete(string supplierId)
    {
        var deleted = await service.DeleteAsync(supplierId);
        if (!deleted)
        {
            logger.LogWarning("Supplier {SupplierId} not found for delete", supplierId);
            return NotFound();
        }

        logger.LogInformation("Deleted supplier {SupplierId}", supplierId);
        return NoContent();
    }
}
