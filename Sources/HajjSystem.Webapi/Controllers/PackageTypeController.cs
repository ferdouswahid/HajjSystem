using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackageTypeController : ControllerBase
{
    private readonly IPackageTypeService _service;
    private readonly IMapper _mapper;

    public PackageTypeController(IPackageTypeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchPackageTypes([FromBody] PackageTypeSearchModel model)
    {
        var items = await _service.SearchPackageTypesAsync(model);
        var models = _mapper.Map<IEnumerable<PackageTypeModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<PackageTypeModel>>(items);
        
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
                Message = "PackageType not found" 
            });
        }
        
        var model = _mapper.Map<PackageTypeModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PackageTypeCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var packageType = _mapper.Map<PackageType>(model);
        var created = await _service.CreateAsync(packageType);
        var resultModel = _mapper.Map<PackageTypeModel>(created);
        
        return Ok(new OperationResponse 
        {
            Data = resultModel,
            Status = true, 
            Message = "PackageType created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PackageTypeUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "PackageType not found" 
            });
        }

        var packageType = _mapper.Map<PackageType>(model);
        var updated = await _service.UpdateAsync(packageType);
        var resultModel = _mapper.Map<PackageTypeModel>(updated);
        
        return Ok(new OperationResponse 
        {
            Data = resultModel,
            Status = true, 
            Message = "PackageType updated successfully" 
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
                Message = "PackageType not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "PackageType deleted successfully" 
        });
    }
}
