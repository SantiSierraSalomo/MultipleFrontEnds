using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Dto;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Seed / CreateData")]
public class CreateDataController(ICreateDataService service, ILogger<CreateDataController> logger) : ControllerBase
{
    [HttpPost("CreateMasterdata")]
    public async Task<ActionResult<CreateMasterdataResultDto>> CreateMasterdata()
    {
        logger.LogInformation("CreateMasterdata request received");
        var result = await service.CreateMasterdataAsync();
        logger.LogInformation(
            "CreateMasterdata finished. Families: {Families}, Suppliers: {Suppliers}, Items: {Items}, Warehouses: {Warehouses}",
            result.FamiliesCreated,
            result.SuppliersCreated,
            result.ItemsCreated,
            result.WarehousesCreated);

        return Ok(result);
    }

    [HttpPost("CreateProposals")]
    public async Task<ActionResult<CreateProposalsResultDto>> CreateProposals()
    {
        logger.LogInformation("CreateProposals request received");
        var result = await service.CreateProposalsAsync();
        logger.LogInformation("CreateProposals finished. Days: {Days}, Proposals: {Proposals}", result.DaysCreated, result.ProposalsCreated);

        return Ok(result);
    }
}
