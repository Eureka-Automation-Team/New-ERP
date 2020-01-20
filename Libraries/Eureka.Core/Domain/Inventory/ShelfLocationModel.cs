using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Inventory
{
    public class ShelfLocationModel
    {
        public int LocationId { get; set; }
        public int LevelNo { get; set; }
        public int ColumnNo { get; set; }
        public string CombindLocation { get; set; }
        public int ItemId { get; set; }
        public int TaskId { get; set; }
        public bool ReserveFlag { get; set; }
        public bool FillFlag { get; set; }
        public bool AvailableFlag { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public int Priority { get; set; }

    }
}
