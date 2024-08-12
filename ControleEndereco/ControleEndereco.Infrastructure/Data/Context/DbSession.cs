using System.Data;

using Microsoft.Data.Sqlite;

namespace ControleEndereco.Infrastructure.Data.Context
{
    public class DbSession : IDisposable
    {
        public Guid Id { get; }
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set;  }

        public DbSession(string connectionString)
        {
            this.Id = Guid.NewGuid();
            this.Connection = new SqliteConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            this.Connection?.Dispose();
        }
    }
}
