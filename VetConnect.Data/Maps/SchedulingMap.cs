using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetConnect.Domain.Entities;

namespace VetConnect.Data.Maps;

internal class SchedulingMap : IEntityTypeConfiguration<Scheduling>
{
    // Mapeamento do Agendamento
    public void Configure(EntityTypeBuilder<Scheduling> builder)
    {
        builder.ToTable("Schedulings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DateInitial);
        
        builder.Property(x => x.DateEnd);

        builder.Property(x => x.Description)
            .HasMaxLength(45);

        builder.Property(x => x.ServiceHistoryId);
        
        builder.Property(x => x.PetId);

        builder.HasOne(p => p.ServiceHistory)
            .WithOne()
            .HasForeignKey<Scheduling>(x => x.ServiceHistoryId);
    }
}