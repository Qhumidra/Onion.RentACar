using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Interfaces;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQueryRequest, CarListDto?>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        public GetCarQueryHandler(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public async Task<CarListDto?> Handle(GetCarQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _carDal.GetByFilterAsync(c => c.Id == request.Id);

            return _mapper.Map<CarListDto>(data);
        }
    }
}
