using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Token")]
    public class ContractTokenEntity : CollectBaseEntity
    {
        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal Amount { get; set; }

        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal Balance { get; set; }

        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal Quantity { get; set; }

        public string TokenAbbr { get; set; }
        public int TokenCanShow { get; set; }
        public int TokenDecimal { get; set; }
        public string TokenId { get; set; }
        public string TokenLogo { get; set; }
        public string TokenName { get; set; }

        [SugarColumn(ColumnDataType = "decimal(18,6)")]
        public decimal TokenPriceInTrx { get; set; }

        public string TokenType { get; set; }
        public bool Vip { get; set; }
    }
}