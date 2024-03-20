using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.CarImageService;

public interface ICarImageService
{
    Task<List<CarImage>> GetList();
    Task<CarImage> Get(Guid id);
    Task Add(IFormFile file,CarImage carImage);
    Task Update(IFormFile file,CarImage carImage);
    Task Delete(CarImage carImage);
    Task<List<CarImage>> GetImagesByCarId(Guid id);
}
