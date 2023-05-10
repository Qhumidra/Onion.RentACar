using AutoMapper;
using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Queries.AppUser;
using Onion.RentACar.Application.Interfaces;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQueryRequest, UserGetByNameDto>
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public GetUserByNameQueryHandler(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public async Task<UserGetByNameDto> Handle(GetUserByNameQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userDal.GetByFilterAsync(u => u.Name == request.Name);

            return _mapper.Map<UserGetByNameDto>(user);
        }
    }
}
