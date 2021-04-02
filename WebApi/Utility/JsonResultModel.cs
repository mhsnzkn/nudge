using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utility
{
    public class JsonResultModel
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; } = false;
    }
}
