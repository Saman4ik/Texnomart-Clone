﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Texnomart.Aplication.DTOs.ProductDto;
using Texnomart.Aplication.Interfaces;
using Texnomart.Domain.Enums;

namespace TexnomartWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PtoductsController(IProductService productService
                                        ) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPut]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> UpdateProductAsync([FromForm] ProductDto dto)
    {
        await _productService.UpdateAsync(dto);
        return Ok(dto);
    }
    [HttpPost]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> CreateAsync([FromBody] AddProductDto dto)
    {
        await _productService.CreateAsync(dto);
        return Ok(dto);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _productService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _productService.GetAllAsync());

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> GetByIdAsync(int id)
        => Ok(await _productService.GetByIdAsync(id));

    [HttpGet("{name}")]
    [Authorize(Roles = "Admin, SupperAdmin")]
    public async Task<IActionResult> GetNameAsync(string name)
        => Ok(await _productService.GetByNameAsync(name));
}
