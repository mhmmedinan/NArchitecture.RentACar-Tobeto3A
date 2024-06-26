﻿using Application.Features.Cars.Queries.GetListCarByModelId;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Queries.GetListModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateModelCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("",result);
        }

        [HttpGet("{BrandId}")]
        public async Task<IActionResult> GetList([FromRoute]GetListModelQuery modelQuery)
        {
            var result = await Mediator.Send(modelQuery);
            return Ok(result);
        }

    }
}
