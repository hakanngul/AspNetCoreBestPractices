using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Data.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class CategoryService: Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await UnitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}