using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Enums;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQueryRequest, CarListDto>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;

        public GetCarByIdQueryHandler(ICarDal carDal, IMapper mapper, ICacheManager cache)
        {
            _carDal = carDal;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<CarListDto> Handle(GetCarByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheIsExist = CacheTool.IsExist("cars" + request.Id, _cache);

            if (cacheIsExist)
                return _mapper.Map<CarListDto>(CacheTool.GetCache("cars" + request.Id, _cache));

            var data = await _carDal.GetByIdAsync(request.Id);

            CacheTool.AddCache("cars" + request.Id, data, _cache, (int)FromMinutes.SixthMinute);


            return _mapper.Map<CarListDto>(data);
        }
    }
}
