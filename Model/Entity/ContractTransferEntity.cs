using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Transfer", IsDisabledUpdateAll = true)]
    public class ContractTransferEntity : CollectBaseEntity
    {
        public string token { get; set; }
        public decimal amount { get; set; }
        public string contractRet { get; set; }
        public bool confirmed { get; set; }
        [SugarColumn(ColumnName ="bigint")]
        public long timestamp { get; set; }
        public string transferFromAddress { get; set; }
        public string transferToAddress { get; set; }
        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string transactionHash { get; set; }
        public int block { get; set; }
    }
}
