using EventLogger.EventLogger.Domain.Entities;
using EventLogger.EventLogger.Domain.Enum;

namespace EventLogger.Domain.IRepositories
{
    public interface IEventLogRepository
    {
        Task AddEventLog(EventLog eventLog);
        Task<EventLog> GetEventLogById(int eventLogId);
        Task<IEnumerable<EventLog>> GetAllEventsLog();

        Task<IEnumerable<EventLog>> GetEventLogsByType(TypeEvent eventLogType);
        Task<IEnumerable<EventLog>> GetEventLogsByDate(DateTime startDate, DateTime endDate);
    }
}