using AspnetCoreEF7Example.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreEF7Example
{
    public class DataBaseContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }
    }
}
