using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MvcTemaPs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    public class TeatruDBContext : DbContext
    {
        public DbSet<Bilet> Bilets { get; set; }
        public DbSet<Spectacol> Spectacols { get; set; }
    }
}