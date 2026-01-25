using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _service;

    public OrderDetailController(IOrderDetailService service)
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
                Message = "Order detail not found" 
            });
        }

        var deleted = await _service.DeleteAsync(id);
        
        if (!deleted)
        {
            return StatusCode(500, new OperationResponse 
            { 
                Status = false, 
                Message = "Failed to delete order detail" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Order detail deleted successfully" 
        });
    }
}
