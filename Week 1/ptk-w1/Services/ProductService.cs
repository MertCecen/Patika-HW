using ptk_w1;

namespace ptk_w1.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product == null)
            {
                return false;
            }
            products.Remove(product);
            return true;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return false;

            product.Id = updatedProduct.Id != default ? updatedProduct.Id : product.Id;
            product.Name = !string.IsNullOrWhiteSpace(updatedProduct.Name) ? updatedProduct.Name : product.Name;

            return true;
        }
    }
}
