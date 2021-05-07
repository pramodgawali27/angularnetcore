using API.DTO;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpres
{
    public class MappingProfiles:Profile
    {
       public MappingProfiles() {
            CreateMap<Product, ProductDTO>()
            .ForMember(d=>d.ProductBrand,o=>o.MapFrom(x=>x.ProductBrand.Name))
            .ForMember(d=>d.ProductType,o=>o.MapFrom(x=>x.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductValueResolver>());
        }
    }
}
