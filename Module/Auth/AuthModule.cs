using Prestamos_Backend.Module.Auth.Repository;
using Prestamos_Backend.Module.Auth.Services;  
using Prestamos_Backend.Module.Auth.Controllers; 


namespace Prestamos_Backend.Module.Auth;

 public static class AuthModule
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddScoped<AuthRepository>();
        services.AddScoped<AuthServices>();
        services.AddScoped<JwtServices>();

        return services;
    }
}