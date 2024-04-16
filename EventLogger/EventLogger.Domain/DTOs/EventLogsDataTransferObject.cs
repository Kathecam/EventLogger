using EventLogger.EventLogger.Domain.Enum;

namespace EventLogger.Domain.DTOs
{
    public class EventLogsDataTransferObject
    {
        public int EventLogId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public TypeEvent TypeEvent { get; set; }
    }

}