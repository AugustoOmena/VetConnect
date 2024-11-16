﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VetConnect.Persistence.Context;

#nullable disable

namespace VetConnect.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241114224915_AddSchedulingAndAttendanceTables")]
    partial class AddSchedulingAndAttendanceTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VetConnect.Domain.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uuid");

                    b.Property<int>("AttendanceStatus")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUppdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SchedulingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchedulingId")
                        .IsUnique();

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUppdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PetType")
                        .HasColumnType("integer");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Scheduling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttendenceId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateInitial")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUppdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Scheduling");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.ServiceHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUppdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("SchedulingId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("SchedulingId")
                        .IsUnique();

                    b.ToTable("ServiceHistories");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DateUppdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("UserType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("VetConnect.Domain.Entities.Scheduling", "Scheduling")
                        .WithOne("Attendance")
                        .HasForeignKey("VetConnect.Domain.Entities.Attendance", "SchedulingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scheduling");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Pet", b =>
                {
                    b.HasOne("VetConnect.Domain.Entities.User", "User")
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Scheduling", b =>
                {
                    b.HasOne("VetConnect.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetConnect.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.ServiceHistory", b =>
                {
                    b.HasOne("VetConnect.Domain.Entities.Pet", "Pet")
                        .WithMany("ServiceHistories")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VetConnect.Domain.Entities.Scheduling", "Scheduling")
                        .WithOne("ServiceHistory")
                        .HasForeignKey("VetConnect.Domain.Entities.ServiceHistory", "SchedulingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Scheduling");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Pet", b =>
                {
                    b.Navigation("ServiceHistories");
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.Scheduling", b =>
                {
                    b.Navigation("Attendance")
                        .IsRequired();

                    b.Navigation("ServiceHistory")
                        .IsRequired();
                });

            modelBuilder.Entity("VetConnect.Domain.Entities.User", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}