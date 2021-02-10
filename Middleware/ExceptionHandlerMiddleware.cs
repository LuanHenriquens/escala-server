using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using escala_server.Middleware.Exceptions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace escala_server.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                // var response = context.Response;
                // response.ContentType = "application/json";

                // switch(ex)
                // {
                //     case NotFoundException e:
                //         response.StatusCode = (int)HttpStatusCode.NotFound;
                //         break;
                //     case BusinessException e:
                //         response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                //         break;
                //     case TokenNotInformated e:
                //         response.StatusCode = (int)HttpStatusCode.BadRequest;
                //         break;
                //     case ValidationException e:
                //         response.StatusCode = (int)HttpStatusCode.BadRequest;
                //         break;
                //     case ForbiddenException e:
                //         response.StatusCode = (int)HttpStatusCode.Forbidden;
                //         break;
                //     case ListStringException e:
                //         response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                //         break;
                //     case AlreadyExistsException e:
                //         response.StatusCode = (int)HttpStatusCode.Conflict;
                //         break;
                //     default:
                //         // unhandled error
                //         response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //         break;
                // }

                // var result = JsonSerializer.Serialize(new { message = ex?.Message });
                // await response.WriteAsync(result);
            }
        }
        
        private static async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error switch
                {
                    NotFoundException e => (int) HttpStatusCode.NotFound,
                    BusinessException e => (int) HttpStatusCode.UnprocessableEntity,
                    TokenNotInformated e => (int) HttpStatusCode.BadRequest,
                    ValidationException e => (int) HttpStatusCode.BadRequest,
                    ForbiddenException e => (int) HttpStatusCode.Forbidden,
                    ListStringException e => (int) HttpStatusCode.UnprocessableEntity,
                    AlreadyExistsException e => (int) HttpStatusCode.Conflict,
                    _ => (int) HttpStatusCode.InternalServerError
                };
            
            var lstStringExption = new ListStringException();

            if (typeof(ListStringException) == error.GetType())
                lstStringExption = (ListStringException) error;
            
            var result = JsonSerializer.Serialize(new
            {
                message = (lstStringExption.TaskExceptions.Any()) ? "Houve um erro." : error?.Message,
                errors = lstStringExption.TaskExceptions.Select(c => c.Message.ToString())
            });
            
            await context.Response.WriteAsync(result);
        }
    }
}