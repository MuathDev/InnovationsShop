using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
          public class ProductController : ControllerBase
          {
                    private readonly InnovationShopContext _dbcontext;
                    public ProductController(InnovationShopContext dbcontext)
                    {
                              _dbcontext = dbcontext;
                    }

                    [HttpGet("GetProducts")]
                    public async Task<ActionResult<List<Product>>> GetProducts()
                    {
                              var products = await _dbcontext.Tbproducts.ToListAsync();

                              return Ok(products);
                    }

                    [HttpGet("{id}")]
                    public async Task<ActionResult<Product>> GetProduct(int id)
                    {
                              return Ok(await _dbcontext.Tbproducts.FindAsync(id));
                    }
          }
}