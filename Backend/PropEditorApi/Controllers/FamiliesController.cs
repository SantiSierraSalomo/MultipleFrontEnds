using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Family")] // section name in Swagger UI
public class FamiliesController(IFamilyService service) : ControllerBase
{
    [HttpGet]
    public Task<List<FamilyDto>> GetAll() => service.GetAllAsync();

    [HttpGet("{familyId}")]
    public async Task<ActionResult<FamilyDto>> GetById(string familyId)
    {
        var entity = await service.GetByIdAsync(familyId);
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<FamilyDto>> Create(FamilyCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { familyId = created.FamilyId }, created);
    }

    [HttpPut("{familyId}")]
    public async Task<ActionResult<FamilyDto>> Update(string familyId, FamilyUpdateDto dto)
    {
        var updated = await service.UpdateAsync(familyId, dto);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{familyId}")]
    public async Task<IActionResult> Delete(string familyId)
    {
        var deleted = await service.DeleteAsync(familyId);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
