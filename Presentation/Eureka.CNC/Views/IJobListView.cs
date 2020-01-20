using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface IJobListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;

        BindingSource bindingHead { get; set; }
        string jobNo { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        List<JobEntityModel> jobs { get; set; }
        List<JobEntityModel> jobsSelected { get; set; }
        void BindingData();
        void CloseMe();
    }
}
