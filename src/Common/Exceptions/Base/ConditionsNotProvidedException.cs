using System.Runtime.Serialization;

namespace Common.Exceptions.Base
{
    public class ConditionsNotProvidedException : Exception
    {
        public ConditionsNotProvidedException()
        {
        }

        public ConditionsNotProvidedException(string? message) : base(message)
        {
        }

        public ConditionsNotProvidedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ConditionsNotProvidedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}