using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.RentCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.RentHandlers
{
    public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommandRequest>
    {
        private readonly IRentListDal _rent;
        private readonly ICacheManager _cache;

        public UpdateRentCommandHandler(IRentListDal rent, ICacheManager cache)
        {
            _rent = rent;
            _cache = cache;
        }

        public async Task<Unit> Handle(UpdateRentCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedData = await _rent.GetByFilterAsync(r => r.Id == request.Id);

            if (updatedData != null)
            {
                CacheTool.RemoveCache("rentList", _cache);

                updatedData.CarId = request.CarId;
                updatedData.AppUserId = request.AppUserId;
                updatedData.PaymentType = request.PaymentType;
                updatedData.Price = request.Price;
                updatedData.IssueDate = request.IssueDate;
                updatedData.PurchaseDate = request.PurchaseDate;
                updatedData.StatusId = request.StatusId;

                await _rent.UpdateAsync(updatedData);
            }


            return Unit.Value;
        }
    }
}
