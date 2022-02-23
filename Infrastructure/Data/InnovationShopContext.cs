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

          }
}