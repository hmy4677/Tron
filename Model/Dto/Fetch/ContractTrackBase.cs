using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Fetch
{
    public class ContractTrackBase
    {
        public int rangeTotal { get; set; }
        public int total { get; set; }
        public List<TrcToken> trc20_tokens { get; set; }
    }

    public class TrcToken
    {
        public int holders_count { get; set; }
        public int transfer_num { get; set; }
        public int transfer24h { get; set; }
        public decimal volume24h { get; set; }
        public decimal volume24h_rate { get; set; }
        public int liquidity24h { get; set; }
        public decimal liquidity24h_rate { get; set; }

        public long totalTurnOver { get; set; }
        public long total_supply_with_decimals { get; set; }

        public TokenPrice tokenPriceLine { get; set; }

    }

    public class TokenPrice
    {
        public List<PriceTime> data { get; set; }

    }

    public class PriceTime
    {
        public decimal priceUsd { get; set; }
        public int time { get; set; }
    }
}
