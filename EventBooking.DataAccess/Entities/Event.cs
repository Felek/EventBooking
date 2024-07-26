using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBooking.DataAccess.Entities
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Country { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }

        [Range(0, 100)]
        public int Seats { get; set; }
    }
}
