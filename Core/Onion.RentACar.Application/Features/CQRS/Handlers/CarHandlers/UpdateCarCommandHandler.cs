using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Application.Tools.Validation;
using Onion.RentACar.Application.Utilities.Caching;
using Onion.RentACar.Application.Utilities.ValidationRules.FluentValidation;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommandRequest>
    {
        private readonly ICarDal _carDal;
        private readonly ICacheManager _cache;

        public UpdateCarCommandHandler(ICarDal carDal, ICacheManager cache)
        {
            _carDal = carDal;
            _cache = cache;
        }

        public async Task<Unit> Handle(UpdateCarCommandRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Admin,Employee");


            var updatedData = await _carDal.GetByFilterAsync(c => c.Id == request.Id);


            ValidationTool.Validate(new CarValidator(), request);
            var cacheIsExist = CacheTool.IsExist("cars" + request.Id, _cache);
            if (cacheIsExist)
                CacheTool.RemoveCache("cars" + request.Id, _cache);


            if (updatedData != null)
            {
                CacheTool.RemoveCache("cars", _cache);
                updatedData.Model = request.Model;
                updatedData.Brand = request.Brand;
                updatedData.CategoryId = request.CategoryId;
                updatedData.Age = request.Age;
                updatedData.Price = request.Price;

                await _carDal.UpdateAsync(updatedData);
            }


            return Unit.Value;
        }
    }
}
