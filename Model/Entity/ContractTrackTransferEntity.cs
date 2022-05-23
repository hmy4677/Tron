using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Track_Transfer", IsDisabledUpdateAll = true)]
    public class ContractTrackTransferEntity : CollectBaseEntity
    {
        public string quant { get; set; }
        public string contractRet { get; set; }
        public bool confirmed { get; set; }
        public int block { get; set; }
        [SugarColumn(ColumnDataType = "bigint")]
        public long block_ts { get; set; }
        public string from_address { get; set; }
        public string to_address { get; set; }
        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string hash { get; set; }
    }
}
