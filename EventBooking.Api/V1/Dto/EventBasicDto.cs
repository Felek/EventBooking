using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Api.V1.Dto
{
    public class EventBasicDto : BaseReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }
        public DateTime StartDate { get; set; }
    }
}
