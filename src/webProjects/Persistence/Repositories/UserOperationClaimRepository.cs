using Application.Services.Repositories;
using Core.Persistence.Repositories.EntityFramework;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, Guid, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}

