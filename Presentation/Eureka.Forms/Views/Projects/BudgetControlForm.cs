using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Security;
using Eureka.Forms.Utilities;
using Eureka.Froms.Presentations.Projects;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Projects
{
    public partial class BudgetControlForm : MetroForm, IBudgetControlView
    {
        private BudgetControlPresenter _presenter;
        private List<ProjectModel> _projects;
        private List<ProjectCostModel> _projectCosts;
        private List<CostGroupModel> _costs;
        private ProjectModel _projectSelected;
        private ProjectCostModel _costSelected;
        private bool _cbdActive;

        public BudgetControlForm(bool cbdActive)
        {
            InitializeComponent();
            _presenter = new BudgetControlPresenter(this);
            _cbdActive = cbdActive;

            this.dgvCosts.RowPrePaint
            += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                this.dgvCosts_RowPrePaint);
        }

        private void dgvCosts_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            double budgetRemaining = (double)dgvCosts.Rows[e.RowIndex].Cells["RemainPercentage"].Value;

            if (budgetRemaining > 25)
            {
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (budgetRemaining <= 25 && budgetRemaining != 0)
            {
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvCosts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }
        public List<ProjectModel> projects
        {
            get { return _projects; }
            set { _projects = value; }
        }
        public List<ProjectCostModel> projectCosts
        {
            get { return _projectCosts; }
            set { _projectCosts = value; }
        }
        public List<CostGroupModel> costs
        {
            get { return _costs; }
            set { _costs = value; }
        }

        public string projectFilter
        {
            get { return txtProjectFilter.Text; }
            set { txtProjectFilter.Text = value; }
        }

        public ProjectModel projectSelected
        {
            get { return _projectSelected; }
            set
            {
                _projectSelected = value;

                txtProjectNum.Text = _projectSelected.ProjectNum;
                txtProjectDescription.Text = _projectSelected.ProjectDescription;
                txtCustomerNum.Text = _projectSelected.CustomerNum;
                txtCustomerName.Text = _projectSelected.CustomerName;
                txtProjectDate.Text = string.IsNullOrEmpty(_projectSelected.ProjectNum) ? "" : _projectSelected.ProjectDate.ToString("dd/MM/yyyy");
                txtState.Text = _projectSelected.State;
                txtProductCode.Text = _projectSelected.ProductCode;
                txtType.Text = _projectSelected.Type;
            }
        }

        public ProjectCostModel costSelected
        {
            get { return _costSelected; }
            set { _costSelected = value; }
        }

        public BindingSource bindingBudgets
        {
            get { return projectCostModelBindingSource; }
            set { projectCostModelBindingSource = value; }
        }

        public MetroProgressBar progression
        {
            get { return metroProgressBar; }
            set { metroProgressBar = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Search_Click;
        public event EventHandler Save_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Delete_Click;
        public event EventHandler Selected_Project;
        //public event EventHandler Copy_Rows;
        public event EventHandler Paste_Rows;
        public event EventHandler Delete_Row;
        public event EventHandler GetLine_Selected;
        public event EventHandler Reset_Cost;

        public void BindingProjectsGrid(List<ProjectModel> list)
        {
            if (list == null)
                return;

            dgvProjects.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
                dgvProjects.Rows.Add(list[i].Id, list[i].ProjectNum, list[i].ProjectDescription, list[i].ProjectDate.ToString("dd/MM/yyyy"));

            SetProjectGrid();
        }

        private void SetProjectGrid()
        {
            dgvProjects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvProjects.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvProjects.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvProjects.MultiSelect = false;
            //dgvProjects.AllowUserToAddRows = false;
        }

        private void BudgetControlForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);

            if (_cbdActive)
            {
                butSave.Visible = true;
                butClear.Visible = true;
                butUpdateAllCost.Visible = true;
                mnuPaste.Enabled = true;
                mnuDel.Enabled = true;
                dgvCosts.Columns["cBDAmountDataGridViewTextBoxColumn"].Visible = true;
                dgvCosts.Columns["cBDAmountDataGridViewTextBoxColumn"].ReadOnly = false;
                dgvCosts.Columns["CTGAmount"].ReadOnly = false;
            }
            else
            {
                butSave.Visible = false;
                butClear.Visible = false;
                butUpdateAllCost.Visible = false;
                mnuPaste.Enabled = false;
                mnuDel.Enabled = false;
                dgvCosts.Columns["cBDAmountDataGridViewTextBoxColumn"].Visible = false;
                dgvCosts.Columns["cBDAmountDataGridViewTextBoxColumn"].ReadOnly = true;
                dgvCosts.Columns["CTGAmount"].ReadOnly = true;
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (Search_Click != null)
                Search_Click(sender, e);
        }

        public void BindingCost(List<ProjectCostModel> list)
        {
            if (list != null)
            {
                try
                {
                    //BindingSource bindingLine = new BindingSource();
                    //bindingLine.DataSource = list.OrderBy(o => o.CostCode);
                    bindingMatReturnNav.BindingSource = bindingBudgets;

                    SetCostGrid();
                    dgvCosts.Refresh();
                }
                catch
                {
                    SetCostGrid();
                    return;
                }
            }
        }

        private void SetCostGrid()
        {
            dgvCosts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;            
            dgvCosts.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvCosts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCosts.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvCosts.MultiSelect = true;
            dgvCosts.RowHeadersVisible = true;

            dgvCosts.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCosts.AllowUserToResizeColumns = true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (Save_Click != null)
                Save_Click(sender, e);
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            if (Clear_Click != null)
                Clear_Click(sender, e);
        }

        private void dgvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Selected_Project != null)
                Selected_Project(sender, e);
        }

        private void mnuPasteRows_Click(object sender, EventArgs e)
        {
            if (Paste_Rows != null)
                Paste_Rows(sender, e);
        }

        public void PasteClipboard()
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    int myRowIndex = dgvCosts.CurrentRow.Index;// - 1;

                    using (DataGridViewRow myDataGridViewRow = dgvCosts.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i+1].Value = pastedRowCells[i];
                    }
                    dgvCosts.Rows.Add();
                }
            }
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(sender, e);
        }

        private void dgvCosts_SelectionChanged(object sender, EventArgs e)
        {
            if (GetLine_Selected != null)
                GetLine_Selected(sender, e);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (Paste_Rows != null)
                Paste_Rows(sender, e);
        }

        private void mnuDel_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(sender, e);
        }

        private void dgvCosts_SelectionChanged_1(object sender, EventArgs e)
        {
            if (GetLine_Selected != null)
                GetLine_Selected(sender, e);
        }

        private async void butUpdateAllCost_Click(object sender, EventArgs e)
        {

            if (Reset_Cost != null)
                Reset_Cost(dgvCosts, e);

            if (Selected_Project != null)
                Selected_Project(dgvCosts, e);
        }
    }
}
