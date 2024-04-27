using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Texnomart.Aplication.Common.Exceptions;
using Texnomart.Aplication.Common.Validators;
using Texnomart.Aplication.DTOs.ProductDto;
using Texnomart.Aplication.DTOs.UserDTOs;
using Texnomart.Aplication.Interfaces;
using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Services;

public class ProductService(IUnitOfWork unitOfWork,
                          IValidator<Product> validator)
                           : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Product> _validator = validator;

    public async Task CreateAsync(AddProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Dto can not be null");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Product.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);
        if (product is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Product with this id not found");

        await _unitOfWork.Product.DeleteAsync(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Product.GetAllAsync();
        return products.Select(x => (ProductDto)x).ToList();
    }
    public async Task<ProductDto?> GetByIdAsync(int id)
        => await _unitOfWork.Product.GetByIdAsync(id);

    public async Task<ProductDto> GetByNameAsync(string name)
        => await _unitOfWork.Product.GetByNameAsync(name);
    public async Task UpdateAsync(ProductDto dto)
    {
        if (dto is null)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Dto cannot be null");

        var existingProduct = await _unitOfWork.Product.GetByIdAsync(dto.Id);
        if (existingProduct is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Product not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;
        await _unitOfWork.Product.UpdateAsync(existingProduct);
    }
}
