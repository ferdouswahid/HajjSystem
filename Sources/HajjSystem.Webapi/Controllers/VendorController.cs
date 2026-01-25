using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
    private readonly IVendorService _service;
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public VendorController(IVendorService service, ICompanyService companyService, IMapper mapper)
    {
        _service = service;
        _companyService = companyService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<VendorModel>>(items);
        
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
                Message = "Vendor not found" 
            });
        }
        
        var model = _mapper.Map<VendorModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VendorCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Check if company exists
        var companyExists = await _companyService.ExistsAsync(model.CompanyId);
        if (!companyExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Company not found" 
            });
        }
        
        
        var vendor = _mapper.Map<Models.Entities.Vendor>(model);
        
        var created = await _service.CreateAsync(vendor);
        var createdModel = _mapper.Map<VendorModel>(created);
        
        return Ok(new OperationResponse 
        { 
            Data = createdModel,
            Status = true, 
            Message = "Vendor created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] VendorUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Vendor not found" 
            });
        }
        
        // Check if company exists
        var companyExists = await _companyService.ExistsAsync(model.CompanyId);
        if (!companyExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Company not found" 
            });
        }

        var vendor = _mapper.Map<Models.Entities.Vendor>(model);
        var updated = await _service.UpdateAsync(vendor);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Vendor updated successfully" 
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
                Message = "Vendor not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Vendor deleted successfully" 
        });
    }
}
