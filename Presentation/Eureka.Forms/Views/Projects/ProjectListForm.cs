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
    public partial class ProjectListForm : MetroForm, IProjectListView
    {
        private ProjectListPresenter _presenter;
        private List<ProjectModel> _projects;
        private List<ProjectModel> _projSelected;
        private BindingSource bindingLine;
        private int _pageNumber;
        private IPagedList<ProjectModel> _list;

        public ProjectListForm()
        {
            InitializeComponent();
            _presenter = new ProjectListPresenter(this);
            bindingLine = new BindingSource();
        }

        public string projectNum
        { get { return txtProjectNum.Text; } set { txtProjectNum.Text = value; } }
        public List<ProjectModel> projects
        { get { return _projects; } set { _projects = value; } }
        public List<ProjectModel> projSelected
        { get { return _projSelected; } set { _projSelected = value; } }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<ProjectModel> list { get { return _list; } set { _list = value; } }

        public DateTime startDate { get { return dtpStartDate.Value; } set { dtpStartDate.Value = value; } }
        public DateTime endDate { get { return dtpEndDate.Value; } set { dtpEndDate.Value = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<ProjectModel> list)
        {
            if (list != null)
            {
                try
                {
                    butPreviousPage.Enabled = list.HasPreviousPage;
                    butNextPage.Enabled = list.HasNextPage;
                    txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                    projectModelBindingSource.DataSource = list;
                    bindingNav.BindingSource = projectModelBindingSource;
                    //dgvProjects.DataSource = projectModelBindingSource;

                    //SetPOGrid();
                }
                catch
                {
                    dgvProjects.Rows.Clear();
                    return;
                }
            }
        }

        //private void SetPOGrid()
        //{
        //    dgvProjects.Columns[0].Visible = false;
        //    //dgvProjects.Columns[1].Visible = false;
        //    dgvProjects.Columns[2].Visible = false;
        //    dgvProjects.Columns[3].Visible = false;
        //    //dgvProjects.Columns[4].Visible = false;
        //    dgvProjects.Columns[5].Visible = false;
        //    dgvProjects.Columns[6].Visible = false;
        //    dgvProjects.Columns[7].Visible = false;
        //    dgvProjects.Columns[8].Visible = false;
        //    dgvProjects.Columns[9].Visible = false;
        //    dgvProjects.Columns[10].Visible = false;
        //    dgvProjects.Columns[11].Visible = false;
        //    dgvProjects.Columns[12].Visible = false;
        //    dgvProjects.Columns[13].Visible = false;
        //    dgvProjects.Columns[14].Visible = false;
        //    dgvProjects.Columns[15].Visible = false;
        //    dgvProjects.Columns[16].Visible = false;
        //    dgvProjects.Columns[17].Visible = false;
        //    dgvProjects.Columns[18].Visible = false;
        //    dgvProjects.Columns[19].Visible = false;
        //    dgvProjects.Columns[20].Visible = false;
        //    dgvProjects.Columns[21].Visible = false;
        //    dgvProjects.Columns[22].Visible = false;
        //    dgvProjects.Columns[23].Visible = false;
        //    dgvProjects.Columns[24].Visible = false;
        //    dgvProjects.Columns[25].Visible = false;
        //    dgvProjects.Columns[26].Visible = false;
        //    dgvProjects.Columns[27].Visible = false;
        //    dgvProjects.Columns[28].Visible = false;
        //    dgvProjects.Columns[29].Visible = false;
        //    dgvProjects.Columns[30].Visible = false;

        //    dgvProjects.Columns[3].DefaultCellStyle.Format = "dd-MMM-yyyy";

        //    //dgvProjects.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvProjects.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgvProjects.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        //    dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvProjects.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        //    dgvProjects.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        //    dgvProjects.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    dgvProjects.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        //    dgvProjects.MultiSelect = true;
        //    dgvProjects.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        //    //dgvProjects.RowHeadersVisible = true;


        //    //dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvProjects.AllowUserToResizeColumns = true;
        //    dgvProjects.Columns[0].ReadOnly = true;
        //    dgvProjects.Columns[3].ReadOnly = true;
        //}

        public void CloseMe()
        {
            this.Close();
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void ProjectListForm_Load(object sender, EventArgs e)
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

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvProjects.CurrentRow == null) return;
            //if (dgvProjects.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvProjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvProjects_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvProjects.CurrentRow == null) return;
            if (dgvProjects.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvProjects_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
