using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Core.Entities
{
    public class CollectBaseEntity
    {
        [SugarColumn(IsPrimaryKey = true, ColumnDataType = "bigint")]
        public long Id { get; set; }

        [SugarColumn(ColumnDataType = "bigint")]
        public long ContractId { get; set; }
        public DateTime CollectTime { get; set; }
    }
}
