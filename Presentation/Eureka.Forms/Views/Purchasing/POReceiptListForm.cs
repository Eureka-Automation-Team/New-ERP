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

namespace Eureka.Froms.Views.Purchasing
{
    public partial class POReceiptListForm : MetroForm, IPOReceiptListView
    {
        private POReceiptListPresenter _presenter;
        private List<POReceiptHeaderModel> _rcvs;
        private List<POReceiptHeaderModel> _rcvsSelected;
        private BindingSource bindingHead;
        private string _rcvMethod;

        public POReceiptListForm(List<POReceiptHeaderModel> list)
        {
            InitializeComponent();
            _presenter = new POReceiptListPresenter(this);
            bindingHead = new BindingSource();

            if (list != null)
                rcvs = list;
        }

        public string rcvNum
        {
            get { return txtRcvNum.Text; }
            set { txtRcvNum.Text = value; }
        }
        public string vendorNum
        {
            get { return txtVendor.Text; }
            set { txtVendor.Text = value; }
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
        public List<POReceiptHeaderModel> rcvs
        {
            get { return _rcvs; }
            set { _rcvs = value; }
        }
        public List<POReceiptHeaderModel> rcvsSelected
        {
            get { return _rcvsSelected; }
            set { _rcvsSelected = value; }
        }

        public Session EpiSession => throw new NotImplementedException();

        public string rcvMethod
        {
            get { return _rcvMethod; }
            set { _rcvMethod = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;

        public void BindingData(List<POReceiptHeaderModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingHead.DataSource = list;
                    bindingNav.BindingSource = bindingHead;
                    dgvRcvList.DataSource = bindingHead;

                    SetRcvGrid();
                }
                catch
                {
                    SetRcvGrid();
                    return;
                }
            }
        }

        private void SetRcvGrid()
        {
            dgvRcvList.Columns[0].Visible = false;
            //dgvRcvList.Columns[1].Visible = false;
            //dgvRcvList.Columns[2].Visible = false;
            dgvRcvList.Columns[3].Visible = false;
            dgvRcvList.Columns[4].Visible = false;
            dgvRcvList.Columns[5].Visible = false;
            dgvRcvList.Columns[6].Visible = false;
            dgvRcvList.Columns[7].Visible = false;
            dgvRcvList.Columns[8].Visible = false;
            dgvRcvList.Columns[9].Visible = false;
            //dgvRcvList.Columns[10].Visible = false;
            dgvRcvList.Columns[11].Visible = false;
            dgvRcvList.Columns[12].Visible = false;
            dgvRcvList.Columns[13].Visible = false;
            dgvRcvList.Columns[14].Visible = false;
            dgvRcvList.Columns[15].Visible = false;
            dgvRcvList.Columns[16].Visible = false;
            dgvRcvList.Columns[17].Visible = false;
            dgvRcvList.Columns[18].Visible = false;
            dgvRcvList.Columns[19].Visible = false;
            dgvRcvList.Columns[20].Visible = false;
            dgvRcvList.Columns[21].Visible = false;
            dgvRcvList.Columns[22].Visible = false;
            dgvRcvList.Columns[23].Visible = false;
            dgvRcvList.Columns[24].Visible = false;
            dgvRcvList.Columns[25].Visible = false;
            dgvRcvList.Columns[26].Visible = false;
            dgvRcvList.Columns[27].Visible = false;
            dgvRcvList.Columns[28].Visible = false;
            dgvRcvList.Columns[29].Visible = false;
            dgvRcvList.Columns[30].Visible = false;
            dgvRcvList.Columns[31].Visible = false;
            dgvRcvList.Columns[32].Visible = false;
            dgvRcvList.Columns[33].Visible = false;
            dgvRcvList.Columns[34].Visible = false;
            dgvRcvList.Columns[35].Visible = false;
            dgvRcvList.Columns[36].Visible = false;
            dgvRcvList.Columns[37].Visible = false;
            dgvRcvList.Columns[38].Visible = false;
            dgvRcvList.Columns[39].Visible = false;
            dgvRcvList.Columns[40].Visible = false;
            dgvRcvList.Columns[41].Visible = false;
            dgvRcvList.Columns[42].Visible = false;
            dgvRcvList.Columns[43].Visible = false;
            dgvRcvList.Columns[44].Visible = false;
            dgvRcvList.Columns[45].Visible = false;
            dgvRcvList.Columns[46].Visible = false;
            dgvRcvList.Columns[47].Visible = false;
            dgvRcvList.Columns[48].Visible = false;
            dgvRcvList.Columns[49].Visible = false;
            dgvRcvList.Columns[50].Visible = false;
            dgvRcvList.Columns[51].Visible = false;
            dgvRcvList.Columns[52].Visible = false;
            dgvRcvList.Columns[53].Visible = false;
            dgvRcvList.Columns[54].Visible = false;
            dgvRcvList.Columns[55].Visible = false;
            dgvRcvList.Columns[56].Visible = false;
            dgvRcvList.Columns[57].Visible = false;
            dgvRcvList.Columns[58].Visible = false;
            dgvRcvList.Columns[59].Visible = false;
            dgvRcvList.Columns[60].Visible = false;
            dgvRcvList.Columns[61].Visible = false;
            dgvRcvList.Columns[62].Visible = false;

            dgvRcvList.Columns[2].DefaultCellStyle.Format = "dd-MMM-yyyy";

            dgvRcvList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRcvList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRcvList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRcvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRcvList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRcvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRcvList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvRcvList.MultiSelect = true;
            dgvRcvList.RowHeadersVisible = true;

            dgvRcvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRcvList.AllowUserToResizeColumns = true;
            dgvRcvList.Columns[1].ReadOnly = true;
            dgvRcvList.Columns[2].ReadOnly = true;
            dgvRcvList.Columns[10].ReadOnly = true;
        }

        public void CloseMe()
        {
            this.Close();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Clear_Click != null)
                Clear_Click(sender, e);
        }

        private void POReceiptListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void dgvRcvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRcvList.CurrentRow == null) return;
            if (dgvRcvList.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvRcvList_MultiSelectChanged(object sender, EventArgs e)
        {
            if (dgvRcvList.CurrentRow == null) return;
            if (dgvRcvList.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvRcvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
