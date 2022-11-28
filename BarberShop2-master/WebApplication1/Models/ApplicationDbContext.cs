using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Tootaja>? Tootaja { get; set; }

        public DbSet<Teenus>? Teenus { get; set; }

        public DbSet<Kasutaja>? Kasutaja { get; set; }

        public DbSet<Tellimus>? Tellimus { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}