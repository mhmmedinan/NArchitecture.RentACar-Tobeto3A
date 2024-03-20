using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.CarImageService;

public interface ICarImageService
{
    Task<List<CarImage>> GetList();
    Task<CarImage> Get(Guid id);
    Task<CarImage> Add(IFormFile file, CarImageRequest request);
    Task<CarImage> Update(IFormFile file,CarImage carImage);
    Task<CarImage> Delete(CarImage carImage);
    Task<List<CarImage>> GetImagesByCarId(Guid id);
}
