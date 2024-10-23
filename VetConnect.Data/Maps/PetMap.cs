using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetConnect.Domain.Entities;

namespace VetConnect.Data.Maps;

internal class PetMap : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserId);

        builder.Property(x => x.Name)
            .HasMaxLength(255);

        builder.Property(x => x.Race)
            .HasMaxLength(120);

        builder.Property(x => x.PetType);

        builder.HasOne(p => p.User)
            .WithMany(u => u.Pets)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
