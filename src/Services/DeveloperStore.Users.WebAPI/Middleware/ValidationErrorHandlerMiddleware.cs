using FluentValidation;
using System.Text.Json;

namespace DeveloperStore.Users.WebAPI.Middleware
{
    public class ValidationErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } 
            catch(ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    type = "ValidationError",
                    error = "Invalid input data",
                    details = string.Join(";", ex.Errors.Select(e => e.ErrorMessage))
                };

                var errorJson = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}
