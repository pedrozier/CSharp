using apiemail.Models;
using Microsoft.EntityFrameworkCore;

namespace apiemail.Data
{
    public class EmailDbContext : DbContext
    {
        public EmailDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EmailModel> Emails { get; set; }
    }
}
