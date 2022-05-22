using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class ContractToken
    {
        public int Total { get; set; }
        public List<TokenData> Data { get; set; }

    }
    public class TokenData
    {
        public decimal Amount { get; set; }
        public int Balance { get; set; }
        public decimal Quantity { get; set; }
        public string TokenAbbr { get; set; }
        public int TokenCanShow { get; set; }
        public int TokenDecimal { get; set; }
        public string TokenId { get; set; }
        public string TokenLogo { get; set; }
        public string TokenName { get; set; }
        public decimal TokenPriceInTrx { get; set; }
        public string TokenType { get; set; }
        public bool Vip { get; set; }
    }
}
