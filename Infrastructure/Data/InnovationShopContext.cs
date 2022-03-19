using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
          public class InnovationShopContext : DbContext
          {
                    public InnovationShopContext(DbContextOptions options) : base(options)
                    {
                    }

                    public DbSet<Product> Tbproducts { get; set; }
                    public DbSet<ProductType> Tbproductstype { get; set; }
                    public DbSet<ProductBrand> Tbproductsbrand { get; set; }

                    protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {

                              base.OnModelCreating(modelBuilder);

                              modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

                    }

          }
}