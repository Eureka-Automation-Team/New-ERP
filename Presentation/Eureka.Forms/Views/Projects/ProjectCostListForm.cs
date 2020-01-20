using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Security;
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
    public partial class ProjectCostListForm : MetroForm, IProjectCostListView
    {
        private ProjectCostListPresenter _presenter;
        private string _projectNumber;
        private List<ProjectCostModel> _projectCosts;
        private List<ProjectCostModel> _projCostSelected;
        private int _pageNumber;
        private IPagedList<ProjectCostModel> _list;

        public ProjectCostListForm(string prjNum)
        {
            InitializeComponent();
            _presenter = new ProjectCostListPresenter(this);
            _projectNumber = prjNum;
        }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<ProjectCostModel> list { get { return _list; } set { _list = value; } }
        public string costCode { get { return txtCostCode.Text; } set { txtCostCode.Text = value; } }
        public List<ProjectCostModel> projectCosts { get { return _projectCosts; } set { _projectCosts = value; } }
        public List<ProjectCostModel> projCostSelected { get { return _projCostSelected; } set { _projCostSelected = value; } }

        public BindingSource bindingLine
        {
            get { return projectCostModelBindingSource; }
            set { projectCostModelBindingSource = value; }
        }

        public string projectNum
        {
            get { return _projectNumber; }
            set { _projectNumber = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<ProjectCostModel> list)
        {
            if (list != null)
            {
                butPreviousPage.Enabled = list.HasPreviousPage;
                butNextPage.Enabled = list.HasNextPage;
                txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                bindingNav.BindingSource = bindingLine;

                SetGrid();
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
        }

        public void CloseMe()
        {
            this.Close();
        }

        private void ProjectCostListForm_Load(object sender, EventArgs e)
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

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
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
