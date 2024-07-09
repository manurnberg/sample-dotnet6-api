using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sample_rest_api.Models;

namespace sample_rest_api {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly DataContext _context;

        public ProductsController(ILogger<ProductsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Producto>>> GetProducts()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Producto>> GetProduct(int id)
        {
            var product = await _context.Productos.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]

        public async Task<ActionResult<Producto>> CreateProduct(Producto product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateProduct(int id, Producto product)
        {
            if( id != product.Id )
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Producto>> DeleteProduct(int id)
        {
            var product = await _context.Productos.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}