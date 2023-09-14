using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ptk_w1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }


        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct) {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            product.Id = updatedProduct.Id != default ? updatedProduct.Id : product.Id;
            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product=>product.Id == id);

            if (product == null)
                return BadRequest();

            products.Remove(product);

            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch(int id, [FromBody] Product partialUpdate)
        {
            var product = products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                return BadRequest();
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


    }
}
