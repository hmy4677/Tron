namespace Model.Dto.Fetch
{
    public class ContractData : TronScanBase
    {
        public new List<ContractInfo> Data { get; set; }
    }

    public class ContractInfo
    {
        public int balance { get; set; }
        public int trxCount { get; set; }
    }
}