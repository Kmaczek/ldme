using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ldme.API.host.RequestHandling
{
    public static class ErrorHelper
    {
        public static IActionResult HandleErrors(this Controller ctrl, Exception exception)
        {
            return ctrl.StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto(exception.Message));
        }

        public static IActionResult Unauthorized(this Controller ctrl, ErrorKey key)
        {
            var result = ctrl.StatusCode(StatusCodes.Status401Unauthorized, new ErrorDto(key));
            return result;
        }
    }
}
