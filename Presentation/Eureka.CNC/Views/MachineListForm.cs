using Eureka.CNC.Presentations;
using Eureka.Core.Domain.Manufacturing;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public partial class MachineListForm : MaterialForm, IMachineListView
    {
        private readonly MachineListPresenter _presenter;
        private List<MachineModel> _Machines;
        private MachineModel _MachinesSelected;

        public MachineListForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE);
            _presenter = new MachineListPresenter(this);
        }

        public BindingSource bindingHead
        {
            get { return machineModelBindingSource; }
            set { machineModelBindingSource = value; }
        }

        public string MachineCode
        {
            get { return txtMachineCode.Text; }
            set { txtMachineCode.Text = value; }
        }
        public List<MachineModel> Machines
        {
            get { return _Machines; }
            set { _Machines = value; }
        }
        public MachineModel MachinesSelected
        {
            get { return _MachinesSelected; }
            set { _MachinesSelected = value; }
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
                bindingNav.BindingSource = bindingHead;
            }
            catch { }
            SetJobsGrid();
        }

        private void SetJobsGrid()
        {
            dgvJobs.BorderStyle = BorderStyle.Fixed3D;
            dgvJobs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvJobs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvJobs.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvJobs.MultiSelect = false;
            dgvJobs.RowHeadersVisible = true;
            dgvJobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJobs.AllowUserToResizeColumns = true;
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

        private void MachineListForm_Load(object sender, EventArgs e)
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

        private void dgvJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvJobs.CurrentRow == null) return;
            if (dgvJobs.CurrentRow.Index == -1) return;

            if (Selecting_Row != null)
                Selecting_Row(sender, e);
        }

        private void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }
    }
}
