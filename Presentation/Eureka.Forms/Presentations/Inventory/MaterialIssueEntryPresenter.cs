using Eureka.Core.Domain.Inventory;
using Eureka.Froms.Views.Inventory;
using Eureka.Services.Inventory;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Inventory
{
    public class MaterialIssueEntryPresenter
    {
        private readonly IMaterialIssueEntryView _view;
        private readonly IItemOnhandSrv _repoOnhand;
        private readonly IItemTransactionSrv _repoTrans;

        public MaterialIssueEntryPresenter(IMaterialIssueEntryView view)
        {
            _view = view;
            _repoOnhand = new ItemOnhandSrv();
            _repoTrans = new ItemTransactionSrv();

            _view.Form_Load += Form_Load;
            _view.GenerateNumber += GenerateNumber;
            _view.Save_Click += Save_Click;
            _view.Validate_Lines += Validate_Lines;
        }
        
        private void Validate_Lines(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            //bool valid = true;
            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    double qty = Convert.ToDouble(item.Cells["PrimaryTransactionQuantity"].Value);
                    if (qty != 0)
                    {
                        item.Cells[0].Value = qty;
                    }
                }
                catch
                {
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.head.IssueNumber))
            {
                MessageBox.Show("Please Generate Issue Number before save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MetroGrid grid = sender as MetroGrid;
            //bool valid = true;
            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    //if (string.IsNullOrEmpty(item.Cells[0].Value.ToString()))
                    //{
                    double qty = Convert.ToDouble(item.Cells[0].Value);
                    if (qty != 0)
                    {
                        int id = (int)item.Cells["onhandQuantitiesIdDataGridViewTextBoxColumn"].Value;
                        ItemOnhandModel line = _view.onhandsSelected.Where(x => x.OnhandQuantitiesId == id).FirstOrDefault();
                        GenerateTransaction(line, qty);
                    }
                    //}
                }
                catch
                {
                }
            }

            MessageBox.Show("Issue Completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.CloseForm();
        }

        private bool GenerateTransaction(ItemOnhandModel line, double qty)
        {
            MaterialIssueModel Head = _view.head;

            ItemTransactionModel trans = new ItemTransactionModel();
            trans.InventoryItemId = line.InventoryItemId;
            trans.SubinventoryCode = line.SubinventoryCode;
            trans.TransactionSourceName = "MATERIAL ISSUE";
            trans.TransactionQuantity = qty * -1;
            trans.TransactionUom = string.IsNullOrEmpty(line.TransactionUomCode) ? "PCS" : line.TransactionUomCode;
            trans.PrimaryQuantity = qty * -1;
            trans.TransactionDate = Head.IssueDate;
            trans.TransactionReference = Head.IssueNumber;
            //trans.TransactionSourceName
            trans.TransactionSourceId = line.OnhandQuantitiesId;        //Only Materail Issue using ONHAND_QUANTITIES_ID
            trans.CostedFlag = "Y";
            trans.ActualCost = line.TransactionUnitCost;
            trans.TransactionCost = line.TransactionUnitCost;
            trans.Attribute1 = string.IsNullOrEmpty(line.IssueProjectNum) ? line.ProjectNum : line.IssueProjectNum;
            trans.Attribute2 = string.IsNullOrEmpty(line.IssueCostCode) ? line.ProjectCostCode : line.IssueCostCode;
            trans.Attribute3 = line.LotNumber;
            trans.Attribute4 = line.BomNo;

            int id = _repoTrans.InsertTrans(trans);

            ItemOnhandModel onhand = line;

            //if (onhand != null)
            //{

            double trxQty = onhand.PrimaryTransactionQuantity - qty;
            onhand.PrimaryTransactionQuantity = trxQty;
            onhand.TransactionQuantity = trxQty;
            onhand.UpdateTransactionId = id;
            onhand.TransactionUnitCost = trans.ActualCost;

            _repoOnhand.UpdateOnhand(onhand);
            //}
            return true;
        }

        private void GenerateNumber(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.head.IssueNumber))
            {
                MaterialIssueModel rcv = _view.head;
                rcv.IssueNumber = _repoTrans.GenIssueNumber("ISSUE_NUMBER");
                _view.head = rcv;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            MaterialIssueModel issue = new MaterialIssueModel();
            issue.IssueBy = _view.EpiSession.User.Id;
            issue.IssueByName = _view.EpiSession.User.Description;
            issue.IssueDate = DateTime.Now;

            _view.BindingData();
            _view.head = issue;
            _view.bindingHead.DataSource = ToDataTable(_view.onhandsSelected.ToList());
            _view.DataGridViewLoop();

        }

        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        private DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
    }
}