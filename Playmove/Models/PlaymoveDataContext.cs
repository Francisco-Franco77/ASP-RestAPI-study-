using Microsoft.EntityFrameworkCore;

namespace Playmove.Models
{
    public class PlaymoveDataContext : DbContext
    {
        public PlaymoveDataContext(DbContextOptions<PlaymoveDataContext> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}
