using System.Runtime.Serialization;

namespace Logica
{
    [Serializable]
    public class RolNoCompatibleExcepcion : Exception
    {
        public RolNoCompatibleExcepcion()
        {
        }

        public RolNoCompatibleExcepcion(string? message) : base(message)
        {
        }

        public RolNoCompatibleExcepcion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RolNoCompatibleExcepcion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}