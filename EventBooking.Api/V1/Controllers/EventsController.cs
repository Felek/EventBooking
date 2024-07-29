using AutoMapper;
using EventBooking.DataAccess.Entities;
using EventBooking.Api.V1.Dto;
using EventBooking.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Asp.Versioning;
using EventBooking.Api.Utils;

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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EventsController(ILogger<EventsController> logger, 
                                IEventRepository eventRepository, 
                                IUserRepository userRepository,
                                IMapper mapper)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventBasicDto>>> GetAll([FromQuery] string? country)
        {
            List<Event> events = null;
            if (string.IsNullOrWhiteSpace(country))
                events = (await _eventRepository.GetAll()).ToList();
            else
                events = (await _eventRepository.GetByCountry(country)).ToList();

            var dtos = _mapper.Map<List<EventBasicDto>>(events);

            //I know, I'm a try hard with that HATEOAS here. For that I decided to add id to that dto as well,
            //even if not mentioned in doc - erroneously I believe
            dtos.ForEach(e => e.Links = LinksGenerator.CreateLinks(HttpContext.Request.Host.Value, "events", e.Id));
            return dtos;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventDto>> Get(int id)
        {
            var eventEntity = await _eventRepository.Get(id);

            if (eventEntity == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<EventDto>(eventEntity);
            dto.Links = LinksGenerator.CreateLinks(HttpContext.Request.Host.Value, "events", id);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(AddOrUpdateEventDto eventDto)
        {
            //could consider use of idempotency-key here

            var eventEntity = _mapper.Map<Event>(eventDto);
            //lacking validations here
            _eventRepository.Add(eventEntity);
            await _eventRepository.SaveChanges();

            var dto = _mapper.Map<EventDto>(eventEntity);
            dto.Links = LinksGenerator.CreateLinks(HttpContext.Request.Host.Value, "events", eventEntity.Id);
            return CreatedAtAction(nameof(Get), new { id = eventEntity.Id }, dto);
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
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Event>> Update(int id, AddOrUpdateEventDto eventDto)
        {
            var eventEntity = _mapper.Map<Event>(eventDto);
            eventEntity.Id = id;
            _eventRepository.Update(eventEntity);
            await _eventRepository.SaveChanges();

            return NoContent();
        }

        //PUT, as this can be used idempotently
        [HttpPut("{id}/register")]
        [ProducesResponseType(typeof(EventDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Event>> Register(int id, RegisterDto eventDto)
        {
            var eventEntity = await _eventRepository.Get(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            //just commenting: here I would check if email is valid, Regex
            if (false)
            {
                return BadRequest("Email address is invalid");
            }

            var user = await _userRepository.GetByEmail(eventDto.Email);
            if (user is null)
            {
                user = new User { Email = eventDto.Email.ToLower() };
            }

            if (!eventEntity.Users.Any(u => u.Id == user.Id))
            {
                eventEntity.Users.Add(user);
                await _eventRepository.SaveChanges();
            }

            return NoContent();
        }
    }
}
