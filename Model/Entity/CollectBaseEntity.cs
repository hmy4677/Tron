using SqlSugar;

namespace Model.Entity
{
    public class CollectBaseEntity
    {
        [SugarColumn(IsPrimaryKey = true, ColumnDataType = "bigint")]
        public long Id { get; set; }

        [SugarColumn(ColumnDataType = "bigint")]
        public long RelationId { get; set; }

        public DateTime CollectTime { get; set; }
    }
}