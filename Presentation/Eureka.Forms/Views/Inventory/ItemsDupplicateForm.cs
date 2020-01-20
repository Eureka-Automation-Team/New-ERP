using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eureka.Core.Domain.Inventory;
using Eureka.Forms.Presentations.Inventory;
using MetroFramework.Forms;

namespace Eureka.Forms.Views.Inventory
{
    public partial class ItemsDupplicateForm : MetroForm, IItemsDupplicateView
    {
        private ItemsDupplicatePresenter _presenter;
        private List<ItemMasterModel> _items;
        private List<ItemMasterModel> _itemsSelected;

        public ItemsDupplicateForm(List<ItemMasterModel> _list)
        {
            InitializeComponent();
            _presenter = new ItemsDupplicatePresenter(this);

            if (_list != null)
                _items = _list;
        }

        public BindingSource SourceBinding
        {
            get { return itemMasterModelBindingSource; }
            set { itemMasterModelBindingSource = value; }
        }
        public List<ItemMasterModel> items 
        { 
            get { return _items; } 
            set { _items = value; } 
        }
        public List<ItemMasterModel> itemsSelected
        {
            get { return _itemsSelected; }
            set { _itemsSelected = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Copy_Click;
        public event EventHandler Selecting_Row;

        public void BindingGrid()
        {
            try
            {
                bindingNav.BindingSource = SourceBinding;
                SetLinesGrid();
            }
            catch
            {
                dgvList.Rows.Clear();
                return;
            }
        }

        private void SetLinesGrid()
        {
            dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvList.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvList.MultiSelect = true;
            dgvList.RowHeadersVisible = true;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void ItemsDupplicateForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }
    }
}
