namespace Model.Dto.Fetch
{
    public class ContractTransaction
    {
        public int rangeTotal { get; set; }
        public int Total { get; set; }
        public long WholeChainTxCount { get; set; }
        public List<Trans> Data { get; set; }
    }

    public class Trans
    {
        public string hash { get; set; }
        public int block { get; set; }
        public long timestamp { get; set; }
        public TriggerInfo trigger_info { get; set; }
        public string ownerAddress { get; set; }
        public string toAddress { get; set; }
        public decimal amount { get; set; }
        public Token tokenInfo { get; set; }
        public string result { get; set; }
        public bool confirmed { get; set; }
    }

    public class TriggerInfo
    {
        public string methodName { get; set; }
    }
}