using System;

namespace Core.Entities
{

          public class Product : BaseEntity
          {

                    public string NameAr { get; set; }

                    public string NameEn { get; set; }

                    public string PictureUrl { get; set; }

                    public string DescriptionAr { get; set; }

                    public string DescriptionEn { get; set; }

                    public decimal Price { get; set; }

                    public DateTime CreatedAt { get; set; }

                    public string CreatedBy { get; set; }

                    public DateTime UpdatedAt { get; set; }

                    public string UpdatedBy { get; set; }

                    public ProductType ProductType { get; set; }

                    public ProductBrand ProductBrand { get; set; }

                    public int ProductTypeId { get; set; }

                    public int ProductBrandId { get; set; }




          }

}