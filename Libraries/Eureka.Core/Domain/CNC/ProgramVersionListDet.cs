using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.CNC
{
    public class ProgramVersionListDet
    {
        public ProgramVersionListDet()
        {
        }

        public ProgramVersionListDet(string ProgNo, string ProgVer, string ProgDate)
        {
            this.ProgNo = ProgNo;
            this.ProgVer = ProgVer;
            this.ProgDate = ProgDate;
        }

        public string ProgNo { set; get; }

        public string ProgVer { set; get; }

        public string ProgDate { set; get; }

        public IEnumerable<ProgramVersionListDet> PrgVerList { get; set; }
    }
}
