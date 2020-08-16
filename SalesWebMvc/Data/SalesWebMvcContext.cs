using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    /// <summary>
    /// Classe responsável pela definição das entidades da aplicação no banco de dados.
    /// </summary>
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
