using API.Dtos;
using API.Extensions;
using AutoMapper;
using Core.Entities;

namespace API.Helpers.MappProfile
{
          public class MappingProfiles : Profile
          {

                    public MappingProfiles()
                    {
                              CreateMap<Product, ProductToReturnDto>()
                                  .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.NameEn))
                                  .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.NameEn))
                                  .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
                    }

          }
}
