using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.RentACar.Application.Features.CQRS.Commands.RentCommands;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Features.CQRS.Queries.RentQueries;

namespace Onion.RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var data = await _mediator.Send(new GetListRentQueryRequest());

            return Ok(data);
        }

        [HttpGet("getlistbycategory")]
        public async Task<IActionResult> GetListByCategory(int id)
        {
            var result = await _mediator.Send(new GetListByCategoryQueryRequest(id));

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateRentCommandRequest request)
        {
            var data = await _mediator.Send(request);

            return Ok(data);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateRentCommandRequest request)
        {
            var data = await _mediator.Send(request);

            return Ok(data);
        }
    }
}
