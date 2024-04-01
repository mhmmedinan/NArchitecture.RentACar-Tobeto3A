namespace Application.Features.Cars.Dtos;

public class GetListCarResponse
{
    public Guid ModelId { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }
    public Guid Id { get; set; }
    public string ImagePath { get; set; }
}
