using EventBooking.Api.V1.Dto;
using FluentValidation;

namespace EventBooking.Api.V1.Validators
{
    public class AddOrUpdateEventValidator : AbstractValidator<AddOrUpdateEventDto>
    {
        public AddOrUpdateEventValidator()
        {
            RuleFor(x => x.Name).Length(1, 50);
            RuleFor(x => x.Country).Length(1, 20);
            RuleFor(x => x.Seats).InclusiveBetween(0, 100);
        }
    }
}
