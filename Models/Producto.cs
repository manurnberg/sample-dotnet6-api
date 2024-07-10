
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample_rest_api.Models
{
    public class Producto {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

}

}
