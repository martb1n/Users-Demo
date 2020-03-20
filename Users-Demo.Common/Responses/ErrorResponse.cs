using System.Collections.Generic;
using Users_Demo.Common.Models;

namespace Users_Demo.Common.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors = new List<ErrorModel>();
    }
}
