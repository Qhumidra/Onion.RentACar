using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Application.Interfaces;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommandRequest>
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCarCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedData = await _carDal.GetByIdAsync(request.Id);

            if (updatedData != null)
            {
                await _carDal.UpdateAsync(updatedData);
            }


            return Unit.Value;
        }
    }
}
