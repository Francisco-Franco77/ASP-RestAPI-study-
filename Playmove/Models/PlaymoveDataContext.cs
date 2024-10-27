using Microsoft.EntityFrameworkCore;

namespace Playmove.Models
{
    /// <summary>
    /// Acesso ao contexto de dados do banco playmove
    /// </summary>
    public class PlaymoveDataContext(DbContextOptions<PlaymoveDataContext> options) : DbContext(options)
    {
        /// <summary>
        /// Modelo do fornecedor
        /// </summary>
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}
