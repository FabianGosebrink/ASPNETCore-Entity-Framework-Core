using AspnetCoreEFCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreEFCoreExample
{
    public class DataBaseContext : DbContext
    {
        public DbSet<MyModel> MyModels { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }
    }
}
