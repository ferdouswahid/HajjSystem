using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackageVehicleController : ControllerBase
{
    private readonly IPackageVehicleService _service;

    public PackageVehicleController(IPackageVehicleService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exists = await _service.ExistsAsync(id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Package vehicle not found" 
            });
        }

        var deleted = await _service.DeleteAsync(id);
        
        if (!deleted)
        {
            return StatusCode(500, new OperationResponse 
            { 
                Status = false, 
                Message = "Failed to delete package vehicle" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Package vehicle deleted successfully" 
        });
    }
}
