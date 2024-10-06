using VetConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VetConnect.Data.Maps;

internal class ServiceHistoryMap : IEntityTypeConfiguration<ServiceHistory>
{
    public void Configure(EntityTypeBuilder<ServiceHistory> builder)
    {
        builder.ToTable("ServiceHistories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.PetId)
            .IsRequired();

        // Relacionamento N:1 - Um ServiceHistory pertence a um único Pet
        builder.HasOne(sh => sh.Pet)
            .WithMany(p => p.ServiceHistories)
            .HasForeignKey(sh => sh.PetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}