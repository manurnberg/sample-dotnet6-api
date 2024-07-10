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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _context.Productos
                    .FromSqlRaw("SELECT * FROM Productos")
                    .ToListAsync();

                var productDtos = products.Select(product => new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Available = product.Available,
                    CreatedAt = product.CreatedAt,
                    CategoryId = product.CategoryId
                }).ToList();

        return Ok(productDtos);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error retrieving products");
        return StatusCode(500, "Internal server error");
    }
}


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            try
            {
                var product = await _context.Productos.FromSqlRaw("SELECT * FROM Productos WHERE Id = {0}", id).FirstOrDefaultAsync();

                if (product == null)
            {
                return NotFound();
            }

                var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Available = product.Available,
                CreatedAt = product.CreatedAt
            };

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving product with ID {id}");
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = new ProductDto
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Available = createProductDto.Available,
                CreatedAt = DateTime.Now,
                CategoryId = createProductDto.CategoryId
            };
            try
            {
                product.CreatedAt = DateTime.Now;

                var insertQuery = "INSERT INTO Productos (Name, Price, Available, CreatedAt, CategoryId) VALUES ({0}, {1}, {2}, {3}, {4})";
                var lastInsertId = "SELECT * FROM Productos WHERE Id = last_insert_rowid()";

                await _context.Database.ExecuteSqlRawAsync(insertQuery, product.Name, product.Price, product.Available, DateTime.Now, product.CategoryId);
                var newProduct = await _context.Productos.FromSqlRaw(lastInsertId).FirstOrDefaultAsync();

                if (newProduct == null)
                {
                    return StatusCode(500, "Error creating product.");
                }

                var productDto = new ProductDto
                {
                    Id = newProduct.Id,
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    Available = newProduct.Available,
                    CreatedAt = newProduct.CreatedAt,
                    CategoryId = newProduct.CategoryId
                };


                return CreatedAtAction(nameof(GetProduct), new { id = productDto.Id }, productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Productos.FromSqlRaw("SELECT * FROM Productos WHERE Id = {0} ", id).FirstAsync();
            if (product == null)
            {
                return NotFound();
            }

            try
            {
                await _context.
                Database.
                ExecuteSqlRawAsync("UPDATE Productos SET Name = {0}, Price = {1}, Available = {2} WHERE Id = {3}",
                 updateProductDto.Name, updateProductDto.Price, updateProductDto.Available, id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating product with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Productos.FromSqlRaw("SELECT * FROM Productos WHERE Id = {0}", id).FirstOrDefaultAsync();

                if (product == null)
                {
                    return NotFound();
                }

                await _context.Database.ExecuteSqlRawAsync("DELETE FROM Productos WHERE Id = {0}", id);
                await _context.SaveChangesAsync();

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
