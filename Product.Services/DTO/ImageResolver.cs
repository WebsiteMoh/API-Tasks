using AutoMapper;
using Microsoft.Extensions.Configuration;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.DTO
{
    public class ImageResolver : IValueResolver<Products, ProductModel, String>
    {
        private readonly IConfiguration _context;
        public ImageResolver(IConfiguration context) {
            _context = context;
        }
        public string Resolve(Products source, ProductModel destination, string destMember, ResolutionContext context)
        {
            if(!String.IsNullOrEmpty(source.PictureUrl))
            return $"{_context["BaseURL"]}/{source.PictureUrl}";
            return null;
        }
    }
}
