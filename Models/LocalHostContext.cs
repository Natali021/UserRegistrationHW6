using Microsoft.EntityFrameworkCore;

namespace UserRegistration_HW6.Models
{
    public class LocalHostContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-A858QMV\\SQLEXPRESS; Initial Catalog=HW_6;  Integrated Security=SSPI;");
        }
    }
}
