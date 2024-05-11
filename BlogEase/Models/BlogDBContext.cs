using Microsoft.EntityFrameworkCore;

namespace BlogEase.Models
{
    public class BlogDBContext: DbContext
    {
        public DbSet<ContentClass> ContentClasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FVHS298\\SQLEXPRESS;Database=BlogEaseDB; Integrated Security=true;TrustServerCertificate=true;");
        }
    }
}
