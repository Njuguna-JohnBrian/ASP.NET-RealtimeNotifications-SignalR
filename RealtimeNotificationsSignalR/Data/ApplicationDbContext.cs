using Microsoft.EntityFrameworkCore;
using RealtimeNotificationsSignalR.Models;

namespace RealtimeNotificationsSignalR.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; } = null!;
    }
}