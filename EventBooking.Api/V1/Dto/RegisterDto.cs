using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EventBooking.Api.V1.Dto
{
    public class RegisterDto
    {
        public string Email { get; set; }
    }
}
