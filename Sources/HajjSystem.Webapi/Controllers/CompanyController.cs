using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _service;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<CompanyModel>>(items);
        
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
                Message = "Company not found" 
            });
        }
        
        var model = _mapper.Map<CompanyModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CompanyCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var company = _mapper.Map<Company>(model);
        
        var created = await _service.CreateAsync(company);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Company created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CompanyUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Company not found" 
            });
        }

        var company = _mapper.Map<Company>(model);
        var updated = await _service.UpdateAsync(company);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Company updated successfully" 
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
                Message = "Company not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Company deleted successfully" 
        });
    }
}
