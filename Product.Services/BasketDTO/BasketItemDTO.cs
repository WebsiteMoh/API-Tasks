using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.BasketDTO
{
    public class BasketItemDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public String ProductName { get; set; }
        [Required]
        public int ProductType { get; set; }
        [Required]
        public int ProduccBrand { get; set; }
        [Required]
        public String ImgURL { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        [Range(0.1,double.MaxValue)]
        public float Price { get; set; }
        [Range(1, 10)]
        public int Quentity { get; set; }


    }
}
