using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sample_rest_api.Models;

namespace sample_rest_api {
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly DataContext _context;

        public CategoriesController(ILogger<CategoriesController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            try
            {
                var categories = await _context.Categories.FromSqlRaw("SELECT * FROM Categories").ToListAsync();
                var categoryDto = categories.Select(cat => new CategoryDto
                {
                    Id = cat.Id,
                    Name = cat.Name,

                }).ToList();


                return Ok(categoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories");
                return StatusCode(500, "Internal server error");
            }
        } 
    }
}
