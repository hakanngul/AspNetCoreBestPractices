using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class ProductApiService
    {
        private HttpClient HttpClient { get; }

        private readonly string _products = "Products";

        public ProductApiService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> productDtos;
            var response = await HttpClient.GetAsync(_products);
            if (response.IsSuccessStatusCode)
            {
                productDtos = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>
                    (await response.Content.ReadAsStringAsync());
            }
            else productDtos = null;

            return productDtos;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8,
                "application/json");
            var response = await HttpClient.PostAsync(_products, stringContent);
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await HttpClient.GetAsync($"{_products}/{id}");
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<ProductDto>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<bool> UpdateAsync(ProductDto productDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8,
                "application/json");
            var response = await HttpClient.PutAsync(_products, stringContent);
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await HttpClient.DeleteAsync($"{_products}/{id}");
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}