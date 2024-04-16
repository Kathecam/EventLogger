using AutoMapper;
using EventLogger.EventLogger.Domain.Entities;
using EventLogger.Domain.IRepositories;
using EventLogger.EventLogger.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using EventLogger.EventLogger.Domain.DTOs;

namespace EventLogger.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogsController : ControllerBase
    {
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IMapper _mapper;
        public EventLogsController(IEventLogRepository eventLogRepository, IMapper mapper)
        {
            _eventLogRepository = eventLogRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetAllEventsLogs()
        {
            return Ok(await _eventLogRepository.GetAllEventsLog());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventLog>> GetEventLogById(int id)
        {
            return Ok(await _eventLogRepository.GetEventLogById(id));
        }

        [HttpGet("by-event-type/{eventLogType}")]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetEventLogByType( TypeEvent eventLogType)
        {
            return Ok(await _eventLogRepository.GetEventLogsByType(eventLogType));
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetEventLogByDate(DateTime startDate, DateTime endDate)
        {
            var eventResponse = await _eventLogRepository.GetEventLogsByDate(startDate, endDate);
            return eventResponse == null ? NotFound() : Ok(eventResponse);
        }

        [HttpPost]
        public IActionResult PostEventLog([FromBody] CreateEventLogsDataTransferObject createEventLogsDataTransferObject)
        {
            var eventresponse= _eventLogRepository.AddEventLog(_mapper.Map<EventLog>(createEventLogsDataTransferObject));
            return eventresponse == null ? NotFound() : Ok(eventresponse);
        }
    }
}