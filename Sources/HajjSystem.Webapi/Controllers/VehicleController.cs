using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _service;
    private readonly ICompanyService _companyService;
    private readonly IVendorService _vendorService;
    private readonly IMapper _mapper;
    private readonly IVehicleDetailService _vehicleDetailService;

    public VehicleController(IVehicleService service,IVehicleDetailService vehicleDetailService, ICompanyService companyService, IVendorService vendorService, IMapper mapper)
    {
        _service = service;
        _vehicleDetailService = vehicleDetailService;
        _companyService = companyService;
        _vendorService = vendorService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<VehicleModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }


    [Authorize]
    [HttpGet("search")]
    public async Task<IActionResult> SearchVehicles([FromQuery] VehicleSearchModel model)
    {
        var items = await _service.SearchVehiclesAsync(model);
        var models = _mapper.Map<IEnumerable<VehicleModel>>(items);
        
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
                Message = "Vehicle not found" 
            });
        }
        
        var model = _mapper.Map<VehicleModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] VehicleCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        //var userCompanyId = User.FindFirst("CompanyId")?.Value;


        // Validate CompanyId if provided
       /* if (model.CompanyId.HasValue)
        {
            var companyExists = await _companyService.ExistsAsync(model.CompanyId.Value);
            if (!companyExists)
            {
                return BadRequest(new OperationResponse 
                { 
                    Status = false, 
                    Message = "Company not found" 
                });
            }
        }*/
        
        // Validate VendorId if provided
  /*       if (model.VendorId.HasValue)
        {
            var vendorExists = await _vendorService.ExistsAsync(model.VendorId.Value);
            if (!vendorExists)
            {
                return BadRequest(new OperationResponse 
                { 
                    Status = false, 
                    Message = "Vendor not found" 
                });
            }
        } */
        
         

        var result = await _service.CreateWithDetailsAsync(model);
        return Ok(new { message = result });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] VehicleUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Validate CompanyId if provided
        /* if (model.CompanyId.HasValue)
        {
            var companyExists = await _companyService.ExistsAsync(model.CompanyId.Value);
            if (!companyExists)
            {
                return BadRequest(new OperationResponse 
                { 
                    Status = false, 
                    Message = "Company not found" 
                });
            }
        } */
        
        // Validate VendorId if provided
       /*  if (model.VendorId.HasValue)
        {
            var vendorExists = await _vendorService.ExistsAsync(model.VendorId.Value);
            if (!vendorExists)
            {
                return BadRequest(new OperationResponse 
                { 
                    Status = false, 
                    Message = "Vendor not found" 
                });
            }
        } */

        var result = await _service.UpdateWithDetailsAsync(model);
        return Ok(result);
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
                Message = "Vehicle not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Vehicle deleted successfully" 
        });
    }
}
