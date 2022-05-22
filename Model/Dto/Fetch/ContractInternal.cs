namespace Model.Dto.Fetch
{
    public class ContractInternal
    {
        public int rangeTotal { get; set; }
        public int total { get; set; }
        public List<Internal> data { get; set; }
    }

    public class Internal
    {
        public string hash { get; set; }
        public int block { get; set; }
        public long timestamp { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int note { get; set; }
        public bool confirmed { get; set; }
        public string result { get; set; }
        public decimal call_value { get; set; }
        public Token token_list { get; set; }
    }
}