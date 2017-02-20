namespace Ldme.Logic.Validation.ErrorModels
{
    public class ErrorModel:IErrorModel
    {
        public ErrorModel(string description, string code = null)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}
