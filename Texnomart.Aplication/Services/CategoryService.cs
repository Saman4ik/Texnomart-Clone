﻿using FluentValidation;
using System.Net;
using Texnomart.Aplication.Common.Exceptions;
using Texnomart.Aplication.Common.Validators;
using Texnomart.Aplication.DTOs.CategoryDTOs;
using Texnomart.Aplication.Interfaces;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;
using Texnomart.Domain.Enums;
namespace Texnomart.Aplication.Services;

public class CategoryService(IUnitOfWork unitOfWork,
                          IValidator<Category> validator) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Category> _validator = validator;
     public async Task CreateAsync(AddCategoryDto dto)
    {
        var category = await _unitOfWork.Category.IsCategoryExistsAsync(dto.Name);
        if (!category)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "This category already exists!");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Category.CreateAsync((Category)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category not found");

        await _unitOfWork.Category.DeleteAsync(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync();
        return categories.Select(x => (CategoryDto)x).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category with this is not found");

        return (CategoryDto)category;
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(dto.Id);
        if (category is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Category not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Category.UpdateAsync(category);
    }
}
