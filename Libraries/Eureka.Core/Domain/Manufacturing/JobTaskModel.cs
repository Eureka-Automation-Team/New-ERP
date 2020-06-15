using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Manufacturing
{
    public class JobTaskModel
    {
        public int TaskId { get; set; }
        public int TaskSeq { get; set; }
        public int JobId { get; set; }
        public string TaskNumber { get; set; }
        public string JobNumber { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime EndDate 
        { 
            get { return StartDate.AsDateTime().AddMinutes(StandardTime); }             
        }
        public bool CancelFlag { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string ErrorText { get; set; }
        public bool ReadyFlag { get; set; }
        public bool ReleaseFlag { get; set; }       
        public bool UploadNcfileFlag { get; set; }
        public bool TransferNCFileToMachineFlag { get; set; }
        public string TransferMessage { get; set; }
        public string Source { get; set; }
        public string ShelfNumber { get; set; }
        public bool ReserveShelfFlag { get; set; }       
        public bool OnShelfFlag { get; set; }        
        public bool McProcessFlag { get; set; }
        public bool McPickFlag { get; set; }
        public bool McLoadFlag { get; set; }
        public bool McFinishFlag { get; set; }
        public bool McUnloadFlag { get; set; }
        public bool McPushFlag { get; set; }
        public bool OutboundFlag { get; set; }
        public bool OutboundFinishFlag { get; set; }    //***************
        public string QCStatus { get; set; }             
        public string MaterialCode { get; set; }        
        public string TableNumber { get; set; }
        public string NcFile { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public string MachineNo { get; set; }
        public string MachineNoReady { get; set; }
        public int Priority { get; set; }
        public double StandardTime { get; set; }
        public string PrimaryItemCode { get; set; } //***************
        public string PrimaryItemModel { get; set; } //***************
        public double PrimaryQuantity { get; set; } //***************
        public bool StartFlag { get; set; } //***************
        public int MachineId { get; set; }
    }
}
