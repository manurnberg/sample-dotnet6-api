using System.ComponentModel.DataAnnotations;

namespace sample_rest_api
{
     public class UpdateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool Available { get; set; } = true;

        public int CategoryId { get; set; }
    }
}