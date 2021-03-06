using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecifications<Product>
    {

        public ProductsWithTypesAndBrandSpecification(ProductSpecParams ProductParams)
            :base(x => 
              (string.IsNullOrEmpty(ProductParams.Search) || x.NameAr.ToLower().Contains(ProductParams.Search) || x.NameEn.ToLower().Contains(ProductParams.Search)) &&
              (!ProductParams.typeId.HasValue || x.ProductTypeId == ProductParams.typeId) && (!ProductParams.brandId.HasValue || x.ProductBrandId == ProductParams.brandId)
            )
        {


            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);

            AddOrderBy(x => x.NameEn);

            ApplyPaging(ProductParams.PageSize * (ProductParams.PageIndex - 1), ProductParams.PageSize);


            if (!string.IsNullOrEmpty(ProductParams.sort))
            {
                switch (ProductParams.sort)
                {
                    case "priceAsc":
                        AddOrderBy(i => i.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(i => i.Price);
                        break;
                    default:
                        AddOrderBy(n => n.NameAr);
                        break;
                }
            }

        }

        public ProductsWithTypesAndBrandSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}
