using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Api.V1.Dto
{
    public class AddEventDto
    {
        /// <summary>
        /// Name of event
        /// </summary>
        /// <example>Hitchhiking - lecture by Douglas Adams</example>
        public required string Name { get; set; }

        /// <summary>
        /// Country where event is going to happen
        /// </summary>
        /// <example>732aa76f-6c9c-4598-adaf-775aef8a0f3d</example>
        public required string Country { get; set; }

        /// <summary>
        /// Long and boring description
        /// </summary>
        /// <example>So long, so long, so long, so long, so long,\r\nSo long, so long, so long, so long, so long\r\nSo long and thanks\r\nFor all the fish\r\n\r\n</example>
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Seats { get; set; }
    }
}
