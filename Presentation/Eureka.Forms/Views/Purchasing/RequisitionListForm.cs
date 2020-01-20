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
    public partial class RequisitionListForm : MetroForm, IRequisitionListView
    {
        private readonly RequisitionListPresenter _presenter;
        private List<RequisitionHeaderModel> _prs;
        private List<RequisitionHeaderModel> _prsSelected;
        private IPagedList<RequisitionHeaderModel> _list;
        private int _pageNumber;

        public RequisitionListForm(List<RequisitionHeaderModel> prList)
        {
            InitializeComponent();
            _presenter = new RequisitionListPresenter(this);

            if (prList != null)
                prs = prList;
        }

        public int pageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }
        public IPagedList<RequisitionHeaderModel> list
        {
            get { return _list; }
            set { _list = value; }
        }
        public string projectNo
        {
            get { return txtProjectNum.Text; }
            set { txtProjectNum.Text = value; }
        }
        public string requisitonNo
        {
            get { return txtRequisitionNumber.Text; }
            set { txtRequisitionNumber.Text = value; }
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
        public List<RequisitionHeaderModel> prs
        {
            get { return _prs; }
            set { _prs = value; }
        }
        public List<RequisitionHeaderModel> prsSelected
        {
            get { return _prsSelected; }
            set { _prsSelected = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public BindingSource bindingHead
        {
            get { return requisitionHeaderModelBindingSource; }
            set { requisitionHeaderModelBindingSource = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        //public event EventHandler PreviousPage;
        //public event EventHandler NextPage;

        public void BindingData(IPagedList<RequisitionHeaderModel> list)
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
                    //dgvList.DataSource = bindingHead;

                    SetPOGrid();
                }
                catch
                {
                    dgvList.Rows.Clear();
                    return;
                }
            }
        }

        private void SetPOGrid()
        {
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvList.MultiSelect = false;
            dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void RequisitionListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
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

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null) return;
            if (dgvList.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
