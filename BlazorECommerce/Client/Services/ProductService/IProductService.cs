
namespace BlazorECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Products> Product { get; set; }
        Task GetProducts();
        Task<ServiceResponse<Products>> GetProduct(int productId);
    }
}
