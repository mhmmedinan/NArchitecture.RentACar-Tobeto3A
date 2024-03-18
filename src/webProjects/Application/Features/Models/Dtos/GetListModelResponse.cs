namespace Application.Features.Models.Dtos;

public class GetListModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public string Name { get; set; }
}
