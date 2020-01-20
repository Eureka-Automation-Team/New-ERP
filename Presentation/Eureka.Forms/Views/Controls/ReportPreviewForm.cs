using MetroFramework.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Controls
{
    public partial class ReportPreviewForm : MetroForm
    {
        public ReportPreviewForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void ReportPreviewForm_Load(object sender, EventArgs e)
        {
            //reportViewer1.RefreshReport();
            //reportViewer2.Reset();
            reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer2.RefreshReport();
        }

        private void ReportPreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer2.Dispose();
            GC.SuppressFinalize(reportViewer2);
        }
    }
}
