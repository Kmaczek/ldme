﻿using System;
using System.Collections;
using System.Collections.Generic;
using Ldme.Logic.Validation;
using Ldme.Logic.Validation.ErrorModels;
using Ldme.Models;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ldme.API.host.RequestHandling
{
    public class ErrorDto : IEnumerable<IErrorModel>
    {
        private readonly List<IErrorModel> Errors = new List<IErrorModel>();

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

        public ErrorDto(IDomainResult result)
        {
            Errors.AddRange(result.Errors);
        }

        public IEnumerator<IErrorModel> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
