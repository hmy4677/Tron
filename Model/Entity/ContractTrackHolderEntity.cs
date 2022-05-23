using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Model.Entity
{
    [SugarTable("C_Track_Holder", IsDisabledUpdateAll = true)]
    public class ContractTrackHolderEntity : CollectBaseEntity
    {
        public string blance { get; set; }
        public bool foundationTag { get; set; }
        public string holder_address { get; set; }
        public string srName { get; set; }
        public bool srTag { get; set; }
    }
}
