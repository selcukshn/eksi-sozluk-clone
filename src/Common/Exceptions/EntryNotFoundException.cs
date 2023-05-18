using System.Runtime.Serialization;
using Common.Exceptions.Base;

namespace Common.Exceptions
{
    public class EntryNotFoundException : NotFoundException
    {
        public EntryNotFoundException()
        {
        }

        public EntryNotFoundException(string? message) : base(message)
        {
        }

        public EntryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}