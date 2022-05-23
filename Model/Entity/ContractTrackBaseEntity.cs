using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Track_Base", IsDisabledUpdateAll = true)]
    public class ContractTrackBaseEntity : CollectBaseEntity
    {
        public int holders_count { get; set; }
        public int transfer_num { get; set; }
        public int transfer24h { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,6")]
        public decimal volume24h { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,4")]
        public decimal volume24h_rate { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,6")]
        public int liquidity24h { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,4")]
        public decimal liquidity24h_rate { get; set; }

        public long totalTurnOver { get; set; }
        public long total_supply_with_decimals { get; set; }
        [SugarColumn(ColumnDataType = "decimal(18,6")]
        public decimal tokenPrice { get; set; }
    }
}
