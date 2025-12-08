using FluentValidation;

namespace LoanTrack.WebAPI.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                });

                await context.Response.WriteAsJsonAsync(errors);
            }
        }
    }
}
