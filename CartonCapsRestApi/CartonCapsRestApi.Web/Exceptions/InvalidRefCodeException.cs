using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Exceptions {
    public class InvalidRefCodeException : Exception
    {
        public InvalidRefCodeException()
        {
        }

        public InvalidRefCodeException(string? message) : base(message)
        {
        }
    }
}