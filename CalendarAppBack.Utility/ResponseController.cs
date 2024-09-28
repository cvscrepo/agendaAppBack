using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.Utility
{
    public class ResponseController
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Value { get; set; }
    }
}
