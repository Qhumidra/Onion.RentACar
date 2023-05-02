using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Caching;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Enums;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQueryRequest, List<CarListDto>>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;
        public GetCarsQueryHandler(ICarDal carDal, IMapper mapper, ICacheManager cache)
        {
            _carDal = carDal;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<CarListDto>> Handle(GetCarsQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheIsExist = CacheTool.IsExist("cars", _cache);

            if (cacheIsExist)
                return _mapper.Map<List<CarListDto>>(CacheTool.GetCache("cars", _cache));



            var data = await _carDal.GetAllAsync();



            CacheTool.AddCache("cars", data, _cache, (int)FromMinutes.SixthMinute);

            return _mapper.Map<List<CarListDto>>(data);
        }
    }
}
