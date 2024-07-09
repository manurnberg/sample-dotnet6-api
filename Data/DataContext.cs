using Microsoft.EntityFrameworkCore;
using sample_rest_api.Models;

namespace sample_rest_api
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
            {
            }
            public DbSet<Producto> Productos { get; set; }
    }
}