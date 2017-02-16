using System;
using System.Collections;
using System.Collections.Generic;
using Ldme.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ldme.API.host.RequestHandling
{
    public class ErrorDto : IEnumerable<ErrorModel>
    {
        private readonly List<ErrorModel> Errors = new List<ErrorModel>();

        public ErrorDto(params ErrorModel[] errors)
        {
            Errors.AddRange(errors);
        }

        public ErrorDto(Exception exception)
        {
            Errors.Add(new ErrorModel(exception.Message));
        }

        public ErrorDto(string message, string code = null)
        {
            Errors.Add(new ErrorModel(message, code));
        }

        public ErrorDto(ModelStateDictionary modelState)
        {
            foreach (var error in modelState)
            {
                foreach (var valueError in error.Value.Errors)
                {
                    Errors.Add(new ErrorModel(valueError.ErrorMessage, error.Key));
                }
            }
        }

        public ErrorDto(IdentityResult modelState)
        {
            foreach (var error in modelState.Errors)
            {
                Errors.Add(new ErrorModel(error.Description, error.Code));
            }
        }

        public ErrorDto(ErrorKey key)
        {
            Errors.Add(new ErrorModel(key.Message, key.Code));
        }

        public IEnumerator<ErrorModel> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
