using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.RentACar.Application.Features.CQRS.Queries.CarQueries;
using Onion.RentACar.Application.Features.CQRS.Queries.CategoryQuery;

namespace Onion.RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("carCategories")]
        public async Task<IActionResult> CarCategoryList()
        {
            var result = await _mediator.Send(new GetCarCategoriesQueryRequest());

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("rentCategories")]
        public async Task<IActionResult> RentCategoryList()
        {
            var result = await _mediator.Send(new GetRentCategoriesQueryRequest());

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
