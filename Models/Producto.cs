
namespace sample_rest_api.Models
{
    public class Producto {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public DateTime CreatedAt { get; set; }

}

}
