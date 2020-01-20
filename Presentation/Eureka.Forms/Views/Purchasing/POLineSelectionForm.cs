using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Purchasing
{
    public partial class POLineSelectionForm : MetroForm, IPOLineSelectionView
    {
        private readonly POLineSelectionPresenter _presenter;
        private int _vendorId;
        private POHeaderModel _po;
        private List<POLineModel> _line;
        private List<POLineModel> _linesSelected;
        private BindingSource bindingHead;
        private string _rcvMethod;
        private bool _selectAll;

        public POLineSelectionForm()
        {
            InitializeComponent();
            _presenter = new POLineSelectionPresenter(this);
            bindingHead = new BindingSource();
            _selectAll = false;

        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public int vendorId
        {
            get { return _vendorId; }
            set { _vendorId = value; }
        }

        public POHeaderModel po
        {
            get
            {
                return _po;
            }
            set
            {
                _po = value;
                txtPONum.Text = _po.PoNum;
            }
        }

        public List<POLineModel> line
        {
            get { return _line; }
            set { _line = value; }
        }

        public List<POLineModel> linesSelected
        {
            get { return _linesSelected; }
            set { _linesSelected = value; }
        }

        public string poNumber
        {
            get { return txtPONum.Text; }
            set { txtPONum.Text = _po.PoNum; }
        }

        public string rcvMethod
        {
            get { return _rcvMethod; }
            set { _rcvMethod = value; }
        }
        
        public bool selectAll
        {
            get { return _selectAll; }
            set
            {
                _selectAll = value;

                butSelectAll.Text = _selectAll ? "Unselect All" : "Select All";
            }
        }

        public event EventHandler Form_Load;

        public event EventHandler SearchPO_Click;

        //public event EventHandler SelectAll_Checked;

        public event EventHandler OK_Click;

        public void BindingData(List<POLineModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingHead.DataSource = list;
                    bindingNav.BindingSource = bindingHead;
                    dgvLine.DataSource = bindingHead;

                    SetGrid();
                }
                catch
                {
                    SetGrid();
                    return;
                }
            }
        }

        private void SetGrid()
        {
            //dgvLine.Columns[0].Visible = false;
            dgvLine.Columns[1].Visible = false;
            dgvLine.Columns[2].Visible = false;
            dgvLine.Columns[3].Visible = false;
            //dgvLine.Columns[4].Visible = false;
            //dgvLine.Columns[5].Visible = false;
            //dgvLine.Columns[6].Visible = false;
            //dgvLine.Columns[7].Visible = false;
            //dgvLine.Columns[8].Visible = false;
            //dgvLine.Columns[9].Visible = false;
            //dgvLine.Columns[10].Visible = false;
            //dgvLine.Columns[11].Visible = false;
            //dgvLine.Columns[12].Visible = false;
            //dgvLine.Columns[13].Visible = false;
            //dgvLine.Columns[14].Visible = false;
            //dgvLine.Columns[15].Visible = false;
            //dgvLine.Columns[16].Visible = false;
            //dgvLine.Columns[17].Visible = false;
            //dgvLine.Columns[18].Visible = false;
            //dgvLine.Columns[19].Visible = false;
            //dgvLine.Columns[20].Visible = false;
            //dgvLine.Columns[21].Visible = false;
            dgvLine.Columns[22].Visible = false;
            dgvLine.Columns[23].Visible = false;
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
            dgvLine.Columns[38].Visible = false;
            dgvLine.Columns[39].Visible = false;
            dgvLine.Columns[40].Visible = false;
            //dgvLine.Columns[41].Visible = false;
            dgvLine.Columns[42].Visible = false;

            //dgvLine.Columns[20].ty = DataGridViewComboBoxColumn

            dgvLine.Columns[6].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[13].DefaultCellStyle.Format = "#,##0.00";
            dgvLine.Columns[14].DefaultCellStyle.Format = "dd/MM/yy";
            dgvLine.Columns[18].DefaultCellStyle.Format = "dd/MM/yy";
            dgvLine.Columns[19].DefaultCellStyle.Format = "#,##0.00";

            dgvLine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLine.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLine.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLine.MultiSelect = true;
            dgvLine.RowHeadersVisible = true;

            dgvLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLine.AllowUserToResizeColumns = true;
            dgvLine.Columns[0].ReadOnly = false;
            dgvLine.Columns[2].ReadOnly = true;
            dgvLine.Columns[4].ReadOnly = true;
            dgvLine.Columns[5].ReadOnly = true;
            dgvLine.Columns[6].ReadOnly = true;
            dgvLine.Columns[7].ReadOnly = true;
            dgvLine.Columns[8].ReadOnly = true;
            dgvLine.Columns[9].ReadOnly = true;
            dgvLine.Columns[10].ReadOnly = true;
            dgvLine.Columns[11].ReadOnly = true;
            dgvLine.Columns[12].ReadOnly = true;
            dgvLine.Columns[13].ReadOnly = true;
            dgvLine.Columns[14].ReadOnly = true;
            dgvLine.Columns[15].ReadOnly = true;
            dgvLine.Columns[16].ReadOnly = true;
            dgvLine.Columns[17].ReadOnly = true;
            dgvLine.Columns[18].ReadOnly = true;
            dgvLine.Columns[19].ReadOnly = true;
            dgvLine.Columns[20].ReadOnly = true;
            dgvLine.Columns[21].ReadOnly = true;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void POLineSelectionForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void txtPONum_ButtonClick(object sender, EventArgs e)
        {
            if (SearchPO_Click != null)
                SearchPO_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (OK_Click != null)
                OK_Click(this.dgvLine, e);
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (OK_Click != null)
                OK_Click(this.dgvLine, e);
        }

        private void txtPONum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPO_Click(sender, e);
            }
        }

        private void butSelectAll_Click(object sender, EventArgs e)
        {
            selectAll = selectAll ? false : true;

            foreach (DataGridViewRow row in this.dgvLine.Rows)
            {
                row.Cells[0].Value = selectAll;
            }
        }
    }
}