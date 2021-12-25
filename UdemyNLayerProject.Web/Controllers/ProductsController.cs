using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService ProductService { get; }

        private IMapper Mapper { get; }

        public ProductsController(IProductService productService, IMapper mapper)
        {
            ProductService = productService;
            Mapper = mapper;
        }

        #region HttpGet

        public async Task<IActionResult> Index()
        {
            var products = await ProductService.GetAllAsync();
            
            return View(Mapper.Map<IEnumerable<ProductDto>>(products));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await ProductService.GetByIdAsync(id);
            return View(Mapper.Map<ProductDto>(product));
        }
        
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await ProductService.GetByIdAsync(id);
            ProductService.Remove(product);
            return RedirectToAction("Index");
        }

        #endregion HttpGet

        #region HttPost

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await ProductService.AddAsync(Mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await ProductService.UpdateAsync(Mapper.Map<Product>(productDto));
            return RedirectToAction("Index");
        }

        #endregion HttPost
    }
}