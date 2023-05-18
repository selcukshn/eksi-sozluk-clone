using System.Runtime.Serialization;
using Common.Exceptions.Base;

namespace Common.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}