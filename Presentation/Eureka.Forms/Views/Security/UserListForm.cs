using Eureka.Core.Domain.Users;
using Eureka.Froms.Presentations.Security;
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

namespace Eureka.Froms.Views.Security
{
    public partial class UserListForm : MetroForm, IUserListView
    {

        private UserListPresenter _presenter;
        private List<UserModel> _users;
        private UserModel _userSelected;
        private BindingSource bindingLine;
        private int _pageNumber;
        private IPagedList<UserModel> _list;


        public UserListForm(List<UserModel> lusers)
        {
            InitializeComponent();
            _presenter = new UserListPresenter(this);
            bindingLine = new BindingSource();

            if (lusers != null)
                users = lusers;
        }

        public int pageNumber { get { return _pageNumber; } set { _pageNumber = value; } }
        public IPagedList<UserModel> list { get { return _list; } set { _list = value; } }
        public string userName { get { return txtUserName.Text; } set { txtUserName.Text = value; } }
        public List<UserModel> users { get { return _users; } set { _users = value; } }
        public UserModel userSelected { get { return _userSelected; } set { _userSelected = value; } }
        public string roleName { get { return txtRoleName.Text; } set { txtRoleName.Text = value; } }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Filter_Click;
        public event EventHandler Clear_Click;
        public event EventHandler Selecting_Row;
        public event EventHandler PreviousPage;
        public event EventHandler NextPage;

        public void BindingData(IPagedList<UserModel> list)
        {
            if (list != null)
            {
                try
                {
                    butPreviousPage.Enabled = list.HasPreviousPage;
                    butNextPage.Enabled = list.HasNextPage;
                    txtPageNumber.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                    userModelBindingSource.DataSource = list;
                    bindingNav.BindingSource = userModelBindingSource;
                    dgvUsers.DataSource = userModelBindingSource;

                    //SetPOGrid();
                }
                catch
                {
                    dgvUsers.Rows.Clear();
                    return;
                }
            }
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

        private void UserListForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            if (dgvUsers.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
