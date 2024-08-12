using ControleEndereco.Domain.Interfaces.Transactions;
using ControleEndereco.Infrastructure.Data.Context;

namespace ControleEndereco.Infrastructure.Data.Transactions
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly DbSession _session;

        public UnityOfWork(DbSession session) {
            _session = session;
        }

        public void Begin() => _session.Transaction = _session.Connection.BeginTransaction();

        public void Commit() => _session.Transaction.Commit();

        public void RollBack() => _session.Transaction.Rollback();

        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }
    }
}
