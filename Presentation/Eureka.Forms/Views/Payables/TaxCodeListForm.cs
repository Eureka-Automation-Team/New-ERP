using Eureka.Core.Domain.Commons;
using Eureka.Froms.Presentations.Payables;
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

namespace Eureka.Froms.Views.Payables
{
    public partial class TaxCodeListForm : MetroForm, ITaxCodeListView
    {
        private TaxCodeListPresenter _presenter;
        private List<TaxCodeModel> _taxCodes;
        private TaxCodeModel _taxSelected;
        private BindingSource bindingLine;

        public TaxCodeListForm()
        {
            InitializeComponent();
            _presenter = new TaxCodeListPresenter(this);
            bindingLine = new BindingSource();
        }

        public string taxCode
        { get { return txtTaxCode.Text; } set { txtTaxCode.Text = value; } }
        public List<TaxCodeModel> taxCodes
        { get { return _taxCodes; } set { _taxCodes = value; } }
        public TaxCodeModel taxSelected
        { get { return _taxSelected; } set { _taxSelected = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;

        public void BindingData(List<TaxCodeModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingLine.DataSource = list;
                    bindingNav.BindingSource = bindingLine;
                    dgvTaxCodes.DataSource = bindingLine;

                    SetPOGrid();
                }
                catch
                {
                    dgvTaxCodes.Rows.Clear();
                    return;
                }
            }
        }

        private void SetPOGrid()
        {
            dgvTaxCodes.Columns[0].Visible = false;
            //dgvTaxCodes.Columns[1].Visible = false;
            //dgvTaxCodes.Columns[2].Visible = false;
            //dgvTaxCodes.Columns[3].Visible = false;
            dgvTaxCodes.Columns[4].Visible = false;
            dgvTaxCodes.Columns[5].Visible = false;
            dgvTaxCodes.Columns[6].Visible = false;
            dgvTaxCodes.Columns[7].Visible = false;

            dgvTaxCodes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTaxCodes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTaxCodes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvTaxCodes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTaxCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvTaxCodes.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTaxCodes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTaxCodes.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvTaxCodes.MultiSelect = false;
            dgvTaxCodes.RowHeadersVisible = true;

            dgvTaxCodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaxCodes.AllowUserToResizeColumns = true;
            dgvTaxCodes.Columns[1].ReadOnly = true;
            dgvTaxCodes.Columns[2].ReadOnly = true;
            dgvTaxCodes.Columns[3].ReadOnly = true;
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void TaxCodeListForm_Load(object sender, EventArgs e)
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

        private void dgvTaxCodes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaxCodes.CurrentRow == null) return;
            if (dgvTaxCodes.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvTaxCodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
