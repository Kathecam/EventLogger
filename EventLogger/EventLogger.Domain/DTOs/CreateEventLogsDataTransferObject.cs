using System.ComponentModel.DataAnnotations;
using EventLogger.EventLogger.Domain.Enum;

namespace EventLogger.EventLogger.Domain.DTOs
{
    public class CreateEventLogsDataTransferObject
    {
        public int EventLogId { get; set; }
        [Required]

        public DateTime DateTime { get; set; }
        [Required]
        public string Description { get; set; }=string.Empty;
        [Required]
        public TypeEvent TypeEvent { get; set; }
    }
}