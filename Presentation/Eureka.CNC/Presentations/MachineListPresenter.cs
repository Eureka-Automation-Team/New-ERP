using Eureka.CNC.Views;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Services.Manufacturing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Presentations
{
    public class MachineListPresenter
    {
        private readonly IMachineListView _view;
        private readonly IMachineSrv _repository;

        public MachineListPresenter(IMachineListView view)
        {
            _view = view;
            _repository = new MachineSrv();

            _view.Form_Load += FormLoad;
            _view.Clear_Click += Clear_Click;
            _view.Filter_Click += Filter_Click;
            _view.OK_Click += OK_Click;
            _view.Selecting_Row += Selecting_Row;
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            try
            {
                _view.MachinesSelected = (MachineModel)grid.CurrentRow.DataBoundItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_view.MachinesSelected != null)
                {
                    _view.CloseMe();
                }
                else
                {
                    MessageBox.Show("Please select rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please select rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            var result = _repository.GetAll().Where(x => x.EnableFlag).ToList();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.MachineCode)) result = result.Where(x => x.MachineCode.Contains(_view.MachineCode)).ToList();
            }

            _view.Machines = result;
            _view.bindingHead.DataSource = result;
            _view.BindingData();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.MachineCode = string.Empty;
            Filter_Click(sender, e);
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _view.MachineCode = string.Empty;
        }
    }
}
