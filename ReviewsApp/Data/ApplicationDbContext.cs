using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReviewsApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
