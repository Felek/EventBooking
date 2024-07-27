using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Api.V1.Dto
{
    public class EventDto : BaseReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Seats { get; set; }
    }
}
