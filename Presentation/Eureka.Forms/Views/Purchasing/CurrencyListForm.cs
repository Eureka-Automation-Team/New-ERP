using Eureka.Core.Domain.Commons;
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
    public partial class CurrencyListForm : MetroForm, ICurrencyListView
    {
        private CurrencyPresenter _presenter;
        private List<CurrencyModel> _currencies;
        private CurrencyModel _currSelected;
        private BindingSource bindingLine;

        public CurrencyListForm()
        {
            InitializeComponent();
            _presenter = new CurrencyPresenter(this);
            bindingLine = new BindingSource();
        }

        public string currencyCode
        { get { return txtCurrencyCode.Text; } set { txtCurrencyCode.Text = value; } }
        public List<CurrencyModel> currencies
        { get { return _currencies; } set { _currencies = value; } }
        public CurrencyModel currSelected
        { get { return _currSelected; } set { _currSelected = value; } }

        public BindingSource bindingCurrency
        {
            get { return currencyModelBindingSource; }
            set { currencyModelBindingSource = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;

        public void BindingData()
        {
            try
            {
                bindingNav.BindingSource = bindingCurrency;
                SetPOGrid();
            }
            catch
            {
                SetPOGrid();
                return;
            }
        }

        private void SetPOGrid()
        {
            dgvCurrencies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvCurrencies.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvCurrencies.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCurrencies.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvCurrencies.MultiSelect = false;
            dgvCurrencies.RowHeadersVisible = true;

            dgvCurrencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrencies.AllowUserToResizeColumns = true;
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

        private void dgvCurrencies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCurrencies.CurrentRow == null) return;
            if (dgvCurrencies.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void CurrencyListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void dgvCurrencies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
