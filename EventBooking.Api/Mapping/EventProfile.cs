using AutoMapper;
using EventBooking.DataAccess.Entities;
using EventBooking.Api.V1.Dto;

namespace EventBooking.Api.Mapping
{
    public class EventProfile : Profile
    {
        public EventProfile() 
        {
            CreateMap<Event, EventDto>();
        }
    }
}
