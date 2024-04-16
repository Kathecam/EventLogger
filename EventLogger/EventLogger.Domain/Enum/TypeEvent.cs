using System.Runtime.Serialization;

namespace EventLogger.EventLogger.Domain.Enum
{
    public enum TypeEvent
    {
        [EnumMember(Value = "Api")]
        Api, 
        [EnumMember(Value = "Formulario de Evento Manual")]
        ManualEvent, 
    }
}