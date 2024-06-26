﻿using FluentValidation;
using System.Net;
using Texnomart.Aplication.Common.Exceptions;
using Texnomart.Aplication.Common.Validators;
using Texnomart.Aplication.DTOs.OrderDTOs;
using Texnomart.Aplication.Interfaces;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.Services;

public class OrderService(IUnitOfWork unitOfWork,
                          IValidator<Order> validator) 
                        : IOrderService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Order> _validator = validator;

    public async Task CreateAsync(AddOrderDto dto)
    {
        if (dto is null)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Dto can not be null!");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());

        await _unitOfWork.Order.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _unitOfWork.Order.GetByIdAsync(id);
        if (order is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Order with this id not found");

        await _unitOfWork.Order.DeleteAsync(order);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Order.GetAllAsync();
        return orders.Select(x => (OrderDto)x).ToList();
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        var order = await _unitOfWork.Order.GetByIdAsync(id);
        if (order is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Order with this id not found");

        return (OrderDto)order;
    }
}
