using System;

namespace Core.Entities
{

          public class Product
          {
                    public int Id { get; set; }

                    public string NameAr { get; set; }

                    public string NameEn { get; set; }

                    public string PictureUrl { get; set; }

                    public string DescriptionAr { get; set; }

                    public string DescriptionEn { get; set; }

                    public DateTime CreatedAt { get; set; }

                    public string CreatedBy { get; set; }

                    public DateTime UpdatedAt { get; set; }

                    public string UpdatedBy { get; set; }



          }

}