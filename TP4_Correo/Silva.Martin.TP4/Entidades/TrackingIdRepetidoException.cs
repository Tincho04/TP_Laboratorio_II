using System;

namespace Entidades
{
    /// <summary>
    /// Excepción para el caso de que dos Tracking ID coincidan.
    /// </summary>
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
        }
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}