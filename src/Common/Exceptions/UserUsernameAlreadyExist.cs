using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class UserUsernameAlreadyExist : Exception
    {
        public UserUsernameAlreadyExist()
        {
        }

        public UserUsernameAlreadyExist(string? message) : base(message)
        {
        }

        public UserUsernameAlreadyExist(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserUsernameAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}