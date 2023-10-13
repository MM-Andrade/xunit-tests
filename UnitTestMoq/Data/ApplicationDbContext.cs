using Microsoft.EntityFrameworkCore;
using UnitTestMoq.Model;

namespace UnitTestMoq.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
