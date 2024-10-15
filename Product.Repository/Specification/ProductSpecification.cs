using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Repository.Specification
{
    public class ProductSpecification
    {
        public int? BrandID { get; set; }
        public int? TypeId { get; set;}
        public String? Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int MAXPAGESIZE = 50;
        private int _pageSize = 6;
        public int PageSize
        {
            get=>_pageSize;
            set => _pageSize = (value > MAXPAGESIZE) ? int.MaxValue : value;
        }
        private String? _search;
        public String? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }

    }
}
