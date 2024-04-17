using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListDynamic;
using Application.Features.Brands.Queries.GetListPagination;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommand deleteBrandCommand)
        {
            return Ok(await Mediator.Send(deleteBrandCommand));
        }


        [HttpGet]
        public async Task<IActionResult> GetListPagination([FromQuery] GetListPaginationBrandQuery brandQuery)
        {
            var result = await Mediator.Send(brandQuery);
            return Ok(result);
        }

        [HttpPost("dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBrandDynamicQuery brandDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            BrandListModel result = await Mediator.Send(brandDynamicQuery);
            return Ok(result);
        }
    }
}
