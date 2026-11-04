using Prestamos_Backend.Module.Auth.Repository;
using Prestamos_Backend.Module.Auth.Dtos;
using Prestamos_Backend.Module.Auth.Entities;
using Prestamos_Backend.Exceptions;

namespace Prestamos_Backend.Module.Auth.Services;


public class AuthServices(AuthRepository authRepository, JwtServices jwtServices)
{
    private readonly AuthRepository _authRepository = authRepository;
    private readonly JwtServices _jwtServices = jwtServices;


    public void Register (RegisterRequestDtos registerRequestDtos)
    {
        if (registerRequestDtos.Password != registerRequestDtos.ConfirmPassword)
        {
            throw new Exception("Las contraseñas no coinciden");
        }

        bool isEmailRegistered = _authRepository.ConfirmEmail(registerRequestDtos.Email);  

        if (isEmailRegistered)
        {
            throw new BadRequestException("El correo electrónico ya está registrado");
        }

        var user = new User
        {
            Uuid = Guid.NewGuid(),
            Nombre = registerRequestDtos.Nombre,
            Apellido = registerRequestDtos.Apellido,
            Cedula = registerRequestDtos.Cedula,
            Telefono = registerRequestDtos.Telefono,
            Email = registerRequestDtos.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerRequestDtos.Password),
        };
        
        _authRepository.Register(user);
        
    }

    public bool ConfirmEmail(string email)
    {
        return _authRepository.ConfirmEmail(email);
    }
    
    public LoginResponseDtos Login(LoginRequestDtos loginRequestDtos)
    {
        var user = _authRepository.FindOneByEmail(loginRequestDtos.Email) 
                   ?? throw new Exception("Usuario no encontrado");

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginRequestDtos.Password, user.Password);

        if (!isPasswordValid)
        {
            throw new UnauthorizedException("Contraseña o correo electrónico incorrectos");
        }

        var token = _jwtServices.GenerateToken(user);

        return new LoginResponseDtos
        {
            Token = token
        };
    }
}