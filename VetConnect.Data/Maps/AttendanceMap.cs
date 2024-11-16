using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetConnect.Domain.Entities;

namespace VetConnect.Data.Maps;

internal class AttendanceMap : IEntityTypeConfiguration<Attendance>
{
    
    // Mapeamento do Atendimento
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Description)
            .HasMaxLength(45);

        builder.Property(x => x.Prescription)
            .HasMaxLength(45);

        builder.Property(x => x.AttendanceStatus);

        builder.HasOne(p => p.Scheduling)
            .WithOne(u => u.Attendance)
            .OnDelete(DeleteBehavior.Restrict);
    }
}