using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Response_Handler
{
    public class CustomException : Response
    {
        public CustomException(int statusCode,String ? message=null,String? details = null) : base(statusCode, message)
        {
            Details = details;
        }
        public String? Details { get; set; }
    }
}
