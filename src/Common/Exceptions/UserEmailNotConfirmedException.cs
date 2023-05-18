using System.Runtime.Serialization;
using Common.Exceptions.Base;

namespace Common.Exceptions
{
    public class UserEmailNotConfirmedException : ConditionsNotProvidedException
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