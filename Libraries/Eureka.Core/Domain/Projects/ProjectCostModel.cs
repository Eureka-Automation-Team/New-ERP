using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class ProjectCostModel : BaseEntity
    {
        public int LineNum { get; set; }
        public int ProjectId { get; set; }
        public string ProjectNum { get; set; }
        public int CostId { get; set; }
        [DisplayName("Cost Code")]
        public string CostCode { get; set; }
        [DisplayName("Description")]
        public string CostDescription { get; set; }
        [DisplayName("CBD")]
        public double CBDAmount { get; set; }  //CBD
        [DisplayName("CTG")]
        public double CTGAmount { get; set; } //CTG
        [DisplayName("MP1")]
        public double MP1Amount { get; set; } //MP1       
        [DisplayName("Budget Cost")]
        public double BudgetCostAmount { get; set; }   //Budget Cost
        [DisplayName("Original")]
        public double OrigAmount { get; set; }
        [DisplayName("Cost Usage")]
        public double FcstCostAmount { get; set; }
        [DisplayName("Actual Cost")]
        public double ActCostAmount { get; set; }

        [DisplayName("Last Forecast")]
        public double UfLastForecast { get; set; }
        [DisplayName("Budget Remain")]
        public double UfBudgetRemain
        {
            get { return BudgetCostAmount - (FcstCostAmount ); }
        }
        [DisplayName("Project Reason")]
        public string UfProjectReason { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public double ExcessCost { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Cost Request")]
        public double CostRequisition
        {            
            get
            {
                double amount = ExcessCost - UfBudgetRemain;
                return amount < 0 ? 0 : amount;
            }
        }
        public double RemainPercentage
        {
            get
            {
                double costRem = UfBudgetRemain - ExcessCost;
                double percent = (costRem <= 0) ? 0 : (costRem * 100) / BudgetCostAmount;
                return Math.Round(percent,2);// BudgetCostAmount == 0 ? 0 :(double)Math.Ceiling(percent < 0 ? 0 : percent);
            }
        }
        public string RemainMessage
        {
            get
            {
                string msg = string.Empty;
                if(RemainPercentage == 0)
                {                    
                    if (ExcessCost > 0)
                        msg = "งบติดลบ ให้ของบ";
                    else
                        msg = "งบหมด";
                }
                else if(RemainPercentage <= 25)
                {
                    msg = "เตรียมของบ";
                }
                else if (RemainPercentage > 25)
                {
                    msg = "งบเหลือ";
                }
                return msg;
            }
        }

        public double BeginCostUsaged { get; set; }
        public double BeginCostActual { get; set; }
        public double BeginCostUsagedInstock { get; set; }
        public double InstockCostAmount { get; set; }
    }
}
