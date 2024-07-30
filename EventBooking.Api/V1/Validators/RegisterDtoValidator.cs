using EventBooking.Api.V1.Dto;
using FluentValidation;

namespace EventBooking.Api.V1.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
