using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class TronScanBase
    {
        public int Count { get; set; }
        public virtual List<object> Data { get; set; }
        public TronScanStatus Status { get; set; }
        public string Type { get; set; } = "";
    }
    public class TronScanStatus
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = "success";
    }
}
