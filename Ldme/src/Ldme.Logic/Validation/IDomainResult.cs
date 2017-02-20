using System.Collections.Generic;
using Ldme.Logic.Validation.ErrorModels;

namespace Ldme.Logic.Validation
{
    public interface IDomainResult
    {
        List<IErrorModel> Errors { get; set; }

        bool Valid { get; }

        bool Invalid { get; }
    }
}
