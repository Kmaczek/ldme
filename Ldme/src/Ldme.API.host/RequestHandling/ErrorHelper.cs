using System;
using Ldme.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ldme.API.host.RequestHandling
{
    public static class ErrorHelper
    {
        public static IActionResult HandleErrors(this Controller ctrl, Exception exception)
        {
            //TODO: if DEV then throw detailed exceptions
            if (exception is ResourceNotFoundException)
            {
                return ctrl.StatusCode(StatusCodes.Status404NotFound, new ErrorDto(exception.Message));
            }

            return ctrl.StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto(exception.Message));
        }

        public static IActionResult Unauthorized(this Controller ctrl, ErrorKey key)
        {
            var result = ctrl.StatusCode(StatusCodes.Status401Unauthorized, new ErrorDto(key));
            return result;
        }
    }
}
