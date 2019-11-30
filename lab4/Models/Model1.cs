using System.Data.Entity;

namespace lab4.Models
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet <Equipment> Equipments { get; set; }
        public DbSet <Patient> Patients { get; set; }
        public DbSet <Procedure> Procedures { get; set; }

    }
}