using habitos_app.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace habitos_app.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Habit> Habit { get; set; }
        public DbSet<Medication> Medication { get; set; } // Agregando DbSet para Medication

        //public DbSet<AdminUser> AdminUser { get; set; }
        //public DbSet<RegularUser> RegularUser { get; set; }
        //public DbSet<HealthProfessional> HealthProfessional { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            // Si necesitas configuraciones específicas para las entidades derivadas, hazlo aquí
        }

    }




}
