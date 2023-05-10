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
    public class GetCarCategoriesQueryHandler : IRequestHandler<GetCarCategoriesQueryRequest, List<CarCategoryListDto>>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;
        public GetCarCategoriesQueryHandler(ICategoryDal categoryDal, IMapper mapper, ICacheManager cache)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<CarCategoryListDto>> Handle(GetCarCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var cacheIsExist = CacheTool.IsExist("categories", _cache);

            if (cacheIsExist)
                return  _mapper.Map<List<CarCategoryListDto>>(CacheTool.GetCache("categories", _cache));



            var data = await _categoryDal.GetAllAsync();



            CacheTool.AddCache("categories", data, _cache, (int)FromMinutes.SixthMinute);

            return _mapper.Map<List<CarCategoryListDto>>(data);
        }
    }
}

