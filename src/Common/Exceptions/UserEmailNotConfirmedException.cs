using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class UserEmailNotConfirmedException : Exception
    {
        public UserEmailNotConfirmedException()
        {
        }

        public UserEmailNotConfirmedException(string? message) : base(message)
        {
        }

        public UserEmailNotConfirmedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserEmailNotConfirmedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}