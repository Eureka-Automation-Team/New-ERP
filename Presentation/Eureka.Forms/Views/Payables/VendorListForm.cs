using Eureka.Core.Domain.Payables;
using Eureka.Froms.Presentations.Payables;
using MetroFramework.Forms;
using PagedList;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Payables
{
    public partial class VendorListForm : MetroForm, IVendorListView
    {
        private VendorsListPresenter _presenter;
        private List<VendorModel> _vendors;
        private VendorModel _vendorSelected;
        private BindingSource bindingLine;
        private int _pageNumber;
        private IPagedList<VendorModel> _list;

        public VendorListForm()
        {
            InitializeComponent();
            _presenter = new VendorsListPresenter(this);
            bindingLine = new BindingSource();
        }

        public string VendorNumber
        { get { return txtVendorNum.Text; } set { txtVendorNum.Text = value; } }

        public string VendorName
        { get { return txtVendorName.Text; } set { txtVendorName.Text = value; } }

        public List<VendorModel> vendors { get { return _vendors; } set { _vendors = value; } }
        public VendorModel vendorSelected { get { return _vendorSelected; } set { _vendorSelected = value; } }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<VendorModel> list { get { return _list; } set { _list = value; } }

        public event EventHandler Form_Load;

        public event EventHandler OK_Click;

        public event EventHandler Filter_Click;

        public event EventHandler Selecting_Row;
        public event EventHandler Clear_Click;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<VendorModel> list)
        {
            if (list != null)
            {
                try
                {
                    butPreviousPage.Enabled = list.HasPreviousPage;
                    butNextPage.Enabled = list.HasNextPage;
                    txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                    bindingLine.DataSource = list;
                    bindingNav.BindingSource = bindingLine;
                    dgvVendors.DataSource = bindingLine;

                    //SetPOGrid();
                }
                catch
                {
                    dgvVendors.Rows.Clear();
                    return;
                }
            }
        }

        private void SetPOGrid()
        {
            dgvVendors.Columns[0].Visible = false;
            //dgvVendors.Columns[1].Visible = false;
            //dgvVendors.Columns[2].Visible = false;
            dgvVendors.Columns[3].Visible = false;
            dgvVendors.Columns[4].Visible = false;
            dgvVendors.Columns[5].Visible = false;
            dgvVendors.Columns[6].Visible = false;
            dgvVendors.Columns[7].Visible = false;
            dgvVendors.Columns[8].Visible = false;
            dgvVendors.Columns[9].Visible = false;
            dgvVendors.Columns[10].Visible = false;
            dgvVendors.Columns[11].Visible = false;
            dgvVendors.Columns[12].Visible = false;
            dgvVendors.Columns[13].Visible = false;
            dgvVendors.Columns[14].Visible = false;
            dgvVendors.Columns[15].Visible = false;

            //dgvVendors.Columns[2] = new DataGridViewComboBoxColumn();

            dgvVendors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendors.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendors.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvVendors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvVendors.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvVendors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvVendors.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvVendors.MultiSelect = false;
            dgvVendors.RowHeadersVisible = true;

            dgvVendors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendors.AllowUserToResizeColumns = true;
            dgvVendors.Columns[1].ReadOnly = true;
            dgvVendors.Columns[2].ReadOnly = true;
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

        private void VendorListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
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

        private void dgvVendors_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendors.CurrentRow == null) return;
            if (dgvVendors.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvVendors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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