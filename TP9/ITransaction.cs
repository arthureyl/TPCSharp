namespace TP9
{
    public interface ITransaction
    {
        void Accepter(IVisitor visitor);
    }
}
