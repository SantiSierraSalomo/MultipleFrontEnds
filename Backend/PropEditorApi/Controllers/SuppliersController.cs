using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Supplier")] // section name in Swagger UI
public class SuppliersController(ISupplierService service) : ControllerBase
{
    [HttpGet]
    public Task<List<SupplierDto>> GetAll() => service.GetAllAsync();

    [HttpGet("{supplierId}")]
    public async Task<ActionResult<SupplierDto>> GetById(string supplierId)
    {
        var entity = await service.GetByIdAsync(supplierId);
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<SupplierDto>> Create(SupplierCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { supplierId = created.SupplierId }, created);
    }

    [HttpPut("{supplierId}")]
    public async Task<ActionResult<SupplierDto>> Update(string supplierId, SupplierUpdateDto dto)
    {
        var updated = await service.UpdateAsync(supplierId, dto);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{supplierId}")]
    public async Task<IActionResult> Delete(string supplierId)
    {
        var deleted = await service.DeleteAsync(supplierId);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
