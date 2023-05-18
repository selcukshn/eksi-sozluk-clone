using System.Runtime.Serialization;
using Common.Exceptions.Base;

namespace Common.Exceptions
{
    public class UserEmailAlreadyExist : AlreadyExistException
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