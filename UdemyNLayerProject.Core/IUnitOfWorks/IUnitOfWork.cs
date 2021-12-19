using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        
        ICategoryRepository Categories { get; }

        Task CommitAsync();
        
        void Commit();
    }
}