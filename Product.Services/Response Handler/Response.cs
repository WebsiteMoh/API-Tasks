using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Response_Handler
{
    public class Response
    {
        public Response(int statusCode, String? message = null) {

            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int StatudCode)
        
            =>StatusCode switch
              {
                  100 => "Continue",
                  200=>"OK",
                  500=>"InternalServerError",
                  _ => throw new NotImplementedException(),
              };
        }
    }
    

