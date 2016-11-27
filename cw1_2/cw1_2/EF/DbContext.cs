using System.Data.Entity;
using cw1_2.EF.Models;

namespace cw1_2.EF
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=DbContext")
        {
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Training>().HasMany(i => i.Clients).WithRequired().WillCascadeOnDelete(false);
        }
    }
}
