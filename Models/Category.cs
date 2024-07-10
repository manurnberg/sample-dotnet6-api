using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sample_rest_api.Models;

namespace sample_rest_api {

    public class Category {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; } 

        public ICollection<Producto> Productos { get; set; }
    }
}