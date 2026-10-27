using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Proposals/Proposals")] // section name in Swagger UI
public class ProposalsController(IProposalService service, ILogger<ProposalsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<List<ProposalDto>> GetAll()
    {
        logger.LogInformation("Fetching all proposals");
        return await service.GetAllAsync();
    }

    [HttpGet("{itemId}/{warehouseId}/{proposalIndex:int}")]
    public async Task<ActionResult<ProposalDto>> GetById(string itemId, string warehouseId, int proposalIndex)
    {
        logger.LogInformation("Fetching proposal {ItemId}/{WarehouseId}/{ProposalIndex}", itemId, warehouseId, proposalIndex);
        var entity = await service.GetByIdAsync(itemId, warehouseId, proposalIndex);
        if (entity is null)
        {
            logger.LogWarning("Proposal {ItemId}/{WarehouseId}/{ProposalIndex} not found", itemId, warehouseId, proposalIndex);
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<ProposalDto>> Create(ProposalCreateDto dto)
    {
        var created = await service.CreateAsync(dto);
        logger.LogInformation("Created proposal {ItemId}/{WarehouseId}/{ProposalIndex}", created.ItemId, created.WarehouseId, created.ProposalIndex);
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
            logger.LogWarning("Proposal {ItemId}/{WarehouseId}/{ProposalIndex} not found for update", itemId, warehouseId, proposalIndex);
            return NotFound();
        }

        logger.LogInformation("Updated proposal {ItemId}/{WarehouseId}/{ProposalIndex}", itemId, warehouseId, proposalIndex);
        return Ok(updated);
    }

    [HttpDelete("{itemId}/{warehouseId}/{proposalIndex:int}")]
    public async Task<IActionResult> Delete(string itemId, string warehouseId, int proposalIndex)
    {
        var deleted = await service.DeleteAsync(itemId, warehouseId, proposalIndex);
        if (!deleted)
        {
            logger.LogWarning("Proposal {ItemId}/{WarehouseId}/{ProposalIndex} not found for delete", itemId, warehouseId, proposalIndex);
            return NotFound();
        }

        logger.LogInformation("Deleted proposal {ItemId}/{WarehouseId}/{ProposalIndex}", itemId, warehouseId, proposalIndex);
        return NoContent();
    }
}
