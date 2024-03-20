using Application.Services.Repositories;
using Core.CrossCutting.Utilities.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.CarImageService;

public class CarImageManager : ICarImageService
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public CarImageManager(ICarImageRepository carImageRepository, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<CarImage> Add(IFormFile file, CarImageRequest request)
    {
        await _carImageBusinessRules.CheckIfCarImageNull(request.CarId);
        await _carImageBusinessRules.CheckIfCarImageFormat(file);
        await _carImageBusinessRules.CheckIfImageLimit(request.CarId);
        CarImage carImage = new CarImage()
        {
            CarId = request.CarId,
            ImagePath = request.ImagePath,
        };
        carImage.ImagePath = FileHelper.Add(file, "CarImages");
       return await _carImageRepository.AddAsync(carImage);

    }

    public async Task<CarImage> Delete(CarImage carImage)
    {
        await _carImageBusinessRules.CarImageIdShouldExistsWhenSelected(carImage.Id);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync(c => c.Id == carImage.Id).Result.ImagePath;
        var result = FileHelper.Delete(path);
       return await _carImageRepository.DeleteAsync(carImage);

    }

    public async Task<CarImage> Get(Guid id)
    {
        return await _carImageRepository.GetAsync(c => c.Id == id);
       
    }

    public async Task<List<CarImage>> GetImagesByCarId(Guid id)
    {
        
       await _carImageBusinessRules.CarImageCarIdShouldExistsWhenSelected(id);
       return await _carImageBusinessRules.CheckIfCarImageNull(id);
    }

    public async Task<List<CarImage>> GetList()
    {
        return await _carImageRepository.GetAllAsync();
    }

    public async Task<CarImage> Update(IFormFile file, CarImage carImage)
    {
        await _carImageBusinessRules.CheckIfCarImageFormat(file);
        await _carImageBusinessRules.CheckIfCarImageNull(carImage.CarId);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + _carImageRepository.GetAsync(c => c.Id == carImage.Id).Result.ImagePath;
        carImage.ImagePath = FileHelper.Update(path, file, "CarImages");
       return await _carImageRepository.UpdateAsync(carImage);
    }
}
