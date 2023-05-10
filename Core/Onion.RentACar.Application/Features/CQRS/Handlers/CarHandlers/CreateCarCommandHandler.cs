using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Application.Tools.Validation;
using Onion.RentACar.Application.Utilities.Caching;
using Onion.RentACar.Application.Utilities.ValidationRules.FluentValidation;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, CarCreatedDto?>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;

        public CreateCarCommandHandler(ICarDal carDal, IMapper mapper, ICacheManager cache)
        {
            _carDal = carDal;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<CarCreatedDto?> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Admin,Employee");

            var car = _mapper.Map<Car>(request);


            CacheTool.RemoveCache("cars", _cache);
            ValidationTool.Validate(new CarValidator(), car);


            var data = await _carDal.CreateAsync(car);

            return _mapper.Map<CarCreatedDto>(data);
        }
    }
}
