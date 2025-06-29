﻿using Microsoft.Extensions.Hosting;
using Music.Core.Common;
using Music.Core.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HttpStatusCode status;
                string message;

                switch (ex)
                {
                    case NotFoundException:
                        status = HttpStatusCode.NotFound;
                        message = ex.Message;
                        break;
                    case BadRequestException:
                        status = HttpStatusCode.BadRequest;
                        message = ex.Message;
                        break;
                    default:
                        status = HttpStatusCode.InternalServerError;
                        message = "An unexpected error occurred.";
                        break;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)status;

                var result = _env.IsDevelopment() ? Result.Fail(context.Response.StatusCode, message, ex.StackTrace) 
                    : Result.Fail(context.Response.StatusCode, message, "Internal server error");


                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };


                var json = JsonSerializer.Serialize(result, options);
                await context.Response.WriteAsync(json);
            }
        }


    }
}
