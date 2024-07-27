using AutoMapper;
using EventBooking.DataAccess.Entities;
using EventBooking.Api.V1.Dto;
using EventBooking.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Asp.Versioning;

namespace EventBooking.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(ILogger<EventsController> logger, IEventRepository eventRepository, IMapper mapper)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventBasicDto>>> GetAll([FromQuery] string country)
        {
            List<Event> events = null;
            if (string.IsNullOrWhiteSpace(country))
                events = (await _eventRepository.GetAll()).ToList();
            else
                events = (await _eventRepository.GetByCountry(country)).ToList();

            return _mapper.Map<List<EventBasicDto>>(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDto>> Get(int id)
        {
            var eventEntity = await _eventRepository.Get(id);

            return Ok(_mapper.Map<EventDto>(eventEntity));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(AddEventDto eventDto)
        {
            //could consider use of idempotency-key here

            var eventEntity = _mapper.Map<Event>(eventDto);
            //lacking validations here
            _eventRepository.Add(eventEntity);
            await _eventRepository.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = eventEntity.Id }, eventEntity);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.Get(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            _eventRepository.Delete(eventEntity);
            await _eventRepository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Event>> Update(EventDto eventDto)
        {
            var eventEntity = _mapper.Map<Event>(eventDto);
            _eventRepository.Update(eventEntity);
            await _eventRepository.SaveChanges();

            return NoContent();
        }
    }
}
