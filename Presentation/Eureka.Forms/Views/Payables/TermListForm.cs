using Eureka.Core.Domain.Payables;
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
    public partial class TermListForm : MetroForm, ITermListView
    {
        private TermListPresenter _presenter;
        private List<TermModel> _terms;
        private TermModel _termSelected;
        private BindingSource bindingLine;

        public TermListForm()
        {
            InitializeComponent();
            _presenter = new TermListPresenter(this);
            bindingLine = new BindingSource();
        }

        public string TermCode { get { return txtVendorNum.Text; } set { txtVendorNum.Text = value; } }
        public List<TermModel> terms { get { return _terms; } set { _terms = value; } }
        public TermModel termSelected { get { return _termSelected; } set { _termSelected = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;

        public void BindingData(List<TermModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingLine.DataSource = list;
                    bindingNav.BindingSource = bindingLine;
                    dgvTerms.DataSource = bindingLine;

                    SetPOGrid();
                }
                catch
                {
                    dgvTerms.Rows.Clear();
                    return;
                }
            }
        }

        private void SetPOGrid()
        {
            dgvTerms.Columns[0].Visible = false;
            //dgvTerms.Columns[1].Visible = false;
            //dgvTerms.Columns[2].Visible = false;
            dgvTerms.Columns[3].Visible = false;
            dgvTerms.Columns[4].Visible = false;
            dgvTerms.Columns[5].Visible = false;
            dgvTerms.Columns[6].Visible = false;
            dgvTerms.Columns[7].Visible = false;

            dgvTerms.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTerms.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTerms.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvTerms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvTerms.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTerms.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTerms.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvTerms.MultiSelect = false;
            dgvTerms.RowHeadersVisible = true;

            dgvTerms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTerms.AllowUserToResizeColumns = true;
            dgvTerms.Columns[1].ReadOnly = true;
            dgvTerms.Columns[2].ReadOnly = true;
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

        private void dgvTerms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTerms.CurrentRow == null) return;
            if (dgvTerms.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void TermListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void dgvTerms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
