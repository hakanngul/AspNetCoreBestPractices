using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Data.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await UnitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}