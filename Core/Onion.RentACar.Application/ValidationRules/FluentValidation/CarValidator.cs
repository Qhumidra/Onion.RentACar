using FluentValidation;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.RentACar.Application.ValidationRules.FluentValidation
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
