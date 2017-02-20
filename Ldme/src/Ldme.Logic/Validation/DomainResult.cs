using System.Collections.Generic;
using System.Linq;
using Ldme.Logic.Validation.ErrorModels;
using Ldme.Models;

namespace Ldme.Logic.Validation
{
    public class DomainResult<T> : IDomainResult where T: class
    {
        public T Entity { get; set; }

        public List<IErrorModel> Errors { get; set; } = new List<IErrorModel>();

        public bool Valid => !Invalid;

        public bool Invalid => Errors.Any();
    }
}
