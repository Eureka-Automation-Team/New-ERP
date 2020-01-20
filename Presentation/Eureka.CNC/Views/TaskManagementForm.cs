using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eureka.CNC.Presentations;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Core.Domain.Security;
using MaterialSkin.Controls;

namespace Eureka.CNC.Views
{
    public partial class TaskManagementForm : MaterialForm, ITaskManagementView
    {
        private TaskManagementPresenter _presenter;
        private string _SortBy;
        private List<JobTaskModel> _tasks;

        public TaskManagementForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE);
            _presenter = new TaskManagementPresenter(this);

            this.dgvTasks.RowPrePaint
                    += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                        this.dgvTasks_RowPrePaint);
        }

        private void dgvTasks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (this.FilterType == "REREASE")
            {
                dgvTasks.Rows[e.RowIndex].Cells["priorityDataGridViewTextBoxColumn"].ReadOnly = false;
            }
            else if (this.FilterType == "INSPECTION")
            {
                dgvTasks.Rows[e.RowIndex].Cells["priorityDataGridViewTextBoxColumn"].ReadOnly = true;
            }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public BindingSource bindingTasks
        {
            get { return jobTaskModelBindingSource; }
            set { jobTaskModelBindingSource = value; }
        }

        public string FilterType
        {
            get { return cboFilterType.Text; }
            set
            {
                cboFilterType.Text = value;
                FilterBy = "*";
                if (cboFilterType.Text == "REREASE")
                {
                    mnuRelease.Enabled = true;
                    //mnuReSchedule.Enabled = true;
                    mnuQCInspection.Enabled = false;
                }else if (cboFilterType.Text == "INSPECTION")
                {
                    mnuRelease.Enabled = false;
                    //mnuReSchedule.Enabled = false;
                    mnuQCInspection.Enabled = true;
                }

            }
        }

        public string FilterBy
        {
            get { return cboFilterBy.Text; }
            set
            {
                cboFilterBy.Text = value;
                if (cboFilterBy.Text == "*")
                    FilterWord = "";
            }
        }
        public string FilterWord
        {
            get { return txtFilterWord.Text; }
            set { txtFilterWord.Text = value; }
        }

        public string SortBy
        {
            get { return cboSortBy.Text; }
            set { cboSortBy.Text = value; }
        }
        public List<JobTaskModel> tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public string SortType
        {
            get { return cboSortType.Text; }
            set { cboSortType.Text = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Filter_Click;
        public event EventHandler Release_Click;
        public event EventHandler ResetGrid;
        public event EventHandler QCPass_Click;
        public event EventHandler QCNG_Click;
        public event EventHandler Sorting_Changed;
        public event EventHandler ReSchedule_Click;

        public void BindingTask()
        {
            try
            {
                bindingNav.BindingSource = bindingTasks;
            }
            catch { }

            SetTaskGrid();
        }

        private void SetTaskGrid()
        {
            dgvTasks.BorderStyle = BorderStyle.Fixed3D;
            dgvTasks.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTasks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTasks.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvTasks.MultiSelect = true;
            dgvTasks.RowHeadersVisible = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.AllowUserToResizeColumns = true;
            dgvTasks.Refresh();
        }

        private void mnuFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void TaskManagementForm_Load(object sender, EventArgs e)
        {
            cboSortType.SelectedIndex = 0;
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void mnuRelease_Click(object sender, EventArgs e)
        {
            if (Release_Click != null)
                Release_Click(dgvTasks, e);
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterType = cboFilterType.Text;

            if (ResetGrid != null)
                ResetGrid(sender, e);
        }

        private void cboFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FilterBy = cboFilterBy.Text;
        }

        private void mnuQCPass_Click(object sender, EventArgs e)
        {
            if (QCPass_Click != null)
                QCPass_Click(dgvTasks, e);
        }

        private void mnuQCNG_Click(object sender, EventArgs e)
        {
            if (QCNG_Click != null)
                QCNG_Click(dgvTasks, e);
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sorting_Changed != null)
                Sorting_Changed(sender, e);
        }

        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sorting_Changed != null)
                Sorting_Changed(sender, e);
        }
    }
}
