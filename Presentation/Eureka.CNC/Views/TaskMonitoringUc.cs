using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eureka.Core.Domain.Manufacturing;

namespace Eureka.CNC.Views
{
    public partial class TaskMonitoringUc : UserControl, ITaskMonitoringView
    {
        public TaskMonitoringUc()
        {
            InitializeComponent();
        }

        public List<JobTaskModel> tasks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public JobTaskModel taskSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BindingSource TasksDatasource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler Form_Load;
        public event EventHandler Filter_Click;

        public void BindingTasks()
        {
            throw new NotImplementedException();
        }
    }
}
