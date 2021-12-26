using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ProductApiService ProductApiService { get; }
        private IMapper Mapper { get; }

        public ProductsController( IMapper mapper, ProductApiService productApiService)
        {
            Mapper = mapper;
            ProductApiService = productApiService;
        }
        
        
        public async Task<IActionResult> Index()
        {
            var products = await ProductApiService.GetAllAsync();
            return View(Mapper.Map<IEnumerable<ProductDto>>(products));
        }
        
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await ProductApiService.GetByIdAsync(id);
            return View(Mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await ProductApiService.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await ProductApiService.AddAsync(productDto);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await ProductApiService.UpdateAsync(productDto);
            return RedirectToAction("Index");
        }


    }
}