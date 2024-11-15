using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetConnect.Domain.Entities;

namespace VetConnect.Data.Maps;

internal class SchedulingMap : IEntityTypeConfiguration<Scheduling>
{
    // Mapeamento do Agendamento
    public void Configure(EntityTypeBuilder<Scheduling> builder)
    {
        builder.ToTable("Scheduling");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DateInitial);
        
        builder.Property(x => x.DateEnd);

        builder.Property(x => x.Description)
            .HasMaxLength(45);

        builder.Property(x => x.ServiceId);
        
        builder.Property(x => x.PetId);
        
        builder.Property(x => x.UserId);
        
        builder.HasOne(p => p.ServiceHistory)
            .WithOne(u => u.Scheduling)
            .OnDelete(DeleteBehavior.Cascade);
    }
}