using EventLogger.EventLogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventLogger.Infrastructure
{
    public class EventLoggerDbContext : DbContext
    {
#nullable disable
        public EventLoggerDbContext(DbContextOptions<EventLoggerDbContext> options) : base(options) { }
        public DbSet<EventLog> EventLoggers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>().ToTable("EventLog");
            modelBuilder.Entity<EventLog>().HasKey(x => x.EventLogId);
            modelBuilder.Entity<EventLog>().Property(x => x.EventLogId).ValueGeneratedOnAdd();

        }
    }
}