using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class Context : DbContext
    {
        public DbSet<Shared.Models.UserModel> Users { get; set; }
        public DbSet<Shared.Models.ProductModel> Products { get; set; }

        public Context(DbContextOptions<Context> context) : base(context)
        {

        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shared.Models.ProductModel>().ToTable("Products");
            base.OnModelCreating(modelBuilder);
        }
        */
    }
}