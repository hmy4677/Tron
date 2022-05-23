using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class ContractTrackHolder
    {
        public int rangeTotal { get; set; }
        public int total { get; set; }
        public List<Trc20Token> trc20_tokens { get; set; }
    }

    public class Trc20Token
    {
        public string blance { get; set; }
        public bool foundationTag { get; set; }
        public string holder_address { get; set; }
        public string srName { get; set; }
        public bool srTag { get; set; }
    }
}
