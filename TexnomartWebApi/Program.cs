using Serilog;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Texnomart.Aplication.Interfaces;
using Texnomart.Aplication.Services;
using Texnomart.Data.DbContextt;
using Texnomart.Data.Interfaces;
using Texnomart.Data.Repositories;
using Texnomart.Domain.Entities;
using MovieNTV.Configurations;
using Texnomart.Aplication.Common.Validators;
using MovieNTV.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cache
builder.Services.AddMemoryCache();

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

// Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Unit Of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Service
builder.Services.AddTransient<IAccauntService, AccountService>();
builder.Services.AddTransient<IAuthMenager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAdminService, AdminService>();

// Configure
builder.Services.ConfigureJwtAuthorize(builder.Configuration);
builder.Services.ConfigureSwaggerAuthorize(builder.Configuration);

//Validator
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandleMiddleware>();

app.Run();
