using FluentValidation;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Utilities.ValidationRules.FluentValidation
{
    public class RentValidator : AbstractValidator<RentList>
    {
        public RentValidator()
        {
            RuleFor(c => c.AppUserId).NotNull();
            RuleFor(c => c.CarId).NotNull();
            RuleFor(c => c.PaymentType).NotNull();
            RuleFor(c => c.Price).NotNull();
            RuleFor(c => c.IssueDate).NotNull();
            RuleFor(c => c.PurchaseDate).NotNull();
            RuleFor(c => c.StatusId).NotNull();
        }
    }
}
