using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IContractService _service;
    private readonly IVendorService _vendorService;
    private readonly ICompanyService _companyService;
    private readonly ISeasonService _seasonService;
    private readonly IVehicleContractService _vehicleContractService;
    private readonly IMapper _mapper;

    public ContractController(
        IContractService service,
        IVehicleContractService vehicleContractService,
        IVendorService vendorService,
        ICompanyService companyService,
        ISeasonService seasonService,
        IMapper mapper)
    {
        _service = service;
        _vehicleContractService = vehicleContractService;
        _vendorService = vendorService;
        _companyService = companyService;
        _seasonService = seasonService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<ContractModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost("search")]
    public async Task<IActionResult> SearchContracts([FromBody] ContractSearchModel model)
    {
        var items = await _service.SearchContractsAsync(model);
        var models = _mapper.Map<IEnumerable<ContractModel>>(items);
        
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
                Message = "Contract not found" 
            });
        }
        
        var model = _mapper.Map<ContractModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ContractCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateWithDetailsAsync(model);
        return Ok(new { message = result });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ContractUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

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
                Message = "Contract not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Contract deleted successfully" 
        });
    }
}
