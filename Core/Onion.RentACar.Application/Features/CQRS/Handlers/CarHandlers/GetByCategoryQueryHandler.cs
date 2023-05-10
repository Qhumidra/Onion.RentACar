using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Interfaces;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetByCategoryQueryHandler : IRequestHandler<GetByCategoryQueryRequest, List<CarListDto?>>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        public GetByCategoryQueryHandler(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public async Task<List<CarListDto?>> Handle(GetByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _carDal.GetByCategory(request.Id);

            return _mapper.Map<List<CarListDto>>(data);
        }
    }
}
