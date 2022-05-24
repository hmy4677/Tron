using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Internal", IsDisabledUpdateAll = true)]
    public class ContractInternalEntity : CollectBaseEntity
    {
        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string hash { get; set; }

        public int block { get; set; }

        [SugarColumn(ColumnDataType = "bigint")]
        public long timestamp { get; set; }

        public string from { get; set; }
        public string to { get; set; }
        public string note { get; set; }
        public bool confirmed { get; set; }
        public string result { get; set; }
        public decimal call_value { get; set; }
        public string token { get; set; }
    }
}