namespace BlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Products>> GetProductAsync(int productid)
        {
            var response = new ServiceResponse<Products>();
            var product = await _context.Product.FindAsync(productid);
            if(product==null)
            {
                response.Success= false;
                response.Message = "Sorry, this product doesn't exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Products>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Products>>()
            {
                Data = await _context.Product.ToListAsync()
            };
            return response;
        }
    }
}
