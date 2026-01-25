using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackageController : ControllerBase
{
    private readonly IPackageService _service;
    private readonly IPackageTypeService _packageTypeService;
    private readonly ICompanyService _companyService;
    private readonly ISeasonService _seasonService;
    private readonly IPackageVehicleService _packageVehicleService;
    private readonly IMapper _mapper;

    public PackageController(
        IPackageService service,
        IPackageVehicleService packageVehicleService,
        IPackageTypeService packageTypeService,
        ICompanyService companyService,
        ISeasonService seasonService,
        IMapper mapper)
    {
        _service = service;
        _packageVehicleService = packageVehicleService;
        _packageTypeService = packageTypeService;
        _companyService = companyService;
        _seasonService = seasonService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<PackageModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost("search")]
    public async Task<IActionResult> SearchPackages([FromBody] PackageSearchModel model)
    {
        var items = await _service.SearchPackagesAsync(model);
        var models = _mapper.Map<IEnumerable<PackageModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdWithDetailsAsync(int id)
    {
        var item = await _service.GetByIdWithDetailsAsync(id);
        if (item is null)
        {
            return NotFound(new OperationResponse 
            {
                Status = false, 
                Message = "Package not found" 
            });
        }
        
        var model = _mapper.Map<PackageModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PackageCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Validate PackageTypeId
       /*  var packageTypeExists = await _packageTypeService.ExistsAsync(model.PackageTypeId);
        if (!packageTypeExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Package type not found" 
            });
        } */
        
        // Validate CompanyId
      /*   var companyExists = await _companyService.ExistsAsync(model.CompanyId);
        if (!companyExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Company not found" 
            });
        } */
        
        // Validate SeasonId
/*         var seasonExists = await _seasonService.ExistsAsync(model.SeasonId);
        if (!seasonExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Season not found" 
            });
        } */

        var result = await _service.CreateWithDetailsAsync(model);
        return Ok(new { message = result });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PackageUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Validate PackageTypeId
        /* var packageTypeExists = await _packageTypeService.ExistsAsync(model.PackageTypeId);
        if (!packageTypeExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Package type not found" 
            });
        } */
        
        // Validate CompanyId
        /* var companyExists = await _companyService.ExistsAsync(model.CompanyId);
        if (!companyExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Company not found" 
            });
        } */
        
        // Validate SeasonId
     /*    var seasonExists = await _seasonService.ExistsAsync(model.SeasonId);
        if (!seasonExists)
        {
            return BadRequest(new OperationResponse 
            { 
                Status = false, 
                Message = "Season not found" 
            });
        } */

        var result = await _service.UpdateWithDetailsAsync(model);
        return Ok(new { message = result });
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
                Message = "Package not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Package deleted successfully" 
        });
    }
}
