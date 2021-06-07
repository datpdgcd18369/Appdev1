using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Cataglory> cataglories { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Toppic> toppics { get; set; }
        public DbSet<work> works { get; set; }
        public DbSet<UserIfo> userIfos { get; set; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}