using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleContractController : ControllerBase
{
    private readonly IVehicleContractService _service;
    private readonly IMapper _mapper;

    public VehicleContractController(IVehicleContractService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<VehicleContractModel>>(items);
        
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
                Message = "VehicleContract not found" 
            });
        }
        
        var model = _mapper.Map<VehicleContractModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleContractCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Validate date range
        if (model.StartDate >= model.EndDate)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Start date must be before end date" 
            });
        }
        
        var vehicleContract = _mapper.Map<VehicleContract>(model);
        
        var created = await _service.CreateAsync(vehicleContract);
        var createdModel = _mapper.Map<VehicleContractModel>(created);
        
        return Ok(new OperationResponse 
        { 
            Data = createdModel,
            Status = true, 
            Message = "VehicleContract created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] VehicleContractUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Vehicle Contract not found" 
            });
        }

        // Validate date range
        if (model.StartDate >= model.EndDate)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Start date must be before end date" 
            });
        }

        var vehicleContract = _mapper.Map<VehicleContract>(model);
        var updated = await _service.UpdateAsync(vehicleContract);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "VehicleContract updated successfully" 
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
                Message = "VehicleContract not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "VehicleContract deleted successfully" 
        });
    }
}
