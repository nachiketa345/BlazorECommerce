﻿using System.Collections.Generic;


namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Products> Product { get; set; } = new List<Products>();

        public async Task<ServiceResponse<Products>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Products>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Products>>>("api/product");
            if (result != null && result.Data != null)
                Product = result.Data;
        }
    }
}
