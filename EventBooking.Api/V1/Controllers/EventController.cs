using AutoMapper;
using EventBooking.DataAccess.Entities;
using EventBooking.Api.V1.Dto;
using EventBooking.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace EventBooking.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ApiController]
    [Route("v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(ILogger<EventController> logger, IEventRepository eventRepository, IMapper mapper)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "events")]
        [SwaggerResponseExample(200, typeof(AllEventsExample))]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), 200)]
        //[SwaggerResponseExample(404, typeof(ErrorDtoExample))]
        //[ProducesResponseType(typeof(ErrorDto), 404)]
        public async Task<IEnumerable<EventDto>> GetAll([FromQuery] string country)
        {
            List<Event> events = null;
            if (string.IsNullOrWhiteSpace(country))
                events = (await _eventRepository.GetAllEvents()).ToList();
            else
                events = (await _eventRepository.GetEventsByCountry(country)).ToList();

            return _mapper.Map<List<EventDto>>(events);
        }
    }
}
