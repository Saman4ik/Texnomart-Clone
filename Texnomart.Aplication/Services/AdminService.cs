using FluentValidation;
using System.Net;
using Texnomart.Aplication.Common.Exceptions;
using Texnomart.Aplication.Interfaces;
using Texnomart.Data.Interfaces;
using Texnomart.Domain.Entities;
using Texnomart.Domain.Enums;

namespace Texnomart.Aplication.Services;

public class AdminService(IUnitOfWork work,
                          IValidator<User> validator) : IAdminService
{
    private readonly IUnitOfWork _work = work;
    private readonly IValidator<User> _validator = validator;

    public async Task ChangeUserRoleAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        if (user.Role == Role.SupperAdmin)
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Jinnilik qilma!");

        user.Role = user.Role == Role.Admin ? Role.User : Role.Admin;

        await _work.User.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _work.User.GetByIdAsync(id);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");

        await _work.User.DeleteAsync(user);
    }

    public async Task<List<User>> GetAllAdminAsync()
        => (await _work.User.GetAllAsync())
            .Where(p => p.Role == Role.Admin)
            .ToList();
}
