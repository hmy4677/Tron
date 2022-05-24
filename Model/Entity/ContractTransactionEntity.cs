using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Transaction", IsDisabledUpdateAll = true)]
    public class ContractTransactionEntity : CollectBaseEntity
    {
        [SugarColumn(ColumnDataType = "varchar(128)")]
        public string Hash { get; set; }

        public int Block { get; set; }

        [SugarColumn(ColumnDataType = "bigint")]
        public long Timestamp { get; set; }

        public string MethodName { get; set; }
        public string OwnerAddress { get; set; }
        public string ToAddress { get; set; }

        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal Amount { get; set; }

        public string Token { get; set; }
        public string Result { get; set; }
        public bool Confirmed { get; set; }
    }
}