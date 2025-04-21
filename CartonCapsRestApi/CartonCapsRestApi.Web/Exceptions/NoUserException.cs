using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Exceptions {
    public class NoUserException : Exception
    {
        public NoUserException()
        {
        }

        public NoUserException(string? message) : base(message)
        {
        }
    }
}