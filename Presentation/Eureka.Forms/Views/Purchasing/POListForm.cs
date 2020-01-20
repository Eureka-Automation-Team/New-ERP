using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
using MetroFramework.Forms;
using PagedList;
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
    public partial class POListForm : MetroForm, IPOListView
    {
        private readonly POListPresenter _presenter;
        private BindingSource bindingHead;
        private List<POHeaderModel> _pos;
        private List<POHeaderModel> _posSelected;
        private int _vendorId;
        private int _pageNumber;
        private IPagedList<POHeaderModel> _list;

        public POListForm(List<POHeaderModel> poList)
        {
            InitializeComponent();
            _presenter = new POListPresenter(this);
            bindingHead = new BindingSource();

            if (poList != null)
                pos = poList;
        }

        public string poNum
        { get { return txtPONum.Text; } set { txtPONum.Text = value; } }
        public List<POHeaderModel> pos { get { return _pos; } set { _pos = value; } }
        public List<POHeaderModel> posSelected { get { return _posSelected; } set { _posSelected = value; } }
        public DateTime startDate { get { return dtpStartDate.Value; } set { dtpStartDate.Value = value; } }
        public DateTime endDate { get { return dtpEndDate.Value; } set { dtpEndDate.Value = value; } }

        public string buyer { get { return txtbuyer.Text; } set { txtbuyer.Text = value; } }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public int vendorId { get { return _vendorId; } set { _vendorId = value; } }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<POHeaderModel> list { get { return _list; } set { _list = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<POHeaderModel> list)
        {
            if (list != null)
            {
                try
                {
                    butPreviousPage.Enabled = list.HasPreviousPage;
                    butNextPage.Enabled = list.HasNextPage;
                    txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                    bindingHead.DataSource = list.ToList();
                    bindingNav.BindingSource = bindingHead;
                    dgvPoList.DataSource = bindingHead;

                    SetPOGrid();
                }
                catch
                {
                    dgvPoList.Rows.Clear();
                    return;
                }
            }
        }

        private void SetPOGrid()
        {
            dgvPoList.Columns[0].Visible = false;
            //dgvPoList.Columns[1].Visible = false;
            //dgvPoList.Columns[2].Visible = false;
            dgvPoList.Columns[3].Visible = false;
            dgvPoList.Columns[4].Visible = false;
            dgvPoList.Columns[5].Visible = false;
            dgvPoList.Columns[6].Visible = false;
            dgvPoList.Columns[7].Visible = false;
            dgvPoList.Columns[8].Visible = false;
            dgvPoList.Columns[9].Visible = false;
            dgvPoList.Columns[10].Visible = false;
            dgvPoList.Columns[11].Visible = false;
            dgvPoList.Columns[12].Visible = false;
            dgvPoList.Columns[13].Visible = false;
            dgvPoList.Columns[14].Visible = false;
            dgvPoList.Columns[15].Visible = false;
            dgvPoList.Columns[16].Visible = false;
            dgvPoList.Columns[17].Visible = false;
            dgvPoList.Columns[18].Visible = false;
            dgvPoList.Columns[19].Visible = false;
            dgvPoList.Columns[20].Visible = false;
            dgvPoList.Columns[21].Visible = false;
            dgvPoList.Columns[22].Visible = false;
            dgvPoList.Columns[23].Visible = false;
            dgvPoList.Columns[24].Visible = false;
            dgvPoList.Columns[25].Visible = false;
            dgvPoList.Columns[26].Visible = false;
            dgvPoList.Columns[27].Visible = false;
            dgvPoList.Columns[28].Visible = false;
            dgvPoList.Columns[29].Visible = false;
            dgvPoList.Columns[30].Visible = false;
            dgvPoList.Columns[31].Visible = false;
            dgvPoList.Columns[32].Visible = false;
            dgvPoList.Columns[33].Visible = false;
            dgvPoList.Columns[34].Visible = false;
            dgvPoList.Columns[35].Visible = false;
            dgvPoList.Columns[36].Visible = false;
            dgvPoList.Columns[37].Visible = false;
            dgvPoList.Columns[38].Visible = false;
            dgvPoList.Columns[39].Visible = false;
            dgvPoList.Columns[40].Visible = false;
            dgvPoList.Columns[41].Visible = false;
            dgvPoList.Columns[42].Visible = false;
            dgvPoList.Columns[43].Visible = false;
            dgvPoList.Columns[44].Visible = false;
            dgvPoList.Columns[45].Visible = false;
            dgvPoList.Columns[46].Visible = false;

            //dgvPoList.Columns[47].Visible = false;
            //dgvPoList.Columns[48].Visible = false;

            dgvPoList.Columns[2].DefaultCellStyle.Format = "dd-MMM-yyyy";

            dgvPoList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPoList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPoList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvPoList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPoList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPoList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvPoList.MultiSelect = true;
            dgvPoList.RowHeadersVisible = true;

            dgvPoList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPoList.AllowUserToResizeColumns = true;
            dgvPoList.Columns[1].ReadOnly = true;
            dgvPoList.Columns[2].ReadOnly = true;
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

        private void POListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Clear_Click != null)
                Clear_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }

        private void dgvPoList_MultiSelectChanged(object sender, EventArgs e)
        {
            if (dgvPoList.CurrentRow == null) return;
            if (dgvPoList.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvPoList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPoList.CurrentRow == null) return;
            if (dgvPoList.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvPoList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }

        private void butPreviousPage_Click(object sender, EventArgs e)
        {
            if (PreviousPage != null)
                PreviousPage(sender, e);
        }

        private void butNextPage_Click(object sender, EventArgs e)
        {
            if (NextPage != null)
                NextPage(sender, e);
        }
    }
}
