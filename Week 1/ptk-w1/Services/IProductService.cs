using ptk_w1;

namespace ptk_w1.Services
{
    public interface IProductService
    {
        // Get all the products
        List<Product> GetProducts();
        // Get product by id
        Product GetProductById(int id);
        // Add product
        void AddProduct(Product product);
        // Update product
        bool UpdateProduct(int id, Product updatedProduct);
        // Delete product
        bool DeleteProduct(int id);
    }
}
