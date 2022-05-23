using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class ContractTrackTransfer
    {
        public int rangeTotal { get; set; }
        public int total { get; set; }
        public List<TrackTransfer> token_transfers { get; set; }

    }

    public class TrackTransfer
    {
        public string quant { get; set; }
        public string contractRet { get; set; }
        public bool confirmed { get; set; }
        public int block { get; set; }
        public long block_ts { get; set; }
        public string from_address { get; set; }
        public string to_address { get; set; }
        public TrackInfo tokenInfo { get; set; }
    }

    public class TrackInfo
    {
        public string transaction_id { get; set; }
    }
}
