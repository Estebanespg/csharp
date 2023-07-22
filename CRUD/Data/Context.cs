using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class Context : DbContext
    {
        public DbSet<Shared.Models.UserModel> Users { get; set; }

        public Context(DbContextOptions<Context> context) : base(context)
        {

        }
    }
}