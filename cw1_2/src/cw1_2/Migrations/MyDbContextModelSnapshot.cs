using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorkManager.Data;

namespace cw1_2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cw1_2.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("cw1_2.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IncomeDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("cw1_2.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<byte[]>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("cw1_2.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("cw1_2.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<TimeSpan>("WorkTimeBegin");

                    b.Property<TimeSpan>("WorkTimeEnd");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("cw1_2.Models.Safe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChangeRoom");

                    b.HasKey("Id");

                    b.ToTable("Safes");
                });

            modelBuilder.Entity("cw1_2.Models.SafeReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.Property<DateTime>("ReservationDateEnd");

                    b.Property<DateTime>("ReservationDateStart");

                    b.Property<int>("SafeId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SafeId");

                    b.ToTable("SafesReservations");
                });

            modelBuilder.Entity("cw1_2.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("cw1_2.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PersonId");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PositionId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("cw1_2.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Days")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("ProgramId");

                    b.Property<int>("RoomId");

                    b.Property<int>("StaffId");

                    b.Property<TimeSpan>("TimeBegin");

                    b.Property<TimeSpan>("TimeEnd");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("RoomId");

                    b.HasIndex("StaffId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("cw1_2.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Program");

                    b.HasKey("Id");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("cw1_2.Models.Client", b =>
                {
                    b.HasOne("cw1_2.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cw1_2.Models.Equipment", b =>
                {
                    b.HasOne("cw1_2.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cw1_2.Models.SafeReservation", b =>
                {
                    b.HasOne("cw1_2.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cw1_2.Models.Safe", "Safe")
                        .WithMany()
                        .HasForeignKey("SafeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cw1_2.Models.Service", b =>
                {
                    b.HasOne("cw1_2.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cw1_2.Models.Staff", b =>
                {
                    b.HasOne("cw1_2.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cw1_2.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("cw1_2.Models.Training", b =>
                {
                    b.HasOne("cw1_2.Models.TrainingProgram", "TrainingProgram")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cw1_2.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("cw1_2.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
