using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Froms.Views.Inventory;
using Eureka.Froms.Views.Projects;
using Eureka.Services.Inventory;
using Eureka.Services.Projects;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Inventory
{
    public class MaterialIssuePresenter
    {
        private readonly IMaterialIssueView _view;
        private readonly IItemOnhandSrv _repository;
        private readonly IProjectSrv _repoProj;

        public MaterialIssuePresenter(IMaterialIssueView view)
        {
            _view = view;
            _repository = new ItemOnhandSrv();
            _repoProj = new ProjectSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Find_Project += Find_Project;
            _view.Issue_Entry += Issue_Entry;
            _view.Insert_Cache += Insert_Cache;
            _view.Delete_Cache += Delete_Cache;
            _view.Clear_Cache += Clear_Cache;
            _view.Project_Change += Project_Change;
            _view.CostCode_Change += CostCode_Change;
        }

        private void CostCode_Change(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string costCode = cbo.Text;

            if (!string.IsNullOrEmpty(costCode))
            {
                ProjectCostModel cost = _view.costs.Where(x => x.CostCode == costCode).FirstOrDefault();
                if (cost == null)
                {
                    _view.forCostCode = string.Empty;
                    _view.costs = new List<ProjectCostModel>();
                    _view.BindingComboProjectsCost(_view.costs.ToList());
                    return;
                }
            }
            else
            {
                costCode = string.Empty;
            }

            _view.forCostCode = costCode;
        }

        private void Project_Change(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string projectNum = cbo.Text;

            if (!string.IsNullOrEmpty(projectNum))
            {
                ProjectModel prj = _view.projs.Where(x => x.ProjectNum == projectNum).FirstOrDefault();
                if (prj != null)
                {                   
                    _view.costs = _repoProj.GetProjectCostByProjID(prj.Id);
                    _view.BindingComboProjectsCost(_view.costs.ToList());                    
                }
                else
                {
                    //_view.forProjectNo = string.Empty;
                    _view.costs = new List<ProjectCostModel>();
                    _view.BindingComboProjectsCost(_view.costs.ToList());
                    return;
                }
            }
            else
            {
                projectNum = string.Empty;
            }

            _view.forProjectNo = projectNum;
            _view.forCostCode = string.Empty;
        }

        private void Clear_Cache(object sender, EventArgs e)
        {
            _view.onhandsCache = new List<ItemOnhandModel>();
            _view.BindingCache(_view.onhandsCache.ToList());
        }

        private void Delete_Cache(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            List<ItemOnhandModel> lines = _view.onhandsCache.ToList();

            foreach (DataGridViewRow item in grid.SelectedRows)
            {
                try
                {
                    //if ((bool)item.Cells[0].Value)
                    //{
                        int id = (int)item.Cells[0].Value;
                        lines.RemoveAll(x => x.OnhandQuantitiesId == id);
                    //}
                }
                catch
                {
                }
            }

            _view.onhandsCache = lines;
            _view.bindingCache.DataSource = _view.onhandsCache;
            //_view.BindingCache(_view.onhandsCache.ToList());
        }

        private void Insert_Cache(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            List<ItemOnhandModel> lines = new List<ItemOnhandModel>(); //grid.SelectedRows.DataBoundItem;
            List<ItemOnhandModel> onhands = _view.onhands.ToList();

            if (_view.onhandsCache != null)
                lines = _view.onhandsCache.ToList();

            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    if ((bool)item.Cells[0].Value)
                    {
                        int id = (int)item.Cells[1].Value;
                        //ItemOnhandModel line = _view.onhands.Where(x => x.OnhandQuantitiesId == id).FirstOrDefault();
                        ItemOnhandModel line = (ItemOnhandModel)item.DataBoundItem;

                        line.IssueProjectNum = string.IsNullOrEmpty(_view.forProjectNo) ? line.ProjectNum : _view.forProjectNo;
                        line.IssueCostCode = string.IsNullOrEmpty(_view.forCostCode) ? line.ProjectCostCode : _view.forCostCode;

                        if(!string.IsNullOrEmpty(_view.forProjectNo) && string.IsNullOrEmpty(_view.forCostCode))
                        {
                            MessageBox.Show("Please select cost code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        lines.Add(line);
                        onhands.RemoveAll(x => x.OnhandQuantitiesId == id);
                    }
                }
                catch
                {
                }
            }

            if (lines.Count > 0)
            {
                _view.onhandsCache = lines;
                _view.bindingCache.DataSource = _view.onhandsCache;
                //_view.BindingCache(_view.onhandsCache.ToList());

                _view.onhands = onhands;
                _view.bindingHead.DataSource = _view.onhands;
                //_view.BindingData(_view.onhands.ToList());
            }
            else
            {
                MessageBox.Show("Please select rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Issue_Entry(object sender, EventArgs e)
        {
            /*
            MetroGrid grid = sender as MetroGrid;

            List<ItemOnhandModel> lines = new List<ItemOnhandModel>(); //grid.SelectedRows.DataBoundItem;
            foreach (DataGridViewRow item in grid.Rows)
            {
                try
                {
                    if ((bool)item.Cells[0].Value)
                    {
                        int id = (int)item.Cells[1].Value;
                        ItemOnhandModel line = _view.onhands.Where(x => x.OnhandQuantitiesId == id).FirstOrDefault();
                        lines.Add(line);
                    }
                }
                catch
                {
                }
            }
            */
            if (_view.onhandsCache.Count() > 0)
            {
                //_view.onhandsSelected = lines;

                using (MaterialIssueEntryForm frm = new MaterialIssueEntryForm(_view.onhandsCache))
                {
                    frm.ShowDialog();
                    Filter_Click(null, null);
                    _view.onhandsCache = new List<ItemOnhandModel>();
                    _view.BindingCache(_view.onhandsCache.ToList());
                }
            }
            else
            {
                MessageBox.Show("Please select rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Find_Project(object sender, EventArgs e)
        {
            using (ProjectListForm frm = new ProjectListForm())
            {
                frm.projectNum = _view.projNo;
                frm.ShowDialog();
                if (frm.projSelected != null)
                {
                    _view.projNo = frm.projSelected.FirstOrDefault().ProjectNum;
                }
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_view.projNo))
            //{
            //    MessageBox.Show("Please select Project Number to finding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //var result = _repository.GetBySubinventoryCode(_view.projNo).OrderBy(o => o.ItemCode).ThenBy(o => o.LotNumber).ToList();
            var result = _repository.GetAll().OrderBy(o => o.ItemCode).ThenBy(o => o.LotNumber).ToList();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.projNo)) result = result.Where(x => x.SubinventoryCode.ToUpper().Equals(_view.projNo.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(_view.bomNo)) result = result.Where(x => x.BomNo == (_view.bomNo)).ToList();
                if (!string.IsNullOrEmpty(_view.itemNo)) result = result.Where(x => x.ItemCode.ToUpper().Contains(_view.itemNo.ToUpper())
                                                    || (string.IsNullOrEmpty(x.ItemDescription) ? "" : x.ItemDescription.ToUpper()).Contains(_view.itemNo.ToUpper())
                                                    || (string.IsNullOrEmpty(x.ManuID) ? "" : x.ManuID.ToUpper()).Contains(_view.itemNo.ToUpper())
                                                    || (string.IsNullOrEmpty(x.BrandMat) ? "" : x.BrandMat.ToUpper()).Contains(_view.itemNo.ToUpper())).ToList();
            }

            _view.onhands = result.ToList();
            _view.BindingData(_view.onhands.ToList());
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            _view.onhands = new List<ItemOnhandModel>();
            _view.onhandsCache = new List<ItemOnhandModel>();
            _view.projs = await GetProjectListAsync();
            _view.projNo = string.Empty;
            _view.bomNo = string.Empty;
            _view.itemNo = string.Empty;

            //_view.BindingData(ToDataTable(_view.onhands.ToList()));
            //_view.BindingCache(ToDataTable(_view.onhandsCache.ToList()));
            _view.BindingData(_view.onhands.ToList());
            _view.BindingCache(_view.onhandsCache.ToList());
            _view.BindingComboProjects(_view.projs.ToList());
        }

        public async Task<List<ProjectModel>> GetProjectListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                var List = _repoProj.GetProjectAll();
                return List;
            });
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