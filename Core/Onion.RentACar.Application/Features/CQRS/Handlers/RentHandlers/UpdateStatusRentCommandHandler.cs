using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.RentCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.RentHandlers
{
    public class UpdateStatusRentCommandHandler : IRequestHandler<UpdateStatusRentCommandRequest>
    {
        private readonly IRentListDal _rent;
        private readonly ICacheManager _cache;

        public UpdateStatusRentCommandHandler(IRentListDal rent, ICacheManager cache)
        {
            _rent = rent;
            _cache = cache;
        }

        public async Task<Unit> Handle(UpdateStatusRentCommandRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Admin,Employee,Customer");

            var updatedData = await _rent.GetByFilterAsync(r => r.Id == request.Id);

            if (updatedData != null)
            {
                CacheTool.RemoveCache("rentList", _cache);

                updatedData.StatusId = request.StatusId;

                await _rent.UpdateAsync(updatedData);
            }


            return Unit.Value;
        }
    }
}
