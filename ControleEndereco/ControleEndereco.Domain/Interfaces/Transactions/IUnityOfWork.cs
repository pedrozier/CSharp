namespace ControleEndereco.Domain.Interfaces.Transactions
{
    public interface IUnityOfWork
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}
