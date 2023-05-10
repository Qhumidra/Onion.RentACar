using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.RentACar.Application.Features.CQRS.Commands.AppUserCommand;
using Onion.RentACar.Application.Features.CQRS.Queries.AppUser;

namespace Onion.RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginQueryRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _mediator.Send(new GetUserByNameQueryRequest(name));

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }      
    }
}
