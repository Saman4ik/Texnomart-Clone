﻿using Texnomart.Aplication.DTOs.CategoryDTOs;

namespace Texnomart.Aplication.Interfaces;

public interface ICategoryService
{
    Task CreateAsync(AddCategoryDto dto);
    Task UpdateAsync(CategoryDto dto);
    Task DeleteAsync(int id);
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<IEnumerable<CategoryDto>> GetAllAsync();
}
