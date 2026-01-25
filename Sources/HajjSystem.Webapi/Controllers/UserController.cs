using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost("search")]
    public async Task<IActionResult> SearchUsers([FromBody] UserSearchModel model)
    {
        var users = await _service.SearchUsersAsync(model);
        var userModels = _mapper.Map<IEnumerable<UserModel>>(users);
        
        return Ok(new OperationResponse 
        {   
            Data = userModels.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpPost("customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerUserCreationModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateCustomerAsync(model);
        return Ok(new { message = result });
    }

    [AllowAnonymous]
    [HttpPost("company")]
    public async Task<IActionResult> CreateCompanyUser([FromBody] CompanyUserCreationModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateCompanyUserAsync(model);
        return Ok(new { message = result });
    }





}
