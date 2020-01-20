using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface ITaskManagementView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler Release_Click;
        event EventHandler ResetGrid;
        event EventHandler QCPass_Click;
        event EventHandler QCNG_Click;
        event EventHandler Sorting_Changed;
        event EventHandler ReSchedule_Click;

        string SortBy { get; set; }
        string SortType { get; set; }
        string FilterType { get; set; }
        string FilterBy { get; set; }
        string FilterWord { get; set; }
        List<JobTaskModel> tasks { get; set; }
        BindingSource bindingTasks { get; set; }
        void BindingTask();
    }
}
