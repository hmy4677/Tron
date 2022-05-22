using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Base", IsDisabledUpdateAll = true)]
    public class ContractBaseEntity : CollectBaseEntity
    {
        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal Balance { get; set; }

        public int Transactions { get; set; }
    }
}