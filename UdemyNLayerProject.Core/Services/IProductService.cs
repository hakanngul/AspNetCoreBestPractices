using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    internal interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
        // bool ControlInnerBarcode(Product product); 
    }
}