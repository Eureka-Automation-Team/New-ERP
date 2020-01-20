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
    public partial class JobEntityForm : MaterialForm, IJobEntityView
    {
        private JobEntityPresenter _presenter;
        private List<JobEntityModel> _jobs;
        private List<JobTaskModel> _tasks;
        private JobEntityModel _jobSelected;
        private JobTaskModel _taskSelected;
        private bool _NewTaskAble;

        public JobEntityForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE);
            _presenter = new JobEntityPresenter(this);

            this.dgvTasks.RowPrePaint
                        += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                            this.dgvTasks_RowPrePaint);
        }

        private void dgvTasks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool readyFlag = (bool)dgvTasks.Rows[e.RowIndex].Cells["readyFlagDataGridViewCheckBoxColumn"].Value;

            if (readyFlag)
            {                
                dgvTasks.Rows[e.RowIndex].Cells["Priority"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["ShelfNumber"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["taskNumberDataGridViewTextBoxColumn"].ReadOnly = true;                
                dgvTasks.Rows[e.RowIndex].Cells["startDateDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["endDateDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["StandardTime"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["materialCodeDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["tableNumberDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["machineNoDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvTasks.Rows[e.RowIndex].Cells["dueDateDataGridViewTextBoxColumn"].ReadOnly = true;
            }
            else
            {
                dgvTasks.Rows[e.RowIndex].Cells["Priority"].ReadOnly = false;
                dgvTasks.Rows[e.RowIndex].Cells["ShelfNumber"].ReadOnly = false;
                //dgvTasks.Rows[e.RowIndex].Cells["taskNumberDataGridViewTextBoxColumn"].ReadOnly = false;
                //dgvTasks.Rows[e.RowIndex].Cells["startDateDataGridViewTextBoxColumn"].ReadOnly = false;
                //dgvTasks.Rows[e.RowIndex].Cells["endDateDataGridViewTextBoxColumn"].ReadOnly = false;
                dgvTasks.Rows[e.RowIndex].Cells["StandardTime"].ReadOnly = false;
                dgvTasks.Rows[e.RowIndex].Cells["materialCodeDataGridViewTextBoxColumn"].ReadOnly = false;
                dgvTasks.Rows[e.RowIndex].Cells["tableNumberDataGridViewTextBoxColumn"].ReadOnly = false;
                dgvTasks.Rows[e.RowIndex].Cells["machineNoDataGridViewTextBoxColumn"].ReadOnly = false;
                //dgvTasks.Rows[e.RowIndex].Cells["dueDateDataGridViewTextBoxColumn"].ReadOnly = false;
            }
           
        }

        public List<JobEntityModel> jobs
        {
            get { return _jobs; }
            set { _jobs = value; }
        }

        public List<JobTaskModel> tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public JobEntityModel jobSelected
        {
            get
            {
                _jobSelected.JobEntityName = txtJobEntityName.Text;
                _jobSelected.JobEntiryDate = dtpJobEntiryDate.Value;
                _jobSelected.PrimaryItemCode = txtPrimaryItemCode.Text;
                _jobSelected.PrimaryItemModel = txtPrimaryItemModel.Text;
                _jobSelected.Description = txtDescription.Text;
                _jobSelected.PrimaryQuantity = Convert.ToDouble(string.IsNullOrEmpty(txtPrimaryQuantity.Text) ? "0" : txtPrimaryQuantity.Text);

                return _jobSelected;
            }
            set
            {
                _jobSelected = value;

                txtJobEntityName.Text = _jobSelected.JobEntityName;
                dtpJobEntiryDate.Value = _jobSelected.JobEntiryDate;
                txtDescription.Text = _jobSelected.Description;
                txtPrimaryItemCode.Text = _jobSelected.PrimaryItemCode;
                txtPrimaryItemModel.Text = _jobSelected.PrimaryItemModel;
                txtPrimaryQuantity.Text = _jobSelected.PrimaryQuantity.ToString();
                mnuCancel.Enabled = !_jobSelected.ProcessFlag;
                chkOpenStatus.Checked = _jobSelected.OpenStatus;
                chkCancelFlag.Checked = _jobSelected.CancelFlag;
                chkProcessFlag.Checked = _jobSelected.ProcessFlag;
                chkCompletedFlag.Checked = _jobSelected.CompletedFlag;
                NewTaskAble = (_jobSelected.JobEntityId == 0) ? false : true ;
            }
        }
        public JobTaskModel taskSelected
        {
            get { return _taskSelected; }
            set
            {
                _taskSelected = value;
                mnuAttachFile.Enabled = !string.IsNullOrEmpty(_taskSelected.MachineNo);
                mnuDeleteTask.Enabled = !_taskSelected.ReleaseFlag;
                mnuReady.Enabled = !string.IsNullOrEmpty(_taskSelected.MachineNo)
                                 && !string.IsNullOrEmpty(_taskSelected.MaterialCode)
                                 && !string.IsNullOrEmpty(_taskSelected.TableNumber)
                                 && !string.IsNullOrEmpty(_taskSelected.NcFile)
                                 && !(_taskSelected.StartDate == null)
                                 && !(_taskSelected.EndDate == null)
                                 && !(_taskSelected.StandardTime == 0)
                                 && !(_taskSelected.DueDate == null)
                                 && (_taskSelected.NcFile != null);
            }
        }
        
        public BindingSource bindingJobs
        {
            get { return jobEntityModelBindingSource; }
            set { jobEntityModelBindingSource = value; }
        }

        public BindingSource bindingTasks
        {
            get { return jobTaskModelBindingSource; }
            set { jobTaskModelBindingSource = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public bool NewTaskAble
        {
            get { return _NewTaskAble; }
            set
            {
                _NewTaskAble = value;
                mnuNewTask.Enabled = _NewTaskAble;
            }
        }

        public event EventHandler Form_Load;
        public event EventHandler Filter_Click;
        public event EventHandler Save_Click;
        public event EventHandler New_Job;
        public event EventHandler New_Task;
        public event EventHandler Selecting_Job;
        public event EventHandler TaskSelection_Changed;
        public event EventHandler Upload_NCFile;
        public event EventHandler Ready_Click;
        public event EventHandler Cancel_Click;
        public event EventHandler DeleteTask_Click;
        public event EventHandler Refresh_Click;
        public event EventHandler RefreshLines_Click;
        public event EventHandler Find_Items;

        public void BindingJob()
        {
            try
            {
                bindingNav.BindingSource = bindingJobs;
            }
            catch{}

            SetJobsGrid();
        }

        private void SetJobsGrid()
        {
            dgvJobs.BorderStyle = BorderStyle.Fixed3D;
            dgvJobs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvJobs.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvJobs.MultiSelect = false;
            dgvJobs.RowHeadersVisible = true;
            dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJobs.AllowUserToResizeColumns = true;
            dgvJobs.Refresh();
        }

        private void JobEntityForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void mnuNewJob_Click(object sender, EventArgs e)
        {
            if (New_Job != null)
                New_Job(sender, e);
        }

        private void mnuSaveJob_Click(object sender, EventArgs e)
        {
            if (Save_Click != null)
                Save_Click(dgvTasks, e);
        }

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJobs.CurrentRow == null) return;
            if (dgvJobs.CurrentRow.Index == -1) return;

            if (Selecting_Job != null)
                Selecting_Job(sender, e);
        }

        private void txtPrimaryQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void mnuNewTask_Click(object sender, EventArgs e)
        {
            if (New_Task != null)
                New_Task(dgvTasks, e);
        }

        public void BindingTask()
        {
            try
            {
                bindingNavTask.BindingSource = bindingTasks;
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
            dgvTasks.MultiSelect = false;
            dgvTasks.RowHeadersVisible = true;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvTasks.AllowUserToResizeColumns = true;
            dgvTasks.Refresh();
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            if (dgvTasks.CurrentRow.Index == -1) return;

            if (TaskSelection_Changed != null)
                TaskSelection_Changed(sender, e);
        }

        private void mnuAttachFile_Click(object sender, EventArgs e)
        {
            if (Upload_NCFile != null)
                Upload_NCFile(sender, e);
        }

        private void mnuReady_Click(object sender, EventArgs e)
        {
            if (Ready_Click != null)
                Ready_Click(sender, e);
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            if (Cancel_Click != null)
                Cancel_Click(dgvTasks, e);
        }

        private void mnuDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow == null) return;
            if (dgvTasks.CurrentRow.Index == -1) return;

            if (DeleteTask_Click != null)
                DeleteTask_Click(dgvTasks, e);
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (Refresh_Click != null)
                Refresh_Click(dgvJobs, e);
        }

        private void mnuRefreshLine_Click(object sender, EventArgs e)
        {
            if (RefreshLines_Click != null)
                RefreshLines_Click(sender, e);
        }

        private void dgvTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Find_Items != null)
                Find_Items(sender, e);
        }

        private void dgvTasks_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (dgvTasks.Rows[e.RowIndex].IsNewRow) { return; }

            if (Find_Items != null)
                Find_Items(sender, e);
        }

        private void dgvTasks_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //if(dgvTasks.Columns[e.ColumnIndex].Name == "startDateDataGridViewTextBoxColumn")
            //{
            //    e.Value = DateTime.ParseExact(Convert.ToInt64(e.Value).ToString(), "yyyyMMddHHmmss", null).ToString("dd/MM/yyyy hh:mm:ss tt");
            //    e.ParsingApplied = true;
            //}
        }

        private void dgvTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvTasks.Columns[e.ColumnIndex].Name == "startDateDataGridViewTextBoxColumn" && e.Value != null)
            //{
            //    e.Value = DateTime.ParseExact(e.Value.ToString(), "dd/MM/yyyy hh:mm:ss tt", null).ToString("dd/MM/yyyy hh:mm");
            //    e.FormattingApplied = true;
            //}
        }
    }
}
