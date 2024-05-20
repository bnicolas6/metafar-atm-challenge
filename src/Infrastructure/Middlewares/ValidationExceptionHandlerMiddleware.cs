using FluentValidation;
using Metafar.ATM.Challenge.Common.Http.Response;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Metafar.ATM.Challenge.Infrastructure.Middlewares
{
    public class ValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandlerMiddleware(RequestDelegate next)
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
                var response = ex.Errors.Select(error => new ATMError
                {
                    PropertyName = error.PropertyName,
                    Message = error.ErrorMessage
                }).ToList();

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
