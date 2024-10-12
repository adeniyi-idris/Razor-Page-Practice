using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;


namespace WebApplication2.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }
        public DbSet<Category> categories { get; set; }


    }
}
