using HajjSystem.Models.Entities;
using HajjSystem.Models.Models;
using HajjSystem.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HajjSystem.Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly IUserService _userService;
    private readonly ICompanyService _companyService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;

    public OrderController(
        IOrderService service,
        IOrderDetailService orderDetailService,
        IUserService userService,
        ICompanyService companyService,
        IMapper mapper)
    {
        _service = service;
        _orderDetailService = orderDetailService;
        _userService = userService;
        _companyService = companyService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        var models = _mapper.Map<IEnumerable<OrderModel>>(items);
        
        return Ok(new OperationResponse 
        {   
            Data = models.ToArray(),
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [Authorize]
    [HttpPost("search")]
    public async Task<IActionResult> SearchOrders([FromBody] OrderSearchModel model)
    {
        var items = await _service.SearchOrdersAsync(model);
        var models = _mapper.Map<IEnumerable<OrderModel>>(items);
        
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
                Message = "Order not found" 
            });
        }
        
        var model = _mapper.Map<OrderModel>(item);
        
        return Ok(new OperationResponse 
        {   
            Data = model,
            Status = true, 
            Message = "Get data successfully" 
        });
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateWithDetailsAsync(model);
        return Ok(new { message = result });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] OrderUpdateModel model)
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
                Message = "Order not found" 
            });
        }
        
        return Ok(new OperationResponse 
        { 
            Status = true, 
            Message = "Order deleted successfully" 
        });
    }
}
