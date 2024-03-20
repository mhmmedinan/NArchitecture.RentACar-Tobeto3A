using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, Guid, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}

