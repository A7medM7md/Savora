using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Common.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Shared.Common.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Response<string> responseModel;

                // Use Logger
                _logger.LogError(error,
                    "An unhandled exception occurred while processing request {Method} {Url}",
                    context.Request.Method,
                    context.Request.Path);

                //TODO:: cover all validation errors
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        // custom application error
                        responseModel = Response<string>.Fail(
                            e.Message,
                            HttpStatusCode.Unauthorized
                        );
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;

                    case ValidationException e:
                        // custom validation error
                        responseModel = Response<string>.Fail(
                            e.Message,
                            HttpStatusCode.UnprocessableEntity
                        );
                        response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        responseModel = Response<string>.Fail(
                            e.Message,
                            HttpStatusCode.NotFound
                        );
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;

                    case DbUpdateException e:
                        // can't update error
                        responseModel = Response<string>.Fail(
                            e.Message,
                            HttpStatusCode.BadRequest
                        );
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    default:
                        // generic unhandled exception
                        var msg = error.Message + (error.InnerException != null ? "\n" + error.InnerException.Message : "");
                        responseModel = Response<string>.Fail(
                            msg,
                            HttpStatusCode.InternalServerError
                        );
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }

}
