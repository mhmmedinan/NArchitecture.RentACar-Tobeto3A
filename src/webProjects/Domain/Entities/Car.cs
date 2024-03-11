using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Car : BaseEntity<Guid>
{
    public int ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }

    public Model Model { get; set; }

    public virtual ICollection<CarImage> CarImages { get; set; }

    public Car()
    {
        CarImages = new HashSet<CarImage>();
    }

    public Car(Guid id, int modelId, int modelYear,
        string plate, int state, double dailyPrice) : this()
    {
        Id = id;
        ModelId = modelId;
        ModelYear = modelYear;
        Plate = plate;
        State = state;
        DailyPrice = dailyPrice;
    }
}