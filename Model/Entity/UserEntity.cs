using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [SugarTable("users", IsDisabledUpdateAll = true)]
    public class UserEntity : CommonEntity
    {
        public string Account { get; set; }
        public string Name { get; set; }
        [SugarColumn(ColumnDataType ="varchar(128)")]
        public string Password { get; set; }
        [SugarColumn(IsNullable = true)]
        public string AvatarUrl { get; set; }
    }
}
