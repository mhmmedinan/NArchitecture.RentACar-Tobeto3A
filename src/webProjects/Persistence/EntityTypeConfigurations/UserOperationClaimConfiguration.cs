using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EntityTypeConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.UserId).HasColumnName("UserId");
        builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
        builder.HasOne(u => u.User);
        builder.HasOne(u => u.OperationClaim);
    }
}