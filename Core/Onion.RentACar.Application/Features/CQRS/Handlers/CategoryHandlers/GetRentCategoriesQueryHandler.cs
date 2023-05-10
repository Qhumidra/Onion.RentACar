using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Enums;
using Onion.RentACar.Application.Features.CQRS.Queries.CategoryQuery;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetRentCategoriesQueryHandler : IRequestHandler<GetRentCategoriesQueryRequest, List<RentCategoryListDto>>
    {
        private readonly IStatusDal _statusDal;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;
        public GetRentCategoriesQueryHandler(IMapper mapper, ICacheManager cache, IStatusDal statusDal)
        {
            _mapper = mapper;
            _cache = cache;
            _statusDal = statusDal;
        }

        public async Task<List<RentCategoryListDto>> Handle(GetRentCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheIsExist = CacheTool.IsExist("rentCategories", _cache);

            if (cacheIsExist)
                return _mapper.Map<List<RentCategoryListDto>>(CacheTool.GetCache("rentCategories", _cache));



            var data = await _statusDal.GetAllAsync();



            CacheTool.AddCache("rentCategories", data, _cache, (int)FromMinutes.SixthMinute);

            return _mapper.Map<List<RentCategoryListDto>>(data);
        }
    }
}

