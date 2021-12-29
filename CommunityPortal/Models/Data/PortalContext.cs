using CommunityPortal.Models.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityPortal.Models.Data
{
    public class PortalContext : IdentityDbContext<IdentityUser>
    {
        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}
