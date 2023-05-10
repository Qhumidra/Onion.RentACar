using MediatR;
using Onion.RentACar.Application.Features.CQRS.Commands.AppUserCommand;
using Onion.RentACar.Application.Helpers.Hashing;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Application.Tools.JWT;

namespace Onion.RentACar.Application.Features.CQRS.Handlers.AppUserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest>
    {
        private readonly IUserDal _userDal;

        public UpdateUserCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            SecuredOperation.Role("Customer,Employee,Admin");


            var updatedData = await _userDal.GetByFilterAsync(u => u.Name == request.CurrentName);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);


            if (updatedData != null)
            {
                updatedData.Name = request.Name;
                updatedData.Surname = request.Surname;
                updatedData.PasswordHash = passwordHash;
                updatedData.PasswordSalt = passwordSalt;
                updatedData.Sokak = request.Sokak;
                updatedData.Mahalle = request.Mahalle;
                updatedData.Ilce = request.Ilce;
                updatedData.Il = request.Il;
                updatedData.AdresNotu = request.AdresNotu;
                await _userDal.UpdateAsync(updatedData);

                return Unit.Value;
            }

            throw new ArgumentException();
        }
    }
}
