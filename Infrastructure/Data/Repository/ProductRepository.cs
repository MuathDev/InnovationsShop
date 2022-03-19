
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
          public class ProductRepository : IProductRepository
          {

                    private readonly InnovationShopContext _context;
                    public ProductRepository(InnovationShopContext context)
                    {
                              _context = context;
                    }

                    public async Task<Product> GetProductByIdAsync(int id)
                    {
                              return await _context.Tbproducts
                                  // .Include(t => t.ProductTypeId)
                                  .FirstOrDefaultAsync(t => t.Id == id);
                    }

                    public async Task<IReadOnlyList<Product>> GetProductsAsync()
                    {
                              // return await _context.Tbproducts.
                              //     Include(t => t.ProductTypeId).ToListAsync();
                              return await _context.Tbproducts.ToListAsync();
                    }

          }

}
