using Eureka.Core.Domain.Inventory;
using Eureka.Froms.Views.Inventory;
using Eureka.Froms.Views.Projects;
using Eureka.Services.Inventory;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Inventory
{
    public class MaterialReturnPresenter
    {
        private readonly IMaterialReturnView _view;
        private readonly IItemOnhandSrv _repoOnhand;
        private readonly IItemTransactionSrv _repoTrans;

        public MaterialReturnPresenter(IMaterialReturnView view)
        {
            _view = view;
            _repoOnhand = new ItemOnhandSrv();
            _repoTrans = new ItemTransactionSrv();

            //_view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Find_Project += Find_Project;
            _view.AddLine_Click += AddLine_Click;
            _view.Delete_Click += Delete_Click;
            _view.Save_Click += Save_Click;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            string msgErr = string.Empty;

            if (!ValidateLines(grid, out msgErr))
            {
                MessageBox.Show(string.Format("Have some lines is invalid.{0}{1}", Environment.NewLine, msgErr), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure to Return", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string returnNumber = string.Empty;
                DateTime transactionDate = DateTime.Now;

                using (MaterialReturnEntryForm frm = new MaterialReturnEntryForm())
                {
                    frm.ShowDialog();
                    if (frm.returnNumber != null)
                    {
                        returnNumber = frm.returnNumber;
                        transactionDate = frm.TransactionDate;
                    }
                }

                if (!string.IsNullOrEmpty(returnNumber))
                {
                    foreach (DataGridViewRow item in grid.Rows)
                    {
                        try
                        {
                            //if (string.IsNullOrEmpty(item.Cells[0].Value.ToString()))
                            //{
                            double qty = Convert.ToDouble(item.Cells[0].Value);
                            if (qty != 0)
                            {
                                ItemTransactionModel line = (ItemTransactionModel)item.DataBoundItem;
                                GenerateTransaction(line, qty, returnNumber, transactionDate);
                            }
                            //}
                        }
                        catch
                        {
                        }
                    }

                    MessageBox.Show("Issue Completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.materialsReturn = new List<ItemTransactionModel>();
                    _view.bindingReturnLines.DataSource = _view.materialsReturn;
                    Filter_Click(null, null);
                }
            }
        }

        private void GenerateTransaction(ItemTransactionModel line, double qty, string returnNumber, DateTime transactionDate)
        {
            //MaterialIssueModel Head = _view.head;

            ItemTransactionModel trans = new ItemTransactionModel();
            trans.InventoryItemId = line.InventoryItemId;
            trans.SubinventoryCode = line.TransferSubinventory; //Source Subinventory
            trans.TransferSubinventory = line.TransferSubinventory;
            trans.TransactionSourceName = "MATERIAL RETURN";
            trans.TransactionQuantity = Math.Abs(qty);
            trans.TransactionUom = line.TransactionUom;
            trans.PrimaryQuantity = Math.Abs(qty);
            trans.TransactionDate = transactionDate;
            trans.TransactionReference = returnNumber;
            //trans.TransactionSourceName
            trans.TransactionSourceId = line.TransactionId;     //Only Materail Return using transaction_id
            trans.CostedFlag = "Y";
            trans.ActualCost = line.ActualCost;
            trans.TransactionCost = line.TransactionCost;
            trans.Attribute1 = line.Attribute1;
            trans.Attribute2 = line.Attribute2;
            trans.Attribute3 = line.Attribute3;
            trans.Attribute4 = line.Attribute4;

            line.QuantityAdjusted = line.QuantityAdjusted + qty;
            line.TransactionQuantity = line.TransactionQuantity * -1;
            line.LastUpdateDate = DateTime.Now;
            line.LastUpdatedBy = _view.EpiSession.User.Id;
            _repoTrans.UpdateTrans(line);

            int id = _repoTrans.InsertTrans(trans);

            ItemOnhandModel onhand = _repoOnhand.GetDupplicated(line.InventoryItemId
                                                                , line.TransferSubinventory
                                                                , line.Attribute3
                                                                , string.IsNullOrEmpty(line.Attribute4) ? "999" : line.Attribute4  /*Bom Number*/
                                                                );
            if (onhand != null)
            {
                double trxQty = onhand.PrimaryTransactionQuantity + qty;
                onhand.PrimaryTransactionQuantity = trxQty;
                onhand.TransactionQuantity = trxQty;
                onhand.UpdateTransactionId = id;
                onhand.TransactionUnitCost = trans.ActualCost;

                _repoOnhand.UpdateOnhand(onhand);
            }
            else
            {
                onhand = new ItemOnhandModel();
                onhand.InventoryItemId = line.InventoryItemId;
                onhand.DateReceived = DateTime.Now;
                onhand.PrimaryTransactionQuantity = qty;
                onhand.TransactionQuantity = qty;
                onhand.SubinventoryCode = line.TransferSubinventory;
                onhand.LotNumber = line.Attribute3;
                onhand.TransactionUomCode = line.TransactionUom;
                onhand.CreateTransactionId = id;
                onhand.UpdateTransactionId = id;
                onhand.BomNo = string.IsNullOrEmpty(line.Attribute4) ? "999" : line.Attribute4;
                onhand.TransactionUnitCost = trans.ActualCost;
                //onhand.ProjectId = ;
                onhand.ProjectNum = line.Attribute1;
                onhand.ProjectCostCode = line.Attribute2;

                int onhandId = _repoOnhand.InsertOnhand(onhand);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            List<ItemTransactionModel> lines = _view.materialsReturn.ToList();

            foreach (DataGridViewRow item in grid.SelectedRows)
            {
                try
                {
                    var trx = (ItemTransactionModel)item.DataBoundItem;
                    lines.RemoveAll(x => x.TransactionId == trx.TransactionId);
                }
                catch
                {
                }
            }

            _view.materialsReturn = lines;
            _view.bindingReturnLines.DataSource = _view.materialsReturn;
        }

        private void AddLine_Click(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            List<ItemTransactionModel> lines = new List<ItemTransactionModel>(); //grid.SelectedRows.DataBoundItem;
            List<ItemTransactionModel> trans = _view.materialsTrans.ToList();
            string projectNumber = string.Empty;

            using (ProjectListForm frm = new ProjectListForm())
            {
                frm.ShowDialog();
                if (frm.projSelected != null)
                {
                    projectNumber = frm.projSelected.FirstOrDefault().ProjectNum;
                }
            }

            if (string.IsNullOrEmpty(projectNumber))
            {
                MessageBox.Show("Please select Subinventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_view.materialsReturn != null)
                lines = _view.materialsReturn.ToList();

            List<int> trxIds = new List<int>();
            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    if ((bool)item.Cells[0].Value)
                    {
                        ItemTransactionModel line = (ItemTransactionModel)item.DataBoundItem;

                        line.TransactionQuantity = line.TransactionQuantity;
                        line.TransferSubinventory = projectNumber;
                        lines.Add(line);
                        trxIds.Add(line.TransactionId);
                        //trans.RemoveAll(x => x.TransactionId == line.TransactionId);
                    }
                }
                catch
                {
                }
            }

            if (lines.Count > 0)
            {
                _view.materialsReturn = lines;
                _view.bindingReturnLines.DataSource = _view.materialsReturn;
                _view.BindingReturns();
                //_view.BindingCache(_view.onhandsCache.ToList());

                _view.materialsTrans = trans.Where(x => !trxIds.Contains(x.TransactionId)).ToList() ;
                _view.bindingMaterialsTrans.DataSource = _view.materialsTrans;
                //_view.BindingData(_view.onhands.ToList());
            }
            else
            {
                MessageBox.Show("Please select rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidateLines(MetroGrid grid, out string msg)
        {
            string messageOut = string.Empty;
            bool valid = true;
            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    ItemTransactionModel line = (ItemTransactionModel)item.DataBoundItem;
                    double qty = Convert.ToDouble(item.Cells[0].Value);
                    int lineNum = Convert.ToInt32(item.Index) + 1;
                    if (qty == 0)
                    {
                        valid = false;
                        if (string.IsNullOrEmpty(messageOut))
                            messageOut = "Line : " + lineNum + " value is not be zero.";
                        else
                            messageOut = messageOut + Environment.NewLine + "Line : " + lineNum + " value is not be zero.";
                    }                        

                    if (qty > line.NetIssueTransactionQty)
                    {
                        valid = false;
                        if (string.IsNullOrEmpty(messageOut))
                            messageOut = "Line : " + lineNum + " Return Qty. must less than or equal Transacion Qty.";
                        else
                            messageOut = messageOut + Environment.NewLine + "Line : " + lineNum + " Return Qty. must less than or equal Transacion Qty.";
                    }                                
                }
                catch
                {
                    valid = false;
                }
            }

            msg = messageOut;
            return valid;
        }

        private void Find_Project(object sender, EventArgs e)
        {
            using (ProjectListForm frm = new ProjectListForm())
            {
                frm.projectNum = _view.projNumber;
                frm.ShowDialog();
                if (frm.projSelected != null)
                {
                    _view.projNumber = frm.projSelected.FirstOrDefault().ProjectNum;
                }
            }
        }

        private async void Form_Load(object sender, EventArgs e)
        {           
            if (!String.IsNullOrWhiteSpace(_view.projNumber))
            {
                _view.materialsTrans = await GetListAsync();
                _view.bindingMaterialsTrans.DataSource = _view.materialsTrans;
                _view.BindingTrans();                
            }
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(_view.projNumber))
            //{
            //    MessageBox.Show("Please select Project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _view.materialsTrans = await GetListAsync();
            _view.bindingMaterialsTrans.DataSource = _view.materialsTrans;
            _view.BindingTrans();
        }

        public async Task<List<ItemTransactionModel>> GetListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = _repoTrans.GetTransByStartDate(_view.transDate)
                                       .OrderByDescending(o => o.TransactionDate).ToList(); //Order by LIFO

                Cursor.Current = Cursors.WaitCursor;
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.projNumber)) result = result.Where(x => (string.IsNullOrEmpty(x.Attribute1) ? "" : x.Attribute1.ToUpper()).Contains(_view.projNumber.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.itemFilter)) result = result.Where(x => (string.IsNullOrEmpty(x.ItemCode) ? "" : x.ItemCode.ToUpper()).Contains(_view.itemFilter.ToUpper())
                                                        || (string.IsNullOrEmpty(x.ItemDescription) ? "" : x.ItemDescription.ToUpper()).Contains(_view.itemFilter.ToUpper())
                                                        || (string.IsNullOrEmpty(x.ManuID) ? "" : x.ManuID.ToUpper()).Contains(_view.itemFilter.ToUpper())
                                                        || (string.IsNullOrEmpty(x.BrandMat) ? "" : x.BrandMat.ToUpper()).Contains(_view.itemFilter.ToUpper())).ToList();
                }

                Cursor.Current = Cursors.Default;
                return result;
            });
        }
    }
}
