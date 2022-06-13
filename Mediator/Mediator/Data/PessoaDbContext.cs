using Mediator.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Data
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
