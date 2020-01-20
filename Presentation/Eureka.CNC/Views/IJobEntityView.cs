using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface IJobEntityView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler Save_Click;
        event EventHandler Cancel_Click;
        event EventHandler New_Job;
        event EventHandler New_Task;
        event EventHandler Selecting_Job;
        event EventHandler TaskSelection_Changed;
        event EventHandler Upload_NCFile;
        event EventHandler Ready_Click;
        event EventHandler DeleteTask_Click;
        event EventHandler Refresh_Click;
        event EventHandler RefreshLines_Click;
        event EventHandler Find_Items;

        bool NewTaskAble { get; set; }
        List<JobEntityModel> jobs { get; set; }
        List<JobTaskModel> tasks { get; set; }
        JobEntityModel jobSelected { get; set; }
        JobTaskModel taskSelected { get; set; }

        BindingSource bindingJobs { get; set; }
        BindingSource bindingTasks { get; set; }

        void BindingJob();
        void BindingTask();
    }
}
