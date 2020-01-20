using Eureka.CNC.Presentations;
using Eureka.Core.Domain.Manufacturing;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public partial class JobListForm : MaterialForm, IJobListView
    {
        private readonly JobListPresenter _presenter;
        private List<JobEntityModel> _jobs;
        private List<JobEntityModel> _jobsSelected;

        public JobListForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE);
            _presenter = new JobListPresenter(this);
        }

        public BindingSource bindingHead
        {
            get { return jobEntityModelBindingSource; }
            set { jobEntityModelBindingSource = value; }
        }
        public string jobNo
        {
            get { return txtJobNumber.Text; }
            set { txtJobNumber.Text = value; }
        }
        public DateTime startDate
        {
            get { return dtpStartDate.Value; }
            set { dtpStartDate.Value = value; }
        }
        public DateTime endDate
        {
            get { return dtpEndDate.Value; }
            set { dtpEndDate.Value = value; }
        }
        public List<JobEntityModel> jobs
        {
            get { return _jobs; }
            set { _jobs = value; }
        }
        public List<JobEntityModel> jobsSelected
        {
            get { return _jobsSelected; }
            set { _jobsSelected = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;

        public void BindingData()
        {
            try
            {
                bindingNav.BindingSource = bindingHead;
            }
            catch { }

            SetJobsGrid();
        }

        private void SetJobsGrid()
        {
            dgvJobs.BorderStyle = BorderStyle.Fixed3D;
            dgvJobs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvJobs.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvJobs.MultiSelect = true;
            dgvJobs.RowHeadersVisible = true;
            dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJobs.AllowUserToResizeColumns = true;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void JobListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Clear_Click != null)
                Clear_Click(sender, e);
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJobs.CurrentRow == null) return;
            if (dgvJobs.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
