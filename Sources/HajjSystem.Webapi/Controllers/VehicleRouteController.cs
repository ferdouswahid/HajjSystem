using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleRouteController : ControllerBase
{
    private readonly IVehicleRouteService _service;
    private readonly IMapper _mapper;

    public VehicleRouteController(IVehicleRouteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<VehicleRouteModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound(new OperationResponse 
            {
                Status = false, 
                Message = "VehicleRoute not found" 
            });
        }
        
        var model = _mapper.Map<VehicleRouteModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleRouteCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Check for duplicate name
        var exists = await _service.ExistsByNameAsync(model.Name);
        if (exists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "A VehicleRoute with this name already exists" 
            });
        }
        
        var vehicleRoute = _mapper.Map<VehicleRoute>(model);
        
        var created = await _service.CreateAsync(vehicleRoute);
        var createdModel = _mapper.Map<VehicleRouteModel>(created);
        
        return Ok(new OperationResponse 
        { 
            Data = createdModel,
            Status = true, 
            Message = "VehicleRoute created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] VehicleRouteUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "VehicleRoute not found" 
            });
        }

        // Check for duplicate name (excluding current record)
        var nameExists = await _service.ExistsByNameAsync(model.Name, model.Id);
        if (nameExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "A VehicleRoute with this name already exists" 
            });
        }

        var vehicleRoute = _mapper.Map<VehicleRoute>(model);
        var updated = await _service.UpdateAsync(vehicleRoute);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "VehicleRoute updated successfully" 
        });
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        
        if (!deleted)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "VehicleRoute not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "VehicleRoute deleted successfully" 
        });
    }
}
