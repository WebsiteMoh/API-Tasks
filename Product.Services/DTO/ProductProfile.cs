using AutoMapper;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.DTO
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {

            CreateMap<Products, ProductModel>().
                ForMember(des => des.PictureUrl, option => option.MapFrom<ImageResolver>());
        }
    }
}
