using Core.Persistence.Repositories;
using System.Reflection;

namespace Domain.Entities;

public class Brand : BaseEntity<Guid>
{
    public string Name { get; set; }  //Audi 


    public ICollection<Model> Models { get; set; }

    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}