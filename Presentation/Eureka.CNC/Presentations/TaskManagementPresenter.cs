using Eureka.CNC.Views;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Services.Inventory;
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
    public class TaskManagementPresenter
    {
        private readonly IJobEntitySrv _repository;
        private readonly IShelfLocationSrv _repoLocation;
        private readonly ITaskManagementView _view;

        public TaskManagementPresenter(ITaskManagementView view)
        {
            _view = view;
            _repository = new JobEntitySrv();
            _repoLocation = new ShelfLocationSrv();

            _view.Form_Load += Load;
            _view.Filter_Click += Filter;
            _view.Release_Click += Release;
            _view.ResetGrid += ResetGrid;
            _view.QCPass_Click += QC_Pass;
            _view.QCNG_Click += QC_NG;
            _view.Sorting_Changed += Sorting;
        }

        private void Sorting(object sender, EventArgs e)
        {
            List<JobTaskModel> lines = _view.tasks;

            if (lines == null)
                return;

            if (lines.Count > 0)
            {
                if (!string.IsNullOrEmpty(_view.SortBy))
                {
                    if (_view.SortBy == "Job No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.JobNumber).ToList();
                        else
                            lines = lines.OrderBy(o => o.JobNumber).ToList();
                    }

                    if (_view.SortBy == "Task No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.TaskNumber).ToList();
                        else
                            lines = lines.OrderBy(o => o.TaskNumber).ToList();
                    }

                    if (_view.SortBy == "Item Code")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.PrimaryItemCode).ToList();
                        else
                            lines = lines.OrderBy(o => o.PrimaryItemCode).ToList();
                    }

                    if (_view.SortBy == "Model")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.PrimaryItemModel).ToList();
                        else
                            lines = lines.OrderBy(o => o.PrimaryItemModel).ToList();
                    }

                    if (_view.SortBy == "Start Date")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.StartDate).ToList();
                        else
                            lines = lines.OrderBy(o => o.StartDate).ToList();
                    }

                    if (_view.SortBy == "End Date")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.EndDate).ToList();
                        else
                            lines = lines.OrderBy(o => o.EndDate).ToList();
                    }

                    if (_view.SortBy == "Due Date")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.DueDate).ToList();
                        else
                            lines = lines.OrderBy(o => o.DueDate).ToList();
                    }

                    if (_view.SortBy == "Machine Code")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.MachineNo).ToList();
                        else
                            lines = lines.OrderBy(o => o.MachineNo).ToList();
                    }
                    _view.tasks = lines;
                    _view.bindingTasks.DataSource = lines;
                }
            }
        }

        private void QC_NG(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to set NG tasks.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        JobTaskModel curr = (JobTaskModel)dgr.DataBoundItem;
                        if (curr.Priority > 0)
                        {
                            curr.QCStatus = "NG";
                            curr.LastUpdateDate = DateTime.Now;
                            _repository.UpdateTask(curr);
                        }

                    }
                    Filter(null, null);
                }
            }
        }

        private void QC_Pass(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to set Pass tasks.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        JobTaskModel curr = (JobTaskModel)dgr.DataBoundItem;
                        if (curr.Priority > 0)
                        {
                            curr.QCStatus = "PASS";
                            curr.LastUpdateDate = DateTime.Now;
                            _repository.UpdateTask(curr);
                        }

                    }
                    Filter(null, null);
                }
            }
        }

        private void ResetGrid(object sender, EventArgs e)
        {
            var tasks = new List<JobTaskModel>();
            _view.bindingTasks.DataSource = tasks;
        }

        private void Release(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Release tasks.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        JobTaskModel curr = (JobTaskModel)dgr.DataBoundItem;
                        if (curr.Priority > 0)
                        {
                            var location = _repoLocation.GetAllAvailable().Where(x => x.ReserveFlag == false).FirstOrDefault();
                            if(location != null)
                            {
                                curr.ReserveShelfFlag = true;
                                curr.ShelfNumber = location.CombindLocation;
                                location.ReserveFlag = true;
                                location.TaskId = curr.TaskId;
                                _repoLocation.UpdateLocation(location);
                            }

                            curr.ReleaseFlag = true;
                            curr.LastUpdateDate = DateTime.Now;
                            _repository.UpdateTask(curr);
                        }

                    }
                    Filter(null, null);
                }
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<JobTaskModel> tasks = new List<JobTaskModel>();

            if (_view.FilterType == "REREASE")
            {
                tasks = _repository.GetPendingTasks().OrderBy(o => o.StartDate).ToList();
            }else if(_view.FilterType == "INSPECTION")
            {
                tasks = _repository.GetInspectionTask().OrderBy(o => o.StartDate).ToList();
            }
            else
            {
                MessageBox.Show("Filter Type is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            if (_view.FilterBy == "Task") tasks = tasks.Where(x => x.TaskNumber.ToUpper().Contains(_view.FilterWord.ToUpper())).ToList();
            if (_view.FilterBy == "Job No.") tasks = tasks.Where(x => x.JobNumber.ToUpper().Contains(_view.FilterWord.ToUpper())).ToList();
            if (_view.FilterBy == "Item Code") tasks = tasks.Where(x => x.PrimaryItemCode.ToUpper().Contains(_view.FilterWord.ToUpper())).ToList();
            if (_view.FilterBy == "Model") tasks = tasks.Where(x => x.PrimaryItemModel.ToUpper().Contains(_view.FilterWord.ToUpper())).ToList();
            if (_view.FilterBy == "Machine Code") tasks = tasks.Where(x => x.MachineNo.ToUpper().Contains(_view.FilterWord.ToUpper())).ToList();

            _view.tasks = tasks;
            _view.bindingTasks.DataSource = tasks;
            Cursor.Current = Cursors.Default;
        }

        private void Load(object sender, EventArgs e)
        {
            _view.FilterType = "REREASE";
            var tasks = new List<JobTaskModel>();

            _view.bindingTasks.DataSource = tasks;
            _view.BindingTask();
        }
    }
}
