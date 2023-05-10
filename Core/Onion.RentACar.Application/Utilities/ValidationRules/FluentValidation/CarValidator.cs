using FluentValidation;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Brand).NotNull();
            RuleFor(c => c.Model).NotNull();
            RuleFor(c => c.Price).NotNull();
            RuleFor(c => c.Age).MaximumLength(4);
            RuleFor(c => c.Age).MinimumLength(4);
        }
    }
}
