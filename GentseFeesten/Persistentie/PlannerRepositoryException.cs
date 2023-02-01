using System.Runtime.Serialization;

namespace Persistentie
{
    [Serializable]
    internal class PlannerRepositoryException : Exception
    {
        public PlannerRepositoryException(){}

        public PlannerRepositoryException(string? message) : base(message){}

        public PlannerRepositoryException(string? message, Exception? innerException) : base(message, innerException){}

        protected PlannerRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}