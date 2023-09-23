using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ptk_w1.Services;

namespace ptk_w1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }


        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _productService.AddProduct(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct) {
            var success = _productService.UpdateProduct(id, updatedProduct);

            if (!success)
            {
                return BadRequest("Product not found");
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _productService.DeleteProduct(id);

            if (!success)
            {
                return BadRequest("Product not found");
            }

            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch(int id, [FromBody] Product partialUpdate)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return BadRequest("Product not found");
            }

            // Update specific properties based on the partialUpdate object
            if (!string.IsNullOrWhiteSpace(partialUpdate.Name))
            {
                product.Name = partialUpdate.Name;
            }
            // Add more properties as needed

            // Return a 200 OK response with the updated product
            return Ok(product);
        }

        [HttpGet("list")]
        public IActionResult ListProducts([FromQuery] string name = "") {

            var product = _productService.GetProducts().FirstOrDefault(p => p.Name == name);
            return Ok(product);
        }


    }
}
