using Microsoft.AspNetCore.Mvc;
using MyApiProject.Entities;
using MyApiProject.Repositories;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        { 
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        { 
                var products = await _repository.GetAllAsync();
                return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        { 
          var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
          await _repository.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }//
}
