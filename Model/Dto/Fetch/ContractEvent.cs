using System.Text.Json.Serialization;

namespace Model.Dto.Fetch
{
    public class EventList
    {
        public List<ContractEvent> event_list { get; set; }

    }
    public class ContractEvent
    {
        public int block_number { get; set; }
        public long block_timestamp { get; set; }
        public string transaction_id { get; set; }
        public string @event { get; set; }
        public string event_name { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("0")]
        public string zero { get; set; }

        [JsonPropertyName("1")]
        public string one { get; set; }

        [JsonPropertyName("2")]
        public string two { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string owner { get; set; }
        public string spender { get; set; }
        public string value { get; set; }
    }
}