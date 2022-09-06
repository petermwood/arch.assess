using System.Threading.Tasks;

namespace AG.Data.Contracts
{
    public interface ITweetManager
    {
        Task<bool> Run();
    }
}
