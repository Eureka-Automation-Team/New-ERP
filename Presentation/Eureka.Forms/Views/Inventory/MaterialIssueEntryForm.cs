using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Inventory;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public partial class MaterialIssueEntryForm : MetroForm, IMaterialIssueEntryView
    {
        private readonly MaterialIssueEntryPresenter _presenter;
        private MaterialIssueModel _head;
        private IEnumerable<ItemOnhandModel> _onhandsSelected;
        //private BindingSource bindingHead;

        public MaterialIssueEntryForm(IEnumerable<ItemOnhandModel> issueList)
        {
            InitializeComponent();
            _presenter = new MaterialIssueEntryPresenter(this);

            //bindingHead = new BindingSource();
            onhandsSelected = issueList;
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public MaterialIssueModel head
        {
            get
            {
                _head.IssueDate = dtpIssueDate.Value;

                return _head;
            }
            set
            {
                _head = value;
                txtIssueNumber.Text = _head.IssueNumber;
                txtIssueName.Text = _head.IssueByName;
                dtpIssueDate.Value = _head.IssueDate;
            }
        }

        public IEnumerable<ItemOnhandModel> onhandsSelected
        {
            get { return _onhandsSelected; }
            set { _onhandsSelected = value; }
        }
        
        public BindingSource bindingHead
        {
            get { return itemOnhandModelBindingSource; }
            set { itemOnhandModelBindingSource = value; }
        }

        public event EventHandler Form_Load;

        public event EventHandler Save_Click;

        public event EventHandler GenerateNumber;

        //public event EventHandler Refresh_Click;

        public event EventHandler Validate_Lines;

        public void BindingData()
        {
            try
            {
                //bindingHead.DataSource = list;
                bindingNav.BindingSource = bindingHead;
                //dgvLine.DataSource = bindingHead;

                SetLineGrid();
            }
            catch
            {
                SetLineGrid();
                return;
            }
        }

        public void DataGridViewLoop()
        {
            try
            {
                foreach (DataGridViewRow FileListRow in dgvLine.Rows)
                {
                    UpdateDGVcolumn(FileListRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateDGVcolumn(int RowNum)
        {
            dgvLine[0, RowNum].Value = dgvLine[17, RowNum].Value;
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
            //dgvLine.Columns[35].Visible = false;
            dgvLine.Columns[36].Visible = false;

            dgvLine.Columns[0].HeaderText = "Issue Qty.";
            dgvLine.Columns[3].HeaderText = "ERP-Item No.";
            dgvLine.Columns[4].HeaderText = "PART NAME/Description";
            dgvLine.Columns[5].HeaderText = "MANU ID";
            dgvLine.Columns[6].HeaderText = "Brand/Mat";
            dgvLine.Columns[7].HeaderText = "BOM";
            dgvLine.Columns[15].HeaderText = "Balance Qty.";
            dgvLine.Columns[16].HeaderText = "UOM";
            dgvLine.Columns[18].HeaderText = "Subinventory";
            dgvLine.Columns[23].HeaderText = "Lot No.";
            dgvLine.Columns[35].HeaderText = "Reserved Qty.";

            dgvLine.Columns[15].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[35].DefaultCellStyle.Format = "#,##0";

            dgvLine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            dgvLine.Columns[35].ReadOnly = true;
            */
        }

        public void LineRefresh()
        {
            throw new NotImplementedException();
        }

        private void MaterialIssueEntryForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void butGenNumber_Click(object sender, EventArgs e)
        {
            if (GenerateNumber != null)
                GenerateNumber(sender, e);
        }

        private void bdNavSave_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (Save_Click != null)
                Save_Click(dgvLine, e);
        }

        public void ValidateLines()
        {
            if (Validate_Lines != null)
                Validate_Lines(dgvLine, null);
        }

        private void dgvLine_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double newInteger;
            if (e.ColumnIndex == 0)
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
                {
                    MessageBox.Show("Invalid input number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                double receivedQty = newInteger;
                double onhandQty = dgvLine[17, e.RowIndex].Value.AsDouble();
                if (newInteger > onhandQty)
                {
                    MessageBox.Show("Issue qty. must less than or equal Balance Qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        public void CloseForm()
        {
            this.Close();
        }
    }
}