using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Texnomart.Aplication.DTOs.OrderDTOs;
using Texnomart.Aplication.Interfaces;

namespace TexnomartWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersCantroller(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync(AddOrderDto dto)
    {
        await _orderService.CreateAsync(dto);
        return Ok(dto);
    }

    [HttpGet("{orders}")]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllAsync()
    {
        await _orderService.GetAllAsync();
        return Ok();
    }
    [HttpGet("{id}")]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        await _orderService.GetByIdAsync(id);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _orderService.DeleteAsync(id);
        return Ok();
    }
}
