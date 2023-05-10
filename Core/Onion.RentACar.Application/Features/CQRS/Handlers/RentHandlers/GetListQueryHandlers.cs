using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Enums;
using Onion.RentACar.Application.Features.CQRS.Queries.RentQueries;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Application.Utilities.Caching;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.RentHandlers
{
    public class GetListQueryHandler : IRequestHandler<GetListRentQueryRequest, List<RentListDto>>
    {
        private readonly IRentListDal _rent;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;


        public GetListQueryHandler(IRentListDal rent, IMapper mapper, ICacheManager cache)
        {
            _rent = rent;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<RentListDto>> Handle(GetListRentQueryRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Employee,Admin");

            var cacheIsExist = CacheTool.IsExist("rentList", _cache);

            if (cacheIsExist)
                return _mapper.Map<List<RentListDto>>(CacheTool.GetCache("rentList", _cache));

            var data = await _rent.GetList();

            CacheTool.AddCache("rentList", data, _cache, (int)FromMinutes.SixthMinute);

            return data;
        }

    }
}
