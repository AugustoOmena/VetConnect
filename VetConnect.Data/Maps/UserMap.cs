using VetConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VetConnect.Data.Maps;

internal class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(x => x.Password)
            .HasMaxLength(5000)
            .IsRequired(false);

        builder.Property(x => x.FirstName)
            .HasMaxLength(120)
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasMaxLength(120)
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique(true);
        
        builder.HasMany(u => u.Pets)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}