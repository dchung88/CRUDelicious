using Microsoft.EntityFrameworkCore;
 
namespace CRUDelicious_.Models
{
    public class CRUDelicious_Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public CRUDelicious_Context(DbContextOptions options) : base(options) { }
        public DbSet<Dishes> CRUD {get;set;} 
    }
}