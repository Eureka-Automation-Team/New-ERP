using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.CNC
{
    public class ProgramListDet
    {
        public ProgramListDet()
        {
        }

        public ProgramListDet(string ProgName, string ProgNo, string ProgSize, string ProgDate)
        {
            this.ProgName = ProgName;
            this.ProgNo = ProgNo;
            this.ProgSize = ProgSize;
            this.ProgDate = ProgDate;
        }

        public string ProgName { set; get; }

        public string ProgNo { set; get; }

        public string ProgSize { set; get; }

        public string ProgDate { set; get; }

        public IEnumerable<ProgramListDet> PrgDetList { get; set; }
    }
}
