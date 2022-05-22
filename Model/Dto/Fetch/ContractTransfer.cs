using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class ContractTransfer
    {
        public int total { get; set; }
        public int rangeTotal { get; set; }
        public List<Transfer> data { get; set; }

    }
    public class Transfer
    {
        public Token tokenInfo { get; set; }
        public decimal amount { get; set; }
        public string contractRet { get; set; }
        public bool confirmed   { get; set; }
        public long timestamp { get; set; }
        public string transferFromAddress { get; set; }
        public string transferToAddress { get; set; }
        public string transactionHash { get; set; }
        public int block { get; set; }

    }
    public class Token
    {
        public string tokenName { get; set; }
    }
}
