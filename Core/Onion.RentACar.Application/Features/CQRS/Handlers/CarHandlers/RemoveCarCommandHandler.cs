using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommandRequest>
    {
        private readonly ICarDal _carDal;
        private readonly ICacheManager _cache;

        public RemoveCarCommandHandler(ICarDal carDal, ICacheManager cache)
        {
            _carDal = carDal;
            _cache = cache;
        }

        public async Task<Unit> Handle(RemoveCarCommandRequest request, CancellationToken cancellationToken)
        {
            var removedCar = await _carDal.GetByIdAsync(request.Id);

            CacheTool.RemoveCache("cars", _cache);

            if (removedCar != null)
            {
                await _carDal.Remove(removedCar);
            }

            return Unit.Value;
        }
    }
}
