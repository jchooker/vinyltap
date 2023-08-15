namespace VinylTap.Helpers;

using System.Net;
using System.Text.Json;
using Azure.Core;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception err)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch(err)
            {
                case AppException e:
                    //custom app error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new {message = err?.Message});
            await response.WriteAsync(result);
        }
    }
}