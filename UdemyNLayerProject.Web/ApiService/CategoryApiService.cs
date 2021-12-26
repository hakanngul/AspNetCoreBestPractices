using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class CategoryApiService
    {
        private HttpClient HttpClient { get; }

        private readonly string _categories = "Categories";

        public CategoryApiService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await HttpClient.GetAsync(_categories);
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>
                    (await response.Content.ReadAsStringAsync());
            }
            else categoryDtos = null;

            return categoryDtos;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8,
                "application/json");
            var response = await HttpClient.PostAsync(_categories, stringContent);
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await HttpClient.GetAsync($"{_categories}/{id}");
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<bool> UpdateAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8,
                "application/json");
            var response = await HttpClient.PutAsync(_categories, stringContent);
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await HttpClient.DeleteAsync($"{_categories}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}