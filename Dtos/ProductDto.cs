public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Available { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CategoryId { get; set; }

    }