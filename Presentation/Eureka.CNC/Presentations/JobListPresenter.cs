using Eureka.CNC.Views;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Services.Manufacturing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Eureka.CNC.Presentations
{
    public class JobListPresenter
    {
        private readonly IJobEntitySrv _repository;
        private readonly IJobListView _view;

        public JobListPresenter(IJobListView view)
        {
            _view = view;
            _repository = new JobEntitySrv();

            _view.Form_Load += Form_Load;
            _view.Clear_Click += Clear_Click;
            _view.Filter_Click += Filter_Click;
            _view.OK_Click += OK_Click;
            _view.Selecting_Row += Selecting_Row;
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0)
            {
                List<JobEntityModel> jobs = new List<JobEntityModel>(); // grid.SelectedRows.DataBoundItem;
                foreach (DataGridViewRow item in grid.SelectedRows)
                {
                    try
                    {
                        JobEntityModel pr = (JobEntityModel)item.DataBoundItem;
                        jobs.Add(pr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (jobs.Count != 0)
                {
                    _view.jobsSelected = jobs;
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_view.jobsSelected.Count() > 0)
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
            var result = _repository.GetJobsByDate(_view.startDate, _view.endDate);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.jobNo)) result = result.Where(x => x.JobEntityName.Contains(_view.jobNo)).ToList();
            }

            _view.jobs = result;
            _view.bindingHead.DataSource = result;
            _view.BindingData();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.jobNo = string.Empty;

            Filter_Click(sender, e);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.startDate = DateTime.Now.AddDays(-10);
            _view.endDate = DateTime.Now;
        }
    }
}
