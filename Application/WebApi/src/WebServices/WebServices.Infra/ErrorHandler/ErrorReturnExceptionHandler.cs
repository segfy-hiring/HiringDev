namespace WebServices.Infra.ErrorHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using WebServices.Infra.Exceptions;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// ErrorReturnExceptionHandler.
    /// </summary>
    internal class ErrorReturnExceptionHandler
    {
        /// <summary>
        /// ExceptionHandlerDelegate
        /// </summary>
        /// <param name="showDetailedError">showDetailedError</param>
        /// <returns>RequestDelegate</returns>
        public static RequestDelegate ExceptionHandlerDelegate(bool showDetailedError)
        {
            return async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                var statusCode = HttpStatusCode.InternalServerError;
                ErrorReturn error = new ErrorReturn(ErrorReturn.DefaultErrorMessage);

                IntegraException integraException = null;

                if (exceptionHandlerPathFeature.Error != null)
                {
                    if (exceptionHandlerPathFeature.Error is IntegraException)
                    {
                        integraException = exceptionHandlerPathFeature.Error as IntegraException;
                    }
                    else if (exceptionHandlerPathFeature.Error is AggregateException)
                    {
                        integraException = (exceptionHandlerPathFeature.Error as AggregateException).InnerExceptions.FirstOrDefault(t => t.GetType() == typeof(IntegraException)) as IntegraException;
                    }
                }

                if (integraException != null)
                {
                    statusCode = HttpStatusCode.BadRequest;
                    error = new ErrorReturn(integraException);
                }
                else
                {
                    if (showDetailedError)
                    {
                        if (exceptionHandlerPathFeature != null)
                        {
                            error.ValidationFields.Add("Message", new List<string> { exceptionHandlerPathFeature.Error.Message });
                            error.ValidationFields.Add("StackTrace", new List<string> { exceptionHandlerPathFeature.Error.StackTrace });
                        }
                    }
                }

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("access-control-expose-headers", "Application-Error");

                var result = JsonConvert.SerializeObject(error);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(result);
            };
        }
    }
}
