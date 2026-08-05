using DotNet_Angular_App_2.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Angular_App_2.Data
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes => Set<Class>();

        internal async Task<Class?> FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }


}
