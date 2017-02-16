namespace Ldme.API.host.RequestHandling
{
    public static class ErrorStore
    {
        public static readonly ErrorKey UnauthorizedLoginFailed = new ErrorKey()
        {
            Code = "Unauthorized",
            Message = "Login failed. Incorrect username/email or password"
        };
    }

    public class ErrorKey
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}
