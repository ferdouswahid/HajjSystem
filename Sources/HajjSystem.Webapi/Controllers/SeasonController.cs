using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeasonController : ControllerBase
{
    private readonly ISeasonService _service;
    private readonly IMapper _mapper;

    public SeasonController(ISeasonService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    //[Authorize(Roles = "Owner,Customer")]
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()

    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<SeasonModel>>(items);

        return Ok(new OperationResponse 
        {   Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {

      var roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
      var userName = User.FindFirst("UserName")?.Value;
      var userId = User.FindFirst("UserId")?.Value;
      var seasonId = User.FindFirst("SeasonId")?.Value;
      var companyId = User.FindFirst("CompanyId")?.Value;
      var userType = User.FindFirst("UserType")?.Value;

      Console.WriteLine($"=== JWT Claims ===");
      Console.WriteLine($"Roles: {string.Join(", ", roles)}");
      Console.WriteLine($"UserName: {userName}");
      Console.WriteLine($"UserId: {userId}");
      Console.WriteLine($"SeasonId: {seasonId}");
      Console.WriteLine($"CompanyId: {companyId}");
      Console.WriteLine($"UserType: {userType}");
      Console.WriteLine($"==================");



        var item = await _service.GetByIdAsync(id);
        if (item is null)
            {
                return NotFound(new OperationResponse 
                {
                    Status = false, 
                    Message = "Season not found" 
                });
            }

        var model = _mapper.Map<SeasonModel>(item);
        
        return Ok(new OperationResponse 
        {   Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentSeason()
    {
        var item = await _service.GetCurrentSeasonAsync();
        if (item is null)
        {
            return NotFound(new OperationResponse 
            {
                Status = false, 
                Message = "No current season found" 
            });
        }
        
        var model = _mapper.Map<SeasonModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = new[] { model },
            Status = true, 
            Message = "Get current season successfully" 
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SeasonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var season = _mapper.Map<Season>(model);
        
        var created = await _service.CreateAsync(season);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Season created successfully" 
        });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SeasonUpdateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var exists = await _service.ExistsAsync(model.Id);
        if (!exists)
        {
            return NotFound(new OperationResponse 
            { 
                Status = false, 
                Message = "Season not found" 
            });
        }

        var season = _mapper.Map<Season>(model);
        var updated = await _service.UpdateAsync(season);
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Season updated successfully" 
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
                Message = "Season not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Season deleted successfully" 
        });
    }
}
