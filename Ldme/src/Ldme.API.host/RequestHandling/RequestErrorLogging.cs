using System;
using Ldme.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.RequestHandling
{
    public static class RequestErrorLogging
    {
        public static void LogExceptions<T>(this ILogger<T> logger, Exception exception, Controller controller)
        {
            var path = controller.Request.Path;

            if (exception is ResourceNotFoundException)
            {
                logger.LogError(LdmeLogEvents.ResourceNotFound, exception, $"No resource under path: {path}");
            }

            logger.LogError(LdmeLogEvents.Unknown, exception, $"Unspecified error in: {path}");
        }
    }
}
