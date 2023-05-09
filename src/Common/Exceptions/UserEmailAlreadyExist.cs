using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class UserEmailAlreadyExist : Exception
    {
        public UserEmailAlreadyExist()
        {
        }

        public UserEmailAlreadyExist(string? message) : base(message)
        {
        }

        public UserEmailAlreadyExist(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserEmailAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}