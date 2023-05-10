using MediatR;
using Onion.RentACar.Application.Dtos;
using Onion.RentACar.Application.Features.CQRS.Queries.AppUser;
using Onion.RentACar.Application.Helpers.Hashing;
using Onion.RentACar.Application.Helpers.JWT;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.JWT;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class LoginQueryHandler : IRequestHandler<UserForLoginQueryRequest, UserAccessToken>
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;

        public LoginQueryHandler(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        public async Task<UserAccessToken> Handle(UserForLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var userToCheck = await _userDal.GetByFilterAsync(n => n.Name == request.Name);
            if (userToCheck == null)
            {
                throw new Exception("Kullannici yok");
            }

            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new Exception("Hatali Sifre");
            }

            var accessToken = JWTTool.CreateAccessToken(userToCheck, _tokenHelper, _userDal);
           var roles = _userDal.GetClaims(userToCheck);
            UserAccessToken result = new();

            foreach (var role in roles)
            {
                result.Role = role.Name;

            }
            result.Token = accessToken.Token;
            result.Expiration = accessToken.Expiration;

            return result;
        }

    }
}
