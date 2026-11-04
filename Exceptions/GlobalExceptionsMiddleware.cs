using System.Text.Json;

namespace Prestamos_Backend.Exceptions;

public class GlobalExceptionsMiddleware(RequestDelegate next)
{
    public readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
          
          var statusCode = exception switch {
      NotFoundException => StatusCodes.Status404NotFound,
      BadRequestException => StatusCodes.Status400BadRequest,
      ConflicException => StatusCodes.Status409Conflict,
      ForbiddenException => StatusCodes.Status403Forbidden,
      UnauthorizedException => StatusCodes.Status401Unauthorized,

      _ => StatusCodes.Status500InternalServerError
    };

    context.Response.StatusCode = statusCode;

    var response = new {
      status = statusCode,
      message = exception.Message
    };

         await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}