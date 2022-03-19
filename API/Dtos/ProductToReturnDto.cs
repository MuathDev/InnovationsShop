namespace API.Dtos
{
    public class ProductToReturnDto
    {

        public int Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string PictureUrl { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public string ProductType { get; set; }
        public string ProductBrand { get; set; }

        public decimal Price { get; set; }


    }
}
