using API.Dtos;
using API.PaginationParm;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
          {

                    private readonly IGenericRepository<Product> _productRepo;
                    private readonly IGenericRepository<ProductType> _productTypeRepo;
                    private readonly IGenericRepository<ProductBrand> _productBrandepo;
                    private readonly IMapper _mapper;
                    public ProductsController(
                        IGenericRepository<Product> productRepo,
                        IGenericRepository<ProductType> productTypeRepo,
                        IGenericRepository<ProductBrand> productBrandepo
                        , IMapper mapper)
                    {
                              _mapper = mapper;
                              _productRepo = productRepo;
                              _productTypeRepo = productTypeRepo;
                              _productBrandepo = productBrandepo;
                    }

                    [HttpGet]
                    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams ProductParams)
                    {

                              var spec = new ProductsWithTypesAndBrandSpecification(ProductParams);

                              var countSpec = new ProductWithFiltersForCountSpecification(ProductParams);
                              var TotalItems = await _productRepo.CountAsync(countSpec);

                              var products = await _productRepo.ListAsync(spec);

                              var data = _mapper
                                  .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

                              return Ok(new Pagination<ProductToReturnDto>(ProductParams.PageIndex,
                                  ProductParams.PageSize, TotalItems, data));

                    }


                    [HttpGet("{id}")]
                    [ProducesResponseType(StatusCodes.Status200OK)]
                    [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
                    public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
                    {

                              var spec = new ProductsWithTypesAndBrandSpecification(id);

                              var product = await _productRepo.GetEntityWithSpec(spec);

                              if(product == null) return NotFound(new ApiResponse(404));

                              return _mapper.Map<Product, ProductToReturnDto>(product);

                    }

                    [HttpGet("productstype")]

                    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
                    {

                              return Ok(await _productTypeRepo.ListAllAsync());

                    }


                    [HttpGet("productbrand")]

                    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
                    {

                              return Ok(await _productBrandepo.ListAllAsync());

                    }


          }
}
