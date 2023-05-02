using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.AppUserCommand;
using Onion.RentACar.Application.Helpers.Hashing;
using Onion.RentACar.Application.Helpers.JWT;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.JWT;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class RegisterCommandHandler : IRequestHandler<UserForRegisterCommandRequest, AccessToken>
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;

        public RegisterCommandHandler(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }


        public async Task<AccessToken> Handle(UserForRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            var user = new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            await _userDal.CreateAsync(user);

            var accessToken = JWTTool.CreateAccessToken(user, _tokenHelper, _userDal);
            return accessToken;
        }
    }
}
