using System;
using System.Collections.Generic;
using System.Text;

namespace DellyShop.Domain
{
    public class ApiResult
    {
        public ApiResult()
        {

        }

        public ApiResult(object entity, string message)
        {
            Entity = entity;
            Message = message;
        }

        public Object Entity { get; set; }
        public string Message { get; set; }
    }
}
