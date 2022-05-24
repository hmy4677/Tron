using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Event", IsDisabledUpdateAll = true)]
    public class ContractEventEntity : CollectBaseEntity
    {
        public int block_number { get; set; }

        [SugarColumn(ColumnDataType = "bigint")]
        public long block_timestamp { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string transaction_id { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string @event { get; set; }

        public string event_name { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string? zero { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string? one { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string? two { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string owner { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string spender { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string from { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)", IsNullable = true)]
        public string to { get; set; }

        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string value { get; set; }
    }
}