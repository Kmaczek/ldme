using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ldme.Models.Errors
{
    public class ErrorMessage : IEnumerable<ErrorModel>
    {
        private readonly List<ErrorModel> Errors = new List<ErrorModel>();

        public ErrorMessage(params ErrorModel[] errors)
        {
            Errors.AddRange(errors);
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
