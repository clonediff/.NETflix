using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Shared;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        /*
           Возможно тут нужно будет сделать обработку ошибок, возникающих при oauth => свой кастомный Exception
        */
        catch (Exception ex)
        {
            await HandleExceptionAsync(context,
                exception: ex,
                statusCode: HttpStatusCode.InternalServerError,
                type: "Server error",
                title: ex.Message);
        }
    }

    private async Task HandleExceptionAsync(HttpContext ctx,
        Exception exception,
        HttpStatusCode statusCode,
        string type,
        string title)
    {
        _logger.LogError(exception, "Ex message: {exception.Message}", exception.Message);

        var response = ctx.Response;
        response.StatusCode = (int)statusCode;
        response.ContentType = "application/json";

        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Type = type,
            Title = title,
            Detail = exception.Message
        };

        try
        {
            await JsonSerializer.SerializeAsync(response.Body, problemDetails);
        }
        catch (OperationCanceledException) { }
    }
}