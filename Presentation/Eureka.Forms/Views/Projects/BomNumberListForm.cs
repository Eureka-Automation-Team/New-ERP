using Eureka.Core.Domain.Projects;
using Eureka.Froms.Presentations.Projects;
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

namespace Eureka.Froms.Views.Projects
{
    public partial class BomNumberListForm : MetroForm, IBomNumberListView
    {
        private BomNumberListPresenter _presenter;
        private List<BomNumberModel> _bomNumbers;
        private BomNumberModel _bomSelected;
        private int _pageNumber;
        private IPagedList<BomNumberModel> _list;

        public BomNumberListForm(List<BomNumberModel> lboms)
        {
            InitializeComponent();

            _presenter = new BomNumberListPresenter(this);

            if (lboms != null)
                bomNumbers = lboms;
        }
        
        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<BomNumberModel> list { get { return _list; } set { _list = value; } }
        public string bomNumber { get { return txtBomNumber.Text; } set { txtBomNumber.Text = value; } }
        public List<BomNumberModel> bomNumbers { get { return _bomNumbers; } set { _bomNumbers = value; } }
        public BomNumberModel bomSelected { get { return _bomSelected; } set { _bomSelected = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<BomNumberModel> list)
        {
            if (list != null)
            {
                try
                {
                    butPreviousPage.Enabled = list.HasPreviousPage;
                    butNextPage.Enabled = list.HasNextPage;
                    txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                    bomNumberModelBindingSource.DataSource = list;
                    bindingNav.BindingSource = bomNumberModelBindingSource;
                    dgvBomNumbers.DataSource = bomNumberModelBindingSource;
                }
                catch
                {
                    dgvBomNumbers.Rows.Clear();
                    return;
                }
            }
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void BomNumberListForm_Load(object sender, EventArgs e)
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

        private void dgvBomNumbers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBomNumbers.CurrentRow == null) return;
            if (dgvBomNumbers.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvBomNumbers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
