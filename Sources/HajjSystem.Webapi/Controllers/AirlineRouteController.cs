using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirlineRouteController : ControllerBase
{
    private readonly IAirlineRouteService _service;
    private readonly IMapper _mapper;

    public AirlineRouteController(IAirlineRouteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<AirlineRouteModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound(new OperationResponse 
            {
                Status = false, 
                Message = "Airline route not found" 
            });
        }
        
        var model = _mapper.Map<AirlineRouteModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AirlineRouteCreateModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var airlineRoute = _mapper.Map<AirlineRoute>(model);

        var created = await _service.CreateAsync(airlineRoute);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Airline route created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AirlineRouteUpdateModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Airline route not found" 
            });
        }

        var airlineRoute = _mapper.Map<AirlineRoute>(model);
        var updated = await _service.UpdateAsync(airlineRoute);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Airline route updated successfully" 
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
                Message = "Airline route not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Airline route deleted successfully" 
        });
    }
}
