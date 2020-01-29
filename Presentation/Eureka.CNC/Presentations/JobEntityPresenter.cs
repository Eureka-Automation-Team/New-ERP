using Eureka.CNC.Views;
using Eureka.CNC.Views.Controls;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Services.Manufacturing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Presentations
{
    public class JobEntityPresenter
    {
        private readonly IJobEntitySrv _repository;
        private readonly IMachineSrv _repoMachine;
        private readonly IJobEntityView _view;

        public JobEntityPresenter(IJobEntityView view)
        {
            _view = view;
            _repository = new JobEntitySrv();
            _repoMachine = new MachineSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.New_Job += New_Job;
            _view.Save_Click += Save_Click;
            _view.Selecting_Job += Selecting_Job;
            _view.New_Task += New_Task;
            _view.TaskSelection_Changed += TaskSelection_Changed;
            _view.Upload_NCFile += Upload_NCFile;
            _view.Ready_Click += Ready_Click;
            _view.Cancel_Click += CancelJob;
            _view.DeleteTask_Click += DeleteTask;
            _view.Refresh_Click += Refresh;
            _view.RefreshLines_Click += RefreshLines;
            _view.Find_Items += Find_Items;
        }

        private void Find_Items(object sender, EventArgs e)
        {
            if (_view.taskSelected != null)
            {
                if (!_view.taskSelected.ReadyFlag)
                {
                    DataGridView dgv = sender as DataGridView;
                    DataGridViewCellEventArgs arg = e as DataGridViewCellEventArgs;
                    if (arg == null)
                        return;

                    JobTaskModel task = (JobTaskModel)dgv.CurrentRow.DataBoundItem;
                    string headerText = dgv.Columns[arg.ColumnIndex].Name;
                    if (headerText == "machineNoDataGridViewTextBoxColumn")  //Brand/Material
                    {
                        var machine = _repoMachine.GetByCode(task.MachineNo == null ? "" : task.MachineNo.ToString());
                        if(machine != null)
                        {
                            dgv.CurrentCell.Value = machine.MachineCode;
                        }
                        else
                        {
                            using (MachineListForm frm = new MachineListForm())
                            {
                                frm.ShowDialog();
                                if (frm.MachinesSelected != null)
                                {
                                    dgv.CurrentCell.Value = frm.MachinesSelected.MachineCode;
                                }
                                else
                                {
                                    dgv.CurrentCell.Value = string.Empty;
                                }
                            }
                        }
                        //dgv.CurrentCell.Value
                        dgv.EndEdit();
                    }

                    if (headerText == "startDateDataGridViewTextBoxColumn")  //Brand/Material
                    {
                        //JobTaskModel curr = (JobTaskModel)dgv.CurrentRow.DataBoundItem;

                        using (SingleCalendarForm frm = new SingleCalendarForm(task.StartDate))
                        {
                            frm.ShowDialog();
                            if (frm.boolOK)
                            {
                                dgv.CurrentCell.Value = frm.timeSelected;
                            }
                        }

                        dgv.EndEdit();
                    }
                    //
                    if (headerText == "dueDateDataGridViewTextBoxColumn")  //Brand/Material
                    {
                        //JobTaskModel curr = (JobTaskModel)dgv.CurrentRow.DataBoundItem;

                        using (SingleCalendarForm frm = new SingleCalendarForm(task.StartDate))
                        {
                            frm.ShowDialog();
                            if (frm.boolOK)
                            {
                                dgv.CurrentCell.Value = frm.timeSelected;
                            }
                        }

                        dgv.EndEdit();
                    }
                }
            }
        }

        private void RefreshLines(object sender, EventArgs e)
        {
            if(_view.jobSelected != null)
            {
                var job = _view.jobSelected;
                _view.tasks = _repository.GetTasksByJobID(job.JobEntityId);
                _view.bindingTasks.DataSource = _view.tasks;
                _view.BindingTask();
            }
        }

        private void Refresh(object sender, EventArgs e)
        {
            Selecting_Job(sender, e);
        }

        private void DeleteTask(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            if(_view.taskSelected != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Delete tasks.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    JobTaskModel curr = _view.taskSelected;
                    if (!curr.ReleaseFlag)
                    {
                        _repository.DeleteTask(curr);
                    }
                    _view.tasks = _repository.GetTasksByJobID(_view.jobSelected.JobEntityId);
                    _view.bindingTasks.DataSource = _view.tasks;
                }
            }         
        }

        private void CancelJob(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            JobEntityModel job = _view.jobSelected;
            if (grd.Rows.Count > 0)
            {
                if (job.ProcessFlag)
                {
                    MessageBox.Show(string.Format("Cannot cancel this Job, because Job : {0} was Processed"
                                                   , job.JobEntityName)
                                                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure to Cancel this job.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.Rows)
                    {
                        JobTaskModel curr = (JobTaskModel)dgr.DataBoundItem;
                        if (curr.Priority > 0)
                        {
                            curr.CancelFlag = true;
                            curr.LastUpdateDate = DateTime.Now;
                            _repository.UpdateTask(curr);
                        }

                    }
                    _view.tasks = _repository.GetTasksByJobID(_view.jobSelected.JobEntityId);
                    _view.bindingTasks.DataSource = _view.tasks;
                }
            }
        }

        private void Ready_Click(object sender, EventArgs e)
        {
            var task = _view.taskSelected;
            DialogResult dialogResult = MessageBox.Show("Are you sure to Submit Ready Process.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                task.ReadyFlag = true;
                _repository.UpdateTask(task);
                _view.tasks = _repository.GetTasksByJobID(task.JobId);
                _view.bindingTasks.DataSource = _view.tasks;
            }
        }

        private void Upload_NCFile(object sender, EventArgs e)
        {
            var task = _view.taskSelected;
            double standTime = 0;
            string strFolderPath = Application.StartupPath + "\\NCFiles\\" 
                                + _view.jobSelected.JobEntityName 
                                + "\\" + task.TaskNumber + "\\";

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (ValidateStandardTime(dlg.FileName, out standTime))
                {
                    //*** Create Folder
                    if (!Directory.Exists(strFolderPath))
                    {
                        Directory.CreateDirectory(strFolderPath);
                    }

                    //*** Save File
                    string filePath = dlg.FileName;
                    string fileName = System.IO.Path.GetFileName(filePath);
                    try
                    {
                        File.Copy(filePath, strFolderPath + fileName, true);
                        task.NcFile = fileName;
                        task.StandardTime = standTime;
                        //task.EndDate = task.StartDate.AsDateTime().AddMinutes(standTime);
                        task.UploadNcfileFlag = true;
                        _repository.UpdateTask(task);
                        _view.tasks = _repository.GetTasksByJobID(task.JobId);
                        _view.bindingTasks.DataSource = _view.tasks;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    MessageBox.Show("Upload NC file to task successfully.");
                }
                else
                {
                    MessageBox.Show("Validating file error. Cannot find standard time.", "File Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool ValidateStandardTime(string FileName, out double StandardTime)
        {
            bool validFile = false;
            String line;
            double standardTime = 0;
            int linenum = 1;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(FileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    //Console.WriteLine(line);
                    if(linenum == 5)
                    {
                        int intLength = line.Length;

                        if (Double.TryParse(line.Substring(1, intLength-1), out standardTime))
                        {
                            validFile = true;
                            break;
                        }
                        else
                        {
                            validFile = false;
                            break;
                        }
                    }

                    //Read the next line
                    line = sr.ReadLine();
                    linenum++;
                }

                //close the file
                sr.Close();
            }
            catch
            {
                validFile = false;
            }

            StandardTime = standardTime;
            return validFile;        
        }

        private void TaskSelection_Changed(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            try
            {
                _view.taskSelected = (JobTaskModel)grd.CurrentRow.DataBoundItem;
            }
            catch { _view.taskSelected = null; }           
        }

        private void New_Task(object sender, EventArgs e)
        {
            JobEntityModel job = _view.jobSelected;
            MetroGrid grd = sender as MetroGrid;
            if (job != null)
            {
                if (job.CancelFlag)
                {
                    MessageBox.Show(string.Format("Job : {0} was Canceled."
                                                   , job.JobEntityName)
                                                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (job.CompletedFlag)
                {
                    MessageBox.Show(string.Format("Job : {0} was Completed."
                                                   , job.JobEntityName)
                                                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    _view.bindingTasks.AddNew();
                    JobTaskModel curr = (JobTaskModel)_view.bindingTasks.Current;
                    curr.TaskNumber = (_view.bindingTasks.Count).ToString();
                    var tasksOnDay = _repository.GetTasksByDateRange(DateTime.Now.Date, DateTime.Now.Date)
                                                .Where(x => x.ReleaseFlag && (string.IsNullOrEmpty(x.MachineNoReady) ? x.MachineNo : x.MachineNoReady) == curr.MachineNo)
                                                .OrderByDescending(o => o.EndDate)
                                                .FirstOrDefault();
                    if (tasksOnDay != null)
                        curr.StartDate = tasksOnDay.EndDate;
                    else
                        curr.StartDate = DateTime.Now;

                    curr.DueDate = DateTime.Now.AddDays(1);
                    grd.Focus();
                    grd.CurrentCell = grd[12, grd.CurrentCell.RowIndex];
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error : "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
         
            }
        }

        private void Selecting_Job(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            try
            {
                JobEntityModel job = (JobEntityModel)grid.CurrentRow.DataBoundItem;
                _view.jobSelected = job;
                _view.tasks = _repository.GetTasksByJobID(job.JobEntityId);
                _view.bindingTasks.DataSource = _view.tasks;
                _view.BindingTask();
            }
            catch { }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            //CalculateLine();
            MetroGrid grd = sender as MetroGrid;
            JobEntityModel job = _view.jobSelected;
            string typeLookup = string.Empty;
            //if (!po.SubmitFlag)
            //{
            //if (string.IsNullOrEmpty(job.JobEntityName))
            //{
            //    MessageBox.Show("Job No. is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (string.IsNullOrEmpty(job.PrimaryItemCode))
            {
                MessageBox.Show("Item No. is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(job.PrimaryItemModel))
            {
                MessageBox.Show("Item Model is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (job.PrimaryQuantity == 0)
            {
                MessageBox.Show("Job Quantiry is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (job.JobEntityId == 0)
            {
                var jobExist = _repository.GetExistingJobNumber(job.JobEntityName);
                if (jobExist != null)
                {
                    MessageBox.Show(string.Format("Job No. '{0}' is dupplicated.", job.JobEntityName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                job.JobEntityName = _repository.GetNewJobNumber();
                job.JobEntityId = _repository.InsertJob(job);
            }
            else
            {
                _repository.UpdateJob(job);
            }

            foreach (DataGridViewRow dgr in grd.Rows)
            {
                JobTaskModel line = (JobTaskModel)dgr.DataBoundItem;
                line.LastUpdateDate = DateTime.Now;
                line.LastUpdatedBy = _view.EpiSession.User.Id;
                line.JobNumber = job.JobEntityName;
                line.Description = line.TaskNumber;
                line.PrimaryQuantity = 1;
                line.MachineId = 3;

                if (line.TaskId == 0)
                {
                    line.JobId = job.JobEntityId;
                    line.CreationDate = DateTime.Now;
                    line.CreatedBy = _view.EpiSession.User.Id;
                    _repository.InsertTask(line);
                }
                else
                {
                    _repository.UpdateTask(line);
                }
            }

                MessageBox.Show("Save Completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.jobSelected = job;
            _view.tasks = _repository.GetTasksByJobID(job.JobEntityId);
            _view.bindingJobs.DataSource = _view.jobs;
            _view.bindingTasks.DataSource = _view.tasks;
            //_view.BindingJob();
            //_view.BindingTask();
            _view.bindingJobs.Position = _view.bindingJobs.IndexOf(job);
        }

        private void New_Job(object sender, EventArgs e)
        {
            JobEntityModel job = new JobEntityModel();
            bool newAble = false;
            job.JobEntiryDate = DateTime.Now;
            job.OpenStatus = true;
            job.CancelFlag = false;
            job.CreatedBy = _view.EpiSession.User.Id;
            job.LastUpdatedBy = _view.EpiSession.User.Id;

            var tempExist = _view.jobs.Where(x => x.JobEntityId.Equals(0));
            if (tempExist.Count() == 0)
                newAble = true;

            if(newAble)
            {
                _view.jobs.Add(job);
                _view.bindingJobs.DataSource = _view.jobs.OrderByDescending(o => o.JobEntiryDate);
                _view.BindingJob();
                _view.bindingJobs.Position = _view.bindingJobs.IndexOf(job);
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            using (JobListForm frm = new JobListForm())
            {
                frm.startDate = DateTime.Now;
                frm.endDate = DateTime.Now;
                frm.ShowDialog();
                if (frm.jobsSelected != null)
                {
                    _view.jobs = frm.jobsSelected;
                    _view.bindingJobs.DataSource = _view.jobs.OrderByDescending(o => o.JobEntiryDate);
                    _view.BindingJob();
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.NewTaskAble = false;
            _view.jobs = new List<JobEntityModel>();
            _view.BindingJob();
            _view.BindingTask();
        }
    }
}
