using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Proposals/Proposals")] // section name in Swagger UI
public class ProposalsController(IProposalService service) : ControllerBase
{
    [HttpGet]
    public Task<List<ProposalDto>> GetAll() => service.GetAllAsync();

    [HttpGet("{itemId}/{warehouseId}/{proposalIndex:int}")]
    public async Task<ActionResult<ProposalDto>> GetById(string itemId, string warehouseId, int proposalIndex)
    {
        var entity = await service.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<ProposalDto>> Create(ProposalCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { itemId = created.ItemId, warehouseId = created.WarehouseId, proposalIndex = created.ProposalIndex },
            created);
    }

    [HttpPut("{itemId}/{warehouseId}/{proposalIndex:int}")]
    public async Task<ActionResult<ProposalDto>> Update(
        string itemId,
        string warehouseId,
        int proposalIndex,
        ProposalUpdateDto dto)
    {
        var updated = await service.UpdateAsync(itemId, warehouseId, proposalIndex, dto);
        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{itemId}/{warehouseId}/{proposalIndex:int}")]
    public async Task<IActionResult> Delete(string itemId, string warehouseId, int proposalIndex)
    {
        var deleted = await service.DeleteAsync(itemId, warehouseId, proposalIndex);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
