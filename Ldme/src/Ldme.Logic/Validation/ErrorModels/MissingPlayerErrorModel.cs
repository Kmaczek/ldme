namespace Ldme.Logic.Validation.ErrorModels
{
    public class MissingPlayerErrorModel : IErrorModel
    {
        public MissingPlayerErrorModel(int id)
        {
            this.Code = "MissingPlayer";
            this.Description = $"Can not find player with id [{id}]";
        }
    }
}
