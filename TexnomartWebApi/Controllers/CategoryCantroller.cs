using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texnomart.Aplication.DTOs.CategoryDTOs;
using Texnomart.Aplication.Interfaces;

namespace TexnomartWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryCantroller(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpPost]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> CteateAsync(AddCategoryDto dto)
    {
        await _categoryService.CreateAsync(dto);
        return Ok(dto);
    }

    [HttpPut]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> UpdateAsync(CategoryDto dto)
    {
        await _categoryService.UpdateAsync(dto);
        return Ok(dto);
    }

    [HttpGet("{Id}")]
    [Authorize(Roles ="Admin, SuperAdmin")]

    public async Task<IActionResult> GetByIdAsync(int id)
    {
        await _categoryService.GetByIdAsync(id);
        return Ok();
    }

    [HttpGet("{category}")]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllAsync()
    {
        await _categoryService.GetAllAsync();
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles ="Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }
}
