using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cw1_2.Models;

namespace WorkManager.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Safe> Safes { get; set; }
        public virtual DbSet<SafeReservation> SafesReservations { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }
}
