using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Commands.RentCommands;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.Caching;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Application.Tools.Validation;
using Onion.RentACar.Application.Utilities.Caching;
using Onion.RentACar.Application.Utilities.ValidationRules.FluentValidation;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.RentHandlers
{
    public class CreateRentCommandHandler : IRequestHandler<CreateRentCommandRequest, RentCreateDto>
    {
        private readonly IRentListDal _rent;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;

        public CreateRentCommandHandler(IRentListDal rent, IMapper mapper, ICacheManager cache)
        {
            _rent = rent;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<RentCreateDto> Handle(CreateRentCommandRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Admin,Employee,Customer");


            var rent = _mapper.Map<RentList>(request);


            CacheTool.RemoveCache("rentList", _cache);
            ValidationTool.Validate(new RentValidator(), rent);


            var data = await _rent.CreateAsync(rent);

            return _mapper.Map<RentCreateDto>(data);
        }
    }
}
