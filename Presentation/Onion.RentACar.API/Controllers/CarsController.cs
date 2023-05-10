using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.RentACar.Application.Features.CQRS.Commands.CarCommands;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;

namespace Onion.RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetCarsQueryRequest());

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }



        [HttpGet("getbycategory")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var result = await _mediator.Send(new GetByCategoryQueryRequest(id));

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByid(int id)
        {
            var result = await _mediator.Send(new GetCarByIdQueryRequest(id));

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateCarCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateCarCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _mediator.Send(new RemoveCarCommandRequest(id));


            return Ok(result);
        }
    }
}