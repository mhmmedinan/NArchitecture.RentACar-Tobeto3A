using Application.Services.CarImageService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseController
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carImageService.GetList();
            return Ok(result);
        }

        [HttpGet("getcarid/{carId}")]
        public async Task<IActionResult> GetImagesByCarId(Guid carId)
        {
            var result = await _carImageService.GetImagesByCarId(carId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile file, [FromForm] CarImageRequest carImage)
        {
            var result = await _carImageService.Add(file,carImage);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {

            var carImage = await _carImageService.Get(id);
            var result = await _carImageService.Delete(carImage);
            return Ok(result);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(IFormFile formFile, [FromRoute] Guid id)
        {
            var carImage = await _carImageService.Get(id);
            var result = await _carImageService.Update(formFile, carImage);
            return Ok(result);
        }
    }
}
