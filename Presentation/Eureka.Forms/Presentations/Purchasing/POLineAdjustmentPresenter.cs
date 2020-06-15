using Eureka.Core.Domain.Purchasing;
using Eureka.Forms.Views.Purchasing;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Presentations.Purchasing
{
    public class POLineAdjustmentPresenter
    {
        private readonly IPurchasingSrv _repository;
        private readonly IProjectSrv _repoProj;
        private readonly IPOLineAdjustmentView _view;

        public POLineAdjustmentPresenter(IPOLineAdjustmentView view)
        {
            _view = view;
            _repository = new PurchasingSrv();
            _repoProj = new ProjectSrv();

            _view.FormLoad += InitailLoad;
            _view.SaveAdjust += Adjust;
        }

        private void Adjust(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            List<POLineModel> temps = _repository.GetPOLineByPOID(_view.poLines.FirstOrDefault().PoHeaderId);
            if (grid.SelectedRows.Count > 0)
            {
                List<POLineModel> lines = new List<POLineModel>(); 

                foreach (DataGridViewRow item in grid.Rows)
                {
                    try
                    {
                        POLineModel line = (POLineModel)item.DataBoundItem;
                        POLineModel temp = temps.Where(x => x.PoLineId == line.PoLineId).FirstOrDefault();
                        if (line.Quantity != temp.Quantity)
                        {                            
                            lines.Add(line);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (lines.Count != 0)
                {
                    SaveLinesAdjust(lines);
                }
            }
        }

        private void SaveLinesAdjust(List<POLineModel> lines)
        {
            try
            {
                if (lines != null)
                {
                    if (lines.Count > 0)
                    {
                        List<POLineModel> list = lines;
                        foreach (POLineModel item in list)
                        {
                            item.LastUpdatedBy = _view.EpiSession.User.Id;
                            item.CreatedBy = _view.EpiSession.User.Id;
                            item.LastUpdateDate = DateTime.Now;
                            item.CreationDate = DateTime.Now;

                            //Get Cost remaining balance.
                            var budgetCost = _repoProj.GetByProjectCost(item.RefProjectNum, item.CostCode);
                            double amount = 0;

                            if (item.CurrencyCode != "THB")
                            {
                                amount = item.ExtendedAmount * item.CurrencyRate;
                            }
                            else
                            {
                                amount = item.ExtendedAmount;
                            }

                            if (budgetCost.UfBudgetRemain >= amount)
                            {
                                //Set Encumbrance Flag/Amount for PR line.
                                item.EncumbranceFlag = true;
                                item.EncumbranceAmount = amount;
                            }
                            else
                            {
                                item.EncumbranceFlag = false;
                                item.EncumbranceAmount = 0;
                            }

                            _repository.UpdatePOLine(item);
                            //Keep Logging
                            /*-- statement todo --*/
                        }

                        var resProj = list.GroupBy(x => x.RefProjectId)
                                         .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                                         .FirstOrDefault();
                        _repoProj.ProjectCost_Reset(resProj.ProjectId);

                        _view.poLines = _repository.GetPOLineByPOID(_view.poLines.FirstOrDefault().PoHeaderId);

                        MessageBox.Show("Save PO lines is Completed.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.FormClose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PO Lines is Error! " + Environment.NewLine
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitailLoad(object sender, EventArgs e)
        {
            _view.bindingSource.DataSource = _view.poLines;
        }
    }
}
