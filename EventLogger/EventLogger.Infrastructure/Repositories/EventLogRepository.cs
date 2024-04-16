using EventLogger.EventLogger.Domain.Entities;
using EventLogger.Domain.IRepositories;
using EventLogger.EventLogger.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace EventLogger.Infrastructure.Repositories
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly EventLoggerDbContext _dbContext;
        public EventLogRepository(EventLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEventLog(EventLog eventLog)
        {
            _dbContext.EventLoggers.Add(eventLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EventLog> GetEventLogById(int eventLogId)
        {
            return await _dbContext
            .EventLoggers
            .SingleAsync(e => e.EventLogId == eventLogId);
        }

        public async Task<IEnumerable<EventLog>> GetAllEventsLog()
        {
            return await _dbContext.EventLoggers.ToListAsync();
        }

        public async Task<IEnumerable<EventLog>> GetEventLogsByType(TypeEvent eventLogType)
        {
            return await _dbContext.EventLoggers.Where(e => e.TypeEvent == eventLogType).ToListAsync();
        }

        public async Task<IEnumerable<EventLog>> GetEventLogsByDate(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.EventLoggers.Where(e => e.DateTime >= startDate && e.DateTime <= endDate).ToListAsync();
        }
    }
}