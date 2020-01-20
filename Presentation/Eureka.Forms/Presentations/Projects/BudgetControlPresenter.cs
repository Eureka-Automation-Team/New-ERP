using Eureka.Core.Domain.Projects;
using Eureka.Data.AdoNet.Projects;
using Eureka.Forms.Utilities;
using Eureka.Froms.Views.Projects;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Projects
{
    public class BudgetControlPresenter
    {
        private readonly IPurchasingSrv _repoPO;
        private readonly IProjectSrv _repository;
        private readonly IProjectCostDao _repoCost;
        private readonly IBudgetControlView _view;

        public BudgetControlPresenter(IBudgetControlView view)
        {
            _view = view;
            _repository = new ProjectSrv();
            _repoCost = new ProjectCostDao();
            _repoPO = new PurchasingSrv();

            _view.Form_Load += Form_Load;
            _view.Search_Click += Search_Click;
            _view.Save_Click += Save_Click;
            _view.Clear_Click += Clear_Click;
            //_view.Delete_Click += Delete_Click;
            _view.Selected_Project += Selected_Project;
            _view.Paste_Rows += Paste_Rows;
            _view.GetLine_Selected += GetLine_Selected;
            _view.Delete_Row += Delete_Row;
            _view.Reset_Cost += Reset_CostAsync;
        }

        Task ProcessImport(List<ProjectModel> data, IProgress<ProgressReport> progress)
        {
            int index = 1;
            int totalProgress = data.Count;
            var progressReport = new ProgressReport();
            return Task.Run(() =>
            {
                for (int i = 0; i < totalProgress; i++)
                {
                    progressReport.PercentComplete = index++ * 100 / totalProgress;
                    progress.Report(progressReport);
                    Thread.Sleep(15);
                }
            });
        }

        private void Reset_CostAsync(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            /*
            var polinesNotEncumbrance = _repoPO.GetPOLineAll()
                .Where(x => x.RefProjectNum == _view.projectSelected.ProjectNum)
                .Take(100);

            foreach(var item in polinesNotEncumbrance)
            {
                var budgetCost = _repository.GetByProjectCost(item.RefProjectNum, item.CostCode);
                if(budgetCost != null)
                {
                    if (budgetCost.UfBudgetRemain >= item.ExtendedAmount)
                    {
                        //Set Encumbrance Flag/Amount for PR line.
                        item.EncumbranceFlag = true;
                        item.EncumbranceAmount = item.ExtendedAmount;

                        var cost = _repoCost.GetByProjectCost(item.RefProjectNum, item.CostCode);
                        //_view.projectCosts.Where(x => x.ProjectNum == item.RefProjectNum
                        //                                && x.CostCode == item.CostCode).FirstOrDefault();

                        cost.FcstCostAmount = cost.FcstCostAmount + item.ExtendedAmount;
                        _repoCost.Update(cost);
                    }
                    else
                    {
                        item.EncumbranceFlag = false;
                        item.EncumbranceAmount = 0;
                    }
                }
                else
                {
                    item.EncumbranceFlag = false;
                    item.EncumbranceAmount = 0;
                }

                item.LastUpdateDate = DateTime.Now;
                _repoPO.UpdatePOLine(item);
            }*/

            //var prjs = _view.projects.Where(x => x.ProjectNum.Contains(_view.projectSelected.ProjectNum));
            var prjs = _view.projects;
            foreach (var line in prjs)
            {
                var result = _repository.ProjectCost_Reset(line.Id);
            }
            Cursor.Current = Cursors.Default;
        }



        private void Delete_Row(object sender, EventArgs e)
        {
            if (_view.costSelected != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Line.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    _repoCost.Delete(_view.costSelected);
                    _view.projectCosts = _repository.GetProjectCostByProjID(_view.projectSelected.Id);
                    _view.bindingBudgets.DataSource = _view.projectCosts;
                    _view.BindingCost(_view.projectCosts);
                }
            }
        }

        private void GetLine_Selected(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            ProjectCostModel line = new ProjectCostModel();

            try
            {
                line = (ProjectCostModel)grd.CurrentRow.DataBoundItem;
            }
            catch 
            {
                //MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                line = null;
            }

            _view.costSelected = line;
        }

        private void Paste_Rows(object sender, EventArgs e)
        {
            if(_view.projectSelected != null)
            {
                DataObject o = (DataObject)Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    List<ProjectCostModel> costs = _view.projectCosts;

                    string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    foreach (string pastedRow in pastedRows)
                    {
                        ProjectCostModel cost = new ProjectCostModel();
                        string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                        bool valid = true;
                        for (int i = 0; i < pastedRowCells.Length; i++)
                        {
                            if (i == 0)
                            {
                                cost.CostCode = pastedRowCells[i];
                                int id = ValidCostGroup(cost.CostCode);
                                cost.CostId = id;
                                if(id == 0)
                                {
                                    MessageBox.Show("Cost Code : "+ cost.CostCode +" dose not existing.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                if (DuplicateCostCode(cost.CostCode))
                                {
                                    MessageBox.Show("Cost Code : " + cost.CostCode + " is dupplicated.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                            }                                

                            if (i == 1)
                                cost.CostDescription = pastedRowCells[i];

                            if (i == 2)
                                cost.CBDAmount = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);

                            if (i == 3)
                                cost.CTGAmount = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);

                            if (i == 4)
                                cost.MP1Amount = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);

                            if (i == 5)
                                cost.BudgetCostAmount = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);

                            cost.ProjectId = _view.projectSelected.Id;
                        }                        
                        if(valid)
                            costs.Add(cost);
                    }
                    _view.projectCosts = costs;
                    Save_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Project is null! please select Project.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private int ValidCostGroup(string costCode)
        {
            CostGroupModel result = _view.costs.Where(x => x.CostCode == costCode).FirstOrDefault();
            if (result != null)
                return result.Id;
            else
                return 0;
        }

        private bool DuplicateCostCode(string costCode)
        {
            List<ProjectCostModel> result = _view.projectCosts.Where(x => x.CostCode == costCode).ToList();
            if (result.Count > 0)
                return true;
            else
                return false;
        }

        private double InvalidNumber(string number)
        {
            double myDouble;
            bool isNumerical = double.TryParse(number, out myDouble);
            return myDouble;
        }

        private void Selected_Project(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0) // 1 should be your column index
            {
                try
                {
                    int id = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);
                    _view.projectSelected = _view.projects.Where(x => x.Id == id).FirstOrDefault();
                    _view.projectCosts = _repository.GetProjectCostByProjID(_view.projectSelected.Id);
                    _view.bindingBudgets.DataSource = _view.projectCosts;
                    _view.BindingCost(_view.projectCosts);
                }
                catch
                {
                    //MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //_view.projectSelected = null;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if(_view.projectCosts != null)
                {
                    List<ProjectCostModel> list = _view.projectCosts;
                    foreach(ProjectCostModel item in list)
                    {
                        item.ProjectNum = _view.projectSelected.ProjectNum;
                        item.LastUpdateBy = _view.EpiSession.User.Id;
                        item.CreatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.CreationDate = DateTime.Now;

                        if (item.Id == 0)
                            _repository.InsertProjCost(item);                          
                        else
                            _repository.UpdateProjCost(item);
                    }
                    _view.projectCosts = _repository.GetProjectCostByProjID(_view.projectSelected.Id);
                    _view.bindingBudgets.DataSource = _view.projectCosts;
                    _view.BindingCost(_view.projectCosts);
                    MessageBox.Show("Save Project cost is Completed.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Project cost is Error! " + Environment.NewLine 
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.projectSelected = new ProjectModel();
            _view.projectCosts = new List<ProjectCostModel>();

            _view.BindingCost(_view.projectCosts);
        }


        private void Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.projectFilter))
            {
                var list = _view.projects.Where(x => x.ProjectNum.Contains(_view.projectFilter)).ToList();
                _view.BindingProjectsGrid(list);
            }
            else
            {
                _view.BindingProjectsGrid(_view.projects);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.projects = _repository.GetProjectAll();
            _view.projectCosts = new List<ProjectCostModel>();
            _view.costs = _repository.GetCostGropAll();
            _view.BindingProjectsGrid(_view.projects);
            _view.BindingCost(_view.projectCosts);
        }
    }
}