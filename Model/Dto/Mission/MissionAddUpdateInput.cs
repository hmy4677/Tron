namespace Model.Dto.Mission
{
    public class MissionAddUpdateInput
    {
        public int Type { get; set; }
        public string Name { get; set; } = "";
        public string? Describe { get; set; }
        public string CollectAddress { get; set; } = "";
        public int CollectInterval { get; set; }
        public DateTime LastCollectTime { get; set; }
    }
}