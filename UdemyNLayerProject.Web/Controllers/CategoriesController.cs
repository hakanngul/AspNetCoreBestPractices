using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryApiService CategoryApiService { get; }

        private IMapper Mapper { get; }

        public CategoriesController(CategoryApiService categoryApiService, IMapper mapper)
        {
            Mapper = mapper;
            CategoryApiService = categoryApiService;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await CategoryApiService.GetAllAsync();
            return View(Mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await CategoryApiService.GetByIdAsync(id);
            return View(Mapper.Map<CategoryDto>(category));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await CategoryApiService.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await CategoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await CategoryApiService.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }
    }
}