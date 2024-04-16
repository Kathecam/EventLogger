using AutoMapper;
using EventLogger.Domain.DTOs;
using EventLogger.EventLogger.Domain.DTOs;
using EventLogger.EventLogger.Domain.Entities;

namespace EventLogger.EventLogger.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEventLogsDataTransferObject, EventLog>();
        }
    }
}