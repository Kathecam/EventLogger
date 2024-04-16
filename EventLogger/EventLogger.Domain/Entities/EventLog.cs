using System.ComponentModel.DataAnnotations;
using EventLogger.EventLogger.Domain.Enum;

namespace EventLogger.EventLogger.Domain.Entities
{
    public class EventLog
    {
        [Key]
        public int EventLogId { get; set; }
        public DateTime DateTime { get; set;}
        public string? Description { get; set; }

        public TypeEvent TypeEvent { get; set; }

    }
}