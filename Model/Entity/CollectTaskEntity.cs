using SqlSugar;

namespace Model.Entity
{
    [SugarTable("CollectTasks", IsDisabledUpdateAll = true)]
    public class CollectTaskEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        public int Type { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public string CollectAddress { get; set; } = "";
        public int CollectInterval { get; set; }
        public DateTime? LastCollectTime { get; set; }
        public int Status { get; set; }
    }
}