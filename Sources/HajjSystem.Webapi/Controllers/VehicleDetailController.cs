using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleDetailController : ControllerBase
{
    private readonly IVehicleDetailService _service;
    private readonly IMapper _mapper;

    public VehicleDetailController(IVehicleDetailService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost("search")]
    public async Task<IActionResult> SearchVehicleDetails([FromBody] VehicleDetailSearchModel model)
    {
        var items = await _service.SearchVehicleDetailsAsync(model);
        var models = _mapper.Map<IEnumerable<VehicleDetailModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
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
                Message = "Vehicle detail not found" 
            });
        }

        var deleted = await _service.DeleteAsync(id);
        
        if (!deleted)
        {
            return StatusCode(500, new OperationResponse 
            { 
                Status = false, 
                Message = "Failed to delete vehicle detail" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Vehicle detail deleted successfully" 
        });
    }
}
