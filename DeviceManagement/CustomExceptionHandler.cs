
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http.Filters;

namespace DeviceManagement
{

    /// <summary>  
    /// This class is used to handle the custom exception in the application level.  
    /// </summary>
    public class CustomExceptionFilter : FilterAttribute, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    {/// <summary>  
     /// This method will automatically trigger when any exception occurs in application level.  
     /// </summary>  
     /// <param name="context"></param>  
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = "Error occurred while processing";

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                response.Headers.Remove("TokenExpired");
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            //else if (exceptionType == typeof(CustomException))
            //{
            //    message = context.Exception.ToString();
            //    status = HttpStatusCode.InternalServerError;
            //}
            // TODO : NEED TO DO LOCALISATION
            else if (exceptionType == typeof(FluentValidation.ValidationException))
            {
                var exceptions = context.Exception as FluentValidation.ValidationException;
                message = string.Join(",", exceptions.Errors.ToList().Select(e => $"{e.ErrorMessage } {Environment.NewLine}"));
                status = HttpStatusCode.InternalServerError;
            }
            else if (exceptionType == typeof(System.ComponentModel.DataAnnotations.ValidationException))
            {
                var exceptions = context.Exception as System.ComponentModel.DataAnnotations.ValidationException;
                message = exceptions.Message;
                status = HttpStatusCode.InternalServerError;
            }
            //else if (exceptionType == typeof(LdapException))
            //{
            //    message = "Invalid Credentials";
            //    status = HttpStatusCode.Unauthorized;
            //}
            else if (exceptionType == typeof(SecurityTokenExpiredException))
            {
                response.Headers.Add("TokenExpired", "true");
                message = "Token expired";
                status = HttpStatusCode.Unauthorized;
            }
            context.ExceptionHandled = true;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            response.WriteAsync(message);
        }
    }
}
