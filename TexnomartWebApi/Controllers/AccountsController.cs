﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Texnomart.Aplication.DTOs.UserDTOs;
using Texnomart.Aplication.Interfaces;

namespace MovieNTV.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccauntService accountService) : ControllerBase
{
    private readonly IAccauntService _accountService = accountService;

    [HttpPost("registr")]
    [AllowAnonymous]
    public async Task<IActionResult> RegistrAsync([FromForm] AddUserDto dto)
    {
        var result = await _accountService.RegistrAsync(dto);
        return Ok(result);
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }
    [HttpPost("sendcode")]
    public async Task<IActionResult> SendCodeAsync([FromForm]string email)
    {
        await _accountService.SendCodeAsync(email);
        return Ok();
    }
    [HttpPost("check")]
    public async Task<IActionResult> CheckCodeAsync([FromForm]string email, [FromForm]string code)
        => Ok(await _accountService.CheckCodeAsync(email, code));
}