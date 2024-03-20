using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : BaseEntity<Guid>
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
