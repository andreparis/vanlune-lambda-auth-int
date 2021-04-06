namespace Auth.Int.Domain.Validation
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException() : base("Unauthorized")
        {
        }
    }
}
