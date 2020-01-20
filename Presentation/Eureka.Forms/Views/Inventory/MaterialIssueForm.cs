using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Inventory;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public partial class MaterialIssueForm : MetroForm, IMaterialIssueView
    {
        private readonly MaterialIssuePresenter _presenter;
        private IEnumerable<ItemOnhandModel> _onhands;
        private IEnumerable<ItemOnhandModel> _onhandsSelected;
        private IEnumerable<ItemOnhandModel> _onhandsCache;
        private IEnumerable<ProjectModel> _projs;
        private IEnumerable<ProjectCostModel> _costs;

        private string _forProjectNo;
        private string _forCostCode;

        //private BindingSource bindingHead;
        //private BindingSource bindingCache;

        public MaterialIssueForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            _presenter = new MaterialIssuePresenter(this);

            //bindingHead = new BindingSource();
            //bindingCache = new BindingSource();
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public IEnumerable<ItemOnhandModel> onhands
        {
            get { return _onhands; }
            set { _onhands = value; }
        }

        public string projNo
        {
            get { return txtProjectNum.Text; }
            set { txtProjectNum.Text = value; }
        }

        public string bomNo
        {
            get { return txtBom.Text; }
            set { txtBom.Text = value; }
        }

        public string itemNo
        {
            get { return txtItemCode.Text; }
            set { txtItemCode.Text = value; }
        }

        public IEnumerable<ItemOnhandModel> onhandsSelected
        {
            get { return _onhandsSelected; }
            set { _onhandsSelected = value; }
        }

        public IEnumerable<ItemOnhandModel> onhandsCache
        {
            get { return _onhandsCache; }
            set { _onhandsCache = value; }
        }

        public IEnumerable<ProjectModel> projs
        {
            get { return _projs; }
            set { _projs = value; }
        }

        public IEnumerable<ProjectCostModel> costs
        {
            get { return _costs; }
            set { _costs = value; }
        }

        public string forProjectNo
        {
            get { return _forProjectNo; }
            set { _forProjectNo = value; }
        }

        public string forCostCode
        {
            get { return _forCostCode; }
            set
            {
                _forCostCode = value;

                cboCosts.Text = _forCostCode;
            }
        }
        
        public BindingSource bindingHead
        {
            get { return itemOnhandModelBindingSource; }
            set { itemOnhandModelBindingSource = value; }
        }
        
        public BindingSource bindingCache
        {
            get { return itemOnhandModelBindingSource1; }
            set { itemOnhandModelBindingSource1 = value; }
        }

        public event EventHandler Form_Load;

        public event EventHandler Filter_Click;

        //public event EventHandler Filter_Clear;

        //public event EventHandler Issue_Click;

        public event EventHandler Find_Project;

        public event EventHandler Issue_Entry;

        public event EventHandler Insert_Cache;

        public event EventHandler Delete_Cache;

        public event EventHandler Clear_Cache;

        public event EventHandler Project_Change;

        public event EventHandler CostCode_Change;

        public void BindingData(List<ItemOnhandModel> list)
        {
            try
            {
                bindingHead.DataSource = list;
                bindingNav.BindingSource = bindingHead;
                dgvLine.DataSource = bindingHead;

                SetLineGrid();
            }
            catch
            {
                SetLineGrid();
                return;
            }
        }

        private void SetLineGrid()
        {
            /*
            //dgvLine.Columns[0].Visible = false;
            dgvLine.Columns[1].Visible = false;
            dgvLine.Columns[2].Visible = false;
            //dgvLine.Columns[3].Visible = false;
            //dgvLine.Columns[4].Visible = false;
            //dgvLine.Columns[5].Visible = false;
            //dgvLine.Columns[6].Visible = false;
            //dgvLine.Columns[7].Visible = false;
            dgvLine.Columns[8].Visible = false;
            dgvLine.Columns[9].Visible = false;
            dgvLine.Columns[10].Visible = false;
            dgvLine.Columns[11].Visible = false;
            dgvLine.Columns[12].Visible = false;
            dgvLine.Columns[13].Visible = false;
            dgvLine.Columns[14].Visible = false;
            //dgvLine.Columns[15].Visible = false;
            //dgvLine.Columns[16].Visible = false;
            dgvLine.Columns[17].Visible = false;
            //dgvLine.Columns[18].Visible = false;
            dgvLine.Columns[19].Visible = false;
            dgvLine.Columns[20].Visible = false;
            dgvLine.Columns[21].Visible = false;
            dgvLine.Columns[22].Visible = false;
            //dgvLine.Columns[23].Visible = false;
            dgvLine.Columns[24].Visible = false;
            dgvLine.Columns[25].Visible = false;
            dgvLine.Columns[26].Visible = false;
            dgvLine.Columns[27].Visible = false;
            dgvLine.Columns[28].Visible = false;
            dgvLine.Columns[29].Visible = false;
            dgvLine.Columns[30].Visible = false;
            dgvLine.Columns[31].Visible = false;
            dgvLine.Columns[32].Visible = false;
            dgvLine.Columns[33].Visible = false;
            dgvLine.Columns[34].Visible = false;
            dgvLine.Columns[35].Visible = false;
            dgvLine.Columns[36].Visible = false;
            dgvLine.Columns[37].Visible = false;
            //dgvLine.Columns[38].Visible = false;
            dgvLine.Columns[39].Visible = false;
            dgvLine.Columns[40].Visible = false;
            dgvLine.Columns[41].Visible = false;
            dgvLine.Columns[42].Visible = false;

            dgvLine.Columns[0].HeaderText = "Select";
            dgvLine.Columns[3].HeaderText = "ERP-Item No.";
            dgvLine.Columns[4].HeaderText = "PART NAME/Description";
            dgvLine.Columns[5].HeaderText = "MANU ID";
            dgvLine.Columns[6].HeaderText = "Brand/Mat";
            dgvLine.Columns[7].HeaderText = "BOM";
            dgvLine.Columns[15].HeaderText = "Balance Qty.";
            dgvLine.Columns[16].HeaderText = "UOM";
            dgvLine.Columns[18].HeaderText = "Subinventory";
            dgvLine.Columns[23].HeaderText = "Lot No.";
            dgvLine.Columns[38].HeaderText = "Reserved Qty.";

            dgvLine.Columns[15].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[38].DefaultCellStyle.Format = "#,##0";

            dgvLine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            */
            dgvLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLine.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLine.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLine.MultiSelect = true;
            dgvLine.RowHeadersVisible = true;

            dgvLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLine.AllowUserToResizeColumns = true;
            /*
            dgvLine.Columns[0].ReadOnly = false;
            dgvLine.Columns[3].ReadOnly = true;
            dgvLine.Columns[4].ReadOnly = true;
            dgvLine.Columns[5].ReadOnly = true;
            dgvLine.Columns[6].ReadOnly = true;
            dgvLine.Columns[7].ReadOnly = true;
            dgvLine.Columns[15].ReadOnly = true;
            dgvLine.Columns[16].ReadOnly = true;
            dgvLine.Columns[18].ReadOnly = true;
            dgvLine.Columns[23].ReadOnly = true;
            dgvLine.Columns[38].ReadOnly = true;*/
        }

        private void MaterialIssueForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bdNavFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void txtProjectNum_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Project != null)
                Find_Project(sender, e);
        }

        private void bdNavSave_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (Issue_Entry != null)
                Issue_Entry(dgvLine, e);
        }

        public void BindingCache(List<ItemOnhandModel> list)
        {
            try
            {
                bindingCache.DataSource = list;
                bindingNavigator1.BindingSource = bindingCache;
                dgvCacheList.DataSource = bindingCache;

                SetCacheGrid();
            }
            catch
            {
                SetCacheGrid();
                return;
            }
        }

        private void SetCacheGrid()
        {
            /*
            //dgvCacheList.Columns[0].Visible = false;
            dgvCacheList.Columns[0].Visible = false;
            dgvCacheList.Columns[1].Visible = false;
            //dgvCacheList.Columns[2].Visible = false;
            //dgvCacheList.Columns[3].Visible = false;
            //dgvCacheList.Columns[4].Visible = false;
            //dgvCacheList.Columns[5].Visible = false;
            //dgvCacheList.Columns[6].Visible = false;
            dgvCacheList.Columns[7].Visible = false;
            dgvCacheList.Columns[8].Visible = false;
            dgvCacheList.Columns[9].Visible = false;
            dgvCacheList.Columns[10].Visible = false;
            dgvCacheList.Columns[11].Visible = false;
            dgvCacheList.Columns[12].Visible = false;
            dgvCacheList.Columns[13].Visible = false;
            //dgvCacheList.Columns[14].Visible = false;
            //dgvCacheList.Columns[15].Visible = false;
            dgvCacheList.Columns[16].Visible = false;
            //dgvCacheList.Columns[17].Visible = false;
            dgvCacheList.Columns[18].Visible = false;
            dgvCacheList.Columns[19].Visible = false;
            dgvCacheList.Columns[20].Visible = false;
            dgvCacheList.Columns[21].Visible = false;
            //dgvCacheList.Columns[22].Visible = false;
            dgvCacheList.Columns[23].Visible = false;
            dgvCacheList.Columns[24].Visible = false;
            dgvCacheList.Columns[25].Visible = false;
            dgvCacheList.Columns[26].Visible = false;
            dgvCacheList.Columns[27].Visible = false;
            dgvCacheList.Columns[28].Visible = false;
            dgvCacheList.Columns[29].Visible = false;
            dgvCacheList.Columns[30].Visible = false;
            dgvCacheList.Columns[31].Visible = false;
            dgvCacheList.Columns[32].Visible = false;
            dgvCacheList.Columns[33].Visible = false;
            dgvCacheList.Columns[34].Visible = false;
            dgvCacheList.Columns[35].Visible = false;
            dgvCacheList.Columns[36].Visible = false;
            dgvCacheList.Columns[37].Visible = false;
            dgvCacheList.Columns[38].Visible = false;
            dgvCacheList.Columns[39].Visible = false;
            dgvCacheList.Columns[40].Visible = false;
            dgvCacheList.Columns[41].Visible = false;
            //dgvCacheList.Columns[42].Visible = false;

            dgvCacheList.Columns[2].HeaderText = "ERP-Item No.";
            dgvCacheList.Columns[3].HeaderText = "PART NAME/Description";
            dgvCacheList.Columns[4].HeaderText = "MANU ID";
            dgvCacheList.Columns[5].HeaderText = "Brand/Mat";
            dgvCacheList.Columns[6].HeaderText = "BOM";
            dgvCacheList.Columns[14].HeaderText = "Balance Qty.";
            dgvCacheList.Columns[15].HeaderText = "UOM";
            dgvCacheList.Columns[17].HeaderText = "Subinventory";
            dgvCacheList.Columns[22].HeaderText = "Lot No.";
            //dgvCacheList.Columns[35].HeaderText = "Reserved Qty.";

            dgvCacheList.Columns[14].DefaultCellStyle.Format = "#,##0";
            //dgvCacheList.Columns[34].DefaultCellStyle.Format = "#,##0";

            dgvCacheList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCacheList.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCacheList.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCacheList.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCacheList.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvCacheList.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            */
            dgvCacheList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvCacheList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvCacheList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCacheList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvCacheList.MultiSelect = true;
            dgvCacheList.RowHeadersVisible = true;

            dgvCacheList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCacheList.AllowUserToResizeColumns = true;
            /*
            dgvCacheList.Columns[2].ReadOnly = true;
            dgvCacheList.Columns[3].ReadOnly = true;
            dgvCacheList.Columns[4].ReadOnly = true;
            dgvCacheList.Columns[5].ReadOnly = true;
            dgvCacheList.Columns[6].ReadOnly = true;
            dgvCacheList.Columns[14].ReadOnly = true;
            dgvCacheList.Columns[15].ReadOnly = true;
            dgvCacheList.Columns[17].ReadOnly = true;
            dgvCacheList.Columns[22].ReadOnly = true;
            dgvCacheList.Columns[38].ReadOnly = true;
            dgvCacheList.Columns[39].ReadOnly = true;*/
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (Insert_Cache != null)
                Insert_Cache(dgvLine, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (Insert_Cache != null)
                Insert_Cache(dgvLine, e);
        }

        private void mnuClearList_Click(object sender, EventArgs e)
        {
            if (Clear_Cache != null)
                Clear_Cache(dgvLine, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dgvCacheList.EndEdit();

            if (Delete_Cache != null)
                Delete_Cache(dgvCacheList, e);
        }

        public void BindingComboProjects(List<ProjectModel> projs)
        {
            cboProjects.Items.Clear();
            cboProjects.DataSource = projs;
            cboProjects.DisplayMember = "ProjectNum";
            cboProjects.ValueMember = "Id";
            cboProjects.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboProjects.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cboProjects_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Project_Change != null)
                Project_Change(sender, e);
        }

        public void BindingComboProjectsCost(List<ProjectCostModel> costs)
        {
            cboCosts.Text = string.Empty;
            cboCosts.DataSource = costs;
            cboCosts.DisplayMember = "CostCode";
            cboCosts.ValueMember = "CostId";
            cboCosts.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboCosts.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cboProjects_TextChanged(object sender, EventArgs e)
        {
            if (Project_Change != null)
                Project_Change(sender, e);
        }

        private void cboCosts_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CostCode_Change != null)
                CostCode_Change(sender, e);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvLine.Rows)
            {
                row.Cells[0].Value = chkAll.Checked;
            }
        }
    }
}