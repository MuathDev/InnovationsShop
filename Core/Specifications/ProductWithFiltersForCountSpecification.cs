using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecifications<Product>
    {

        public ProductWithFiltersForCountSpecification(ProductSpecParams ProductParams)
             :base(
                    x =>(string.IsNullOrEmpty(ProductParams.Search) || x.NameAr.ToLower().Contains(ProductParams.Search) ||
                    x.NameEn.ToLower().Contains(ProductParams.Search)) && (!ProductParams.typeId.HasValue || x.ProductTypeId == ProductParams.typeId)
            )

        {



        }

    }

}
