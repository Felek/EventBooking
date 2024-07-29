using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Api.V1.Dto
{
    public class AddOrUpdateEventDto
    {
        /// <summary>
        /// Name of event
        /// </summary>
        /// <example>Hitchhiking - lecture by Douglas Adams</example>
        public required string Name { get; set; }

        /// <summary>
        /// Country where event is going to happen
        /// </summary>
        /// <example>Poland</example>
        public required string Country { get; set; }

        /// <summary>
        /// Long and boring description
        /// </summary>
        /// <example>So long, so long, so long, so long, so long,\r\nSo long, so long, so long, so long, so long\r\nSo long and thanks\r\nFor all the fish\r\n\r\n</example>
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Number of seats
        /// </summary>
        /// <example>100</example>
        public int Seats { get; set; }
    }
}
