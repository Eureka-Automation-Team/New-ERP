using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface ITaskMonitoringView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;

        List<JobTaskModel> tasks { get; set; }
        JobTaskModel taskSelected { get; set; }

        BindingSource TasksDatasource { get; set; }

        void BindingTasks();
    }
}
