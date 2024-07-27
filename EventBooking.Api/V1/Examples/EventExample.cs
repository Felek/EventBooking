using EventBooking.Api.V1.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace EventBooking.Api.V1.Examples
{
    public class EventExample : IExamplesProvider<EventDto>
    {
        public EventDto GetExamples()
        {
            EventDto dto = new()
            {
                Id = 123,
                Name = "Hitchhiking - lecture by Douglas Adams",
                Country = "Poland",
                Description = "So long, so long, so long, so long, so long,\r\nSo long, so long, so long, so long, so long" +
                                ",\r\nSo long and thanks\r\nFor all the fish\r\n\r\n",
                Seats = 50,
                StartDate = DateTime.Now.AddDays(3)
            };
            return dto;
        }
    }
}
