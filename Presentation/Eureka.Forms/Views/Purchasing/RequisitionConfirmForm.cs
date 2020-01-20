using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Purchasing
{
    public partial class RequisitionConfirmForm : MetroForm, IRequisitionConfirmView
    {
        private RequisitionConfirmPresenter _presenter;
        private ProjectModel _projectFilter;
        private BomNumberModel _bomsFilter;
        private RequisitionHeaderModel _reqheadFilter;
        private ItemMasterModel _itemsFilter;
        private List<RequisitionLineModel> _linesSelected;
        private List<RequisitionLineModel> _reqLines;
        private List<ProjectCostModel> _projBudget;

        public RequisitionConfirmForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            _presenter = new RequisitionConfirmPresenter(this);

            this.dgvBudget.RowPrePaint
            += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                this.dgvBudget_RowPrePaint);
        }

        private void dgvBudget_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            double budgetRemaining = (double)dgvBudget.Rows[e.RowIndex].Cells["RemainPercentage"].Value;
            if (budgetRemaining > 25)
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (budgetRemaining <= 25 && budgetRemaining != 0)
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        public List<RequisitionLineModel> linesSelected
        {
            get { return _linesSelected; }
            set { _linesSelected = value; }
        }
        public List<RequisitionLineModel> reqLines
        {
            get { return _reqLines; }
            set { _reqLines = value; }
        }
        public List<ProjectCostModel> projBudget
        {
            get { return _projBudget; }
            set { _projBudget = value; }
        }
        public ProjectModel projectParam
        {
            get { return _projectFilter; }
            set { _projectFilter = value; }
        }
        public BomNumberModel bomsParam
        {
            get { return _bomsFilter; }
            set { _bomsFilter = value; }
        }
        public RequisitionHeaderModel reqheadParam
        {
            get { return _reqheadFilter; }
            set { _reqheadFilter = value; }
        }
        public ItemMasterModel itemsParam
        {
            get { return _itemsFilter; }
            set { _itemsFilter = value; }
        }
        public BindingSource bindingLines
        {
            get { return requisitionLineModelBindingSource; }
            set { requisitionLineModelBindingSource = value; }
        }
        public BindingSource bindingBudgetLines
        {
            get { return projectCostModelBindingSource; }
            set { projectCostModelBindingSource = value; }
        }

        public string projectNumber
        {
            get { return txtprojectNumber.Text; }
            set { txtprojectNumber.Text = value; }
        }
        public string bomNumber
        {
            get { return txtBomNumber.Text; }
            set { txtBomNumber.Text = value; }
        }
        public string requisitionNumber
        {
            get { return txtRequisitionNumber.Text; }
            set { txtRequisitionNumber.Text = value; }
        }
        public string itemNumber
        {
            get { return txtitemNumber.Text; }
            set { txtitemNumber.Text = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public string SortBy
        {
            get { return cboSort.Text; }
            set { cboSort.Text = value; }
        }
        public string SortType
        {
            get { return cboSortType.Text; }
            set { cboSortType.Text = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Filter_Click;
        public event EventHandler Save_Changed;
        public event EventHandler Find_Project;
        public event EventHandler Find_Bom;
        public event EventHandler Find_Requistion;
        public event EventHandler Find_Item;
        public event EventHandler Find_Vendor;
        public event EventHandler ConfirmPrice_Click;
        public event EventHandler UnConfirmPrice_Click;
        public event EventHandler Selection_Changed;
        public event EventHandler Refresh_Lines;
        public event EventHandler Sorting_Changed;
        public event EventHandler Change_Cost;

        public void BindCheckBox()
        {
            throw new NotImplementedException();
        }

        public void BindingBudgetLines(List<ProjectCostModel> list)
        {
            if (list != null)
            {
                if (list != null)
                {
                    try
                    {
                        dgvBudget.Rows.Clear();
                        bindingBudgetLines.DataSource = null;
                        bindingBudgetLines.DataSource = projBudget;
                        SetBudgetGrid();
                    }
                    catch
                    {
                        dgvBudget.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void SetBudgetGrid()
        {
            dgvBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvBudget.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBudget.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBudget.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvBudget.MultiSelect = true;
            dgvBudget.RowHeadersVisible = true;
            dgvBudget.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        public void BindingLines(List<RequisitionLineModel> list)
        {
            if (list != null)
            {
                if (list != null)
                {
                    try
                    {
                        dgvReqLines.Rows.Clear();
                        bindingLines.DataSource = null;
                        bindingLines.DataSource = reqLines;
                        bndNavReqLines.BindingSource = bindingLines;
                        SetLinesGrid();
                    }
                    catch
                    {
                        dgvReqLines.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void SetLinesGrid()
        {
            dgvReqLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvReqLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvReqLines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvReqLines.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReqLines.MultiSelect = true;
            dgvReqLines.RowHeadersVisible = true;
        }

        public void RefreshBudgetGrid()
        {
            dgvBudget.Refresh();
        }

        public void RefreshLinesGird()
        {
            dgvReqLines.Refresh();
        }

        private void RequisitionConfirmForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);

            cboSort.SelectedIndex = 0;
            cboSortType.SelectedIndex = 0;
        }

        private void txtprojectNumber_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Project != null)
                Find_Project(sender, e);
        }

        private void txtprojectNumber_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtprojectNumber.Text))
            {
                if (Find_Project != null)
                    Find_Project(sender, e);
            }
        }

        private void txtBomNumber_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Bom != null)
                Find_Bom(sender, e);
        }

        private void txtBomNumber_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBomNumber.Text))
            {
                if (Find_Bom != null)
                    Find_Bom(sender, e);
            }
        }

        private void txtRequisitionNumber_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Requistion != null)
                Find_Requistion(sender, e);
        }

        private void txtRequisitionNumber_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRequisitionNumber.Text))
            {
                if (Find_Requistion != null)
                    Find_Requistion(sender, e);
            }
        }

        private void txtitemNumber_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtitemNumber.Text))
            {
                if (Find_Item != null)
                    Find_Item(sender, e);
            }
        }

        private void butFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void txtprojectNumber_ClearClicked()
        {
            projectNumber = string.Empty;
            projectParam = null;
        }

        private void txtBomNumber_ClearClicked()
        {
            bomNumber = string.Empty;
            bomsParam = null;
        }

        private void txtRequisitionNumber_ClearClicked()
        {
            requisitionNumber = string.Empty;
            reqheadParam = null;
        }


        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (Save_Changed != null)
                Save_Changed(dgvReqLines, e);
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (Refresh_Lines != null)
                Refresh_Lines(dgvReqLines, e);
        }

        private void mnuConfirm_Click(object sender, EventArgs e)
        {
            if (ConfirmPrice_Click != null)
                ConfirmPrice_Click(dgvReqLines, e);
        }

        private void dgvReqLines_SelectionChanged(object sender, EventArgs e)
        {
            if (Selection_Changed != null)
                Selection_Changed(sender, e);
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sorting_Changed != null)
                Sorting_Changed(sender, e);
        }

        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sorting_Changed != null)
                Sorting_Changed(sender, e);
        }

        private void mnuChangeCost_Click(object sender, EventArgs e)
        {
            if (Change_Cost != null)
                Change_Cost(dgvReqLines, e);
        }
    }
}
