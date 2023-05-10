using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Queries.RentQueries;
using Onion.RentACar.Application.Interfaces;
namespace Onion.RentACar.Application.Features.CQRS.Handlers.RentHandlers
{
    public class GetListByCategoryQueryHandler : IRequestHandler<GetListByCategoryQueryRequest,List<RentListDto>>
    {

        private readonly IRentListDal _rentDal;
        private readonly IMapper _mapper;
        public GetListByCategoryQueryHandler(IRentListDal rentDal, IMapper mapper)
        {
            _rentDal = rentDal;
            _mapper = mapper;
        }
        

        public async Task<List<RentListDto>> Handle(GetListByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _rentDal.GetByCategory(request.Id);

            return _mapper.Map<List<RentListDto>>(data);
        }
    }
}
