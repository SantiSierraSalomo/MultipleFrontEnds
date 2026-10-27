using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Masterdata / Family")] // section name in Swagger UI
public class FamiliesController(IFamilyService service, ILogger<FamiliesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<List<FamilyDto>> GetAll()
    {
        logger.LogInformation("Fetching all families");
        return await service.GetAllAsync();
    }

    [HttpGet("{familyId}")]
    public async Task<ActionResult<FamilyDto>> GetById(string familyId)
    {
        logger.LogInformation("Fetching family {FamilyId}", familyId);
        var entity = await service.GetByIdAsync(familyId);
        if (entity is null)
        {
            logger.LogWarning("Family {FamilyId} not found", familyId);
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<FamilyDto>> Create(FamilyCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        logger.LogInformation("Created family {FamilyId}", created.FamilyId);
        return CreatedAtAction(nameof(GetById), new { familyId = created.FamilyId }, created);
    }

    [HttpPut("{familyId}")]
    public async Task<ActionResult<FamilyDto>> Update(string familyId, FamilyUpdateDto dto)
    {
        var updated = await service.UpdateAsync(familyId, dto);
        if (updated is null)
        {
            logger.LogWarning("Family {FamilyId} not found for update", familyId);
            return NotFound();
        }

        logger.LogInformation("Updated family {FamilyId}", familyId);
        return Ok(updated);
    }

    [HttpDelete("{familyId}")]
    public async Task<IActionResult> Delete(string familyId)
    {
        var deleted = await service.DeleteAsync(familyId);
        if (!deleted)
        {
            logger.LogWarning("Family {FamilyId} not found for delete", familyId);
            return NotFound();
        }

        logger.LogInformation("Deleted family {FamilyId}", familyId);
        return NoContent();
    }
}
