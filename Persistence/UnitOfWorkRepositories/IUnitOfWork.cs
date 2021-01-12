using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.UnitOfWorkRepositories
{
    public interface IUnitOfWork
    {
        Task<bool> SuccessSaveChangesAsync();
    }
}