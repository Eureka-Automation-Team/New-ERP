using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Inventory;
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

namespace Eureka.Froms.Views.Inventory
{
    public partial class ItemListForm : MetroForm, IItemListView
    {
        private ItemListPresenter _presenter;
        private List<ItemMasterModel> _items;
        private ItemMasterModel _itemSelected;
        //private BindingSource bindingLine;
        private int _pageNumber;
        private IPagedList<ItemMasterModel> _list;

        public ItemListForm(List<ItemMasterModel> itemList)
        {
            InitializeComponent();
            _presenter = new ItemListPresenter(this);

            this.items = itemList;
        }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<ItemMasterModel> list { get { return _list; } set { _list = value; } }
        public string itemCode { get { return txtitemCode.Text; } set { txtitemCode.Text = value; } }
        public string itemDescription { get { return txtitemDescription.Text; } set { txtitemDescription.Text = value; } }
        public string manuId { get { return txtmanuId.Text; } set { txtmanuId.Text = value; } }
        public string brandMat { get { return txtbrandMat.Text; } set { txtbrandMat.Text = value; } }
        public List<ItemMasterModel> items { get { return _items; } set { _items = value; } }
        public ItemMasterModel itemSelected { get { return _itemSelected; } set { _itemSelected = value; } }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public BindingSource BindingSource
        {
            get { return itemMasterModelBindingSource; }
            set { itemMasterModelBindingSource = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<ItemMasterModel> list)
        {
            if (list != null)
            {
                if (list != null)
                {
                    try
                    {
                        butPreviousPage.Enabled = list.HasPreviousPage;
                        butNextPage.Enabled = list.HasNextPage;
                        txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                        dgvList.Rows.Clear();
                        BindingSource.DataSource = null;
                        BindingSource.DataSource = list;
                        bindingNav.BindingSource = BindingSource;
                        SetGrid();
                    }
                    catch
                    {
                        dgvList.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void SetGrid()
        {
            dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvList.MultiSelect = true;
            dgvList.RowHeadersVisible = true;
            dgvList.ReadOnly = true;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void ItemListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
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

        private void butClose_Click(object sender, EventArgs e)
        {
            this.itemSelected = null;
            this.Close();
        }

        private void butCopyItem_Click(object sender, EventArgs e)
        {

        }
    }
}
