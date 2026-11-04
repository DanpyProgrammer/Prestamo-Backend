using Microsoft.AspNetCore.Mvc;
using Prestamos_Backend.Module.Auth.Services;
using Prestamos_Backend.Module.Auth.Dtos;

namespace Prestamos_Backend.Module.Auth.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(AuthServices authServices) : ControllerBase
{
    private readonly AuthServices _authServices = authServices;

    [HttpPost("register")]
    public IActionResult Register( RegisterRequestDtos registerRequestDtos)
    {
        _authServices.Register(registerRequestDtos);
        return Ok(new { message = "Usuario registrado exitosamente" });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDtos loginRequestDtos)
    {
        var response = _authServices.Login(loginRequestDtos);
        return Ok(response);
    }
}