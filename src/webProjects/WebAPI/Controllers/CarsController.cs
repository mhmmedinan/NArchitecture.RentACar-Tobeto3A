using Application.Features.Cars.Command.Create;
using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetListPaginationCar;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            return Created("", await Mediator.Send(createCarCommand));
        }


        [HttpGet]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationCarQuery query = new() { PageRequest = pageRequest };
            CarListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
