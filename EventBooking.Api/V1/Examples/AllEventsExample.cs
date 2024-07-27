using EventBooking.Api.V1.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace EventBooking.Api.V1.Examples
{
    public class AllEventsExample : IExamplesProvider<List<EventDto>>
    {
        public List<EventDto> GetExamples()
        {
            List<EventDto> dtos =
            [
                new EventDto
                {
                    Id = 123,
                    Name = "Hitchhiking - lecture by Douglas Adams",
                    Country = "Poland",
                    Description = "So long, so long, so long, so long, so long,\r\nSo long, so long, so long, so long, so long" +
                                  ",\r\nSo long and thanks\r\nFor all the fish\r\n\r\n",
                    Seats = 50,
                    StartDate = DateTime.Now.AddDays(3)
                },
                new EventDto
                {
                    Id = 123,
                    Name = "How to invent strange title of event - exercises",
                    Country = "East Timor",
                    Description = "Sometimes description is just not needed",
                    Seats = 100,
                    StartDate = DateTime.Now.AddDays(13)
                }
            ];
            return dtos;
        }

    }
}
