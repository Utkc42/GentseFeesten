using System.Runtime.Serialization;

namespace Persistentie
{
    [Serializable]
    internal class EvenementRepositoryException : Exception
    {
        public EvenementRepositoryException()
        {
        }

        public EvenementRepositoryException(string? message) : base(message)
        {
        }

        public EvenementRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EvenementRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}