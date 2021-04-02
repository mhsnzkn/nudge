using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utility
{
    public class ResultModel
    {
        public bool Error { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }

        public void SetError(string message)
        {
            this.Error = true;
            this.Message = message;
        }
    }
}
