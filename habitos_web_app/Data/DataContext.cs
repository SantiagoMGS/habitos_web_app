using habitos_app.Web.Models;
using habitos_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace habitos_app.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<HabitType> HabitType { get; set; }
        public DbSet<Habit> Habit { get; set; }
        public DbSet<Medication> Medication { get; set; } // Agregando DbSet para Medication


    }




}
