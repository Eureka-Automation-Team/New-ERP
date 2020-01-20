using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Users;
using Eureka.Forms.Presentations.Purchasing;

namespace Eureka.Forms.Views.Controls
{
    public partial class RequisitionApproveListCtrl : UserControl, IRequisitionApproveListView
    {
        private readonly ReqApproveListPresenter _presenter;
        private UserModel _approver;
        private List<RequisitionLineModel> _linesSelected;
        private List<RequisitionLineModel> _lines;

        public RequisitionApproveListCtrl()
        {
            InitializeComponent();
            _presenter = new ReqApproveListPresenter(this);
        }

        public UserModel approver
        {
            get { return _approver; }
            set { _approver = value; }
        }
        public List<RequisitionLineModel> linesSelected
        {
            get { return _linesSelected; }
            set { _linesSelected = value; }
        }
        public List<RequisitionLineModel> Approvalslines
        {
            get { return _lines; }
            set { _lines = value; }
        }
        public BindingSource bindingLines
        {
            get { return requisitionLineModelBindingSource; }
            set { requisitionLineModelBindingSource = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Refresh_Click;
        public event EventHandler Approve_Click;
        public event EventHandler Reject_Click;

        public void RefreshLinesGird()
        {
            dgvLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLines.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLines.MultiSelect = true;
            dgvLines.RowHeadersVisible = true;
            dgvLines.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (Refresh_Click != null)
                Refresh_Click(sender, e);
        }

        private void RequisitionApproveListCtrl_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void mnuLineApproved_Click(object sender, EventArgs e)
        {
            if (Approve_Click != null)
                Approve_Click(dgvLines, e);
        }

        private void mnuLineReject_Click(object sender, EventArgs e)
        {
            if (Reject_Click != null)
                Reject_Click(dgvLines, e);
        }
    }
}
