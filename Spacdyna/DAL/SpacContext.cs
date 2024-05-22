using Microsoft.EntityFrameworkCore;
using Spacdyna.Models;
using System.Data.Common;

namespace Spacdyna.DAL
{
    public class SpacContext : DbContext
    {
        public SpacContext(DbContextOptions options) : base(options) {}
                
        public DbSet<Provide> provides { get; set; }
    }
}
