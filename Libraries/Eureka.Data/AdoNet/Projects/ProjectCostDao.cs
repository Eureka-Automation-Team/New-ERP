using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class ProjectCostDao : IProjectCostDao
    {
        private static Db db = new Db("ms_sql");

        public List<ProjectCostModel> GetAll()
        {
            string sql = @"SELECT proj_cost_id, line_num, project_id
	                        , project_num, cost_id, cost_code, orig_amt
	                        , plan_cost, fcst_cost, act_cost
	                        , uf_ctg_amt, uf_cbd_amt, uf_last_forecast
	                        , uf_budget_remain, uf_budget_org, uf_proj_reason
	                        , last_update_date, last_updated_by
	                        , creation_date, created_by
                            , excess_cost, remarks, instock_cost_amt
                            , bg_cost_usaged, bg_cost_actual, bg_cost_usagedinstock
                          FROM prj_project_costs";

            return db.Read(sql, Make).ToList();
        }

        public List<ProjectCostModel> GetByCostCode(string costCode)
        {
            string sql = @"SELECT proj_cost_id, line_num, project_id
	                        , project_num, cost_id, cost_code, orig_amt
	                        , plan_cost, fcst_cost, act_cost
	                        , uf_ctg_amt, uf_cbd_amt, uf_last_forecast
	                        , uf_budget_remain, uf_budget_org, uf_proj_reason
	                        , last_update_date, last_updated_by
	                        , creation_date, created_by
                            , excess_cost, remarks, instock_cost_amt
                            , bg_cost_usaged, bg_cost_actual, bg_cost_usagedinstock
                          FROM prj_project_costs
                         WHERE cost_code = @cost_code";

            object[] parms = { "@cost_code", costCode };
            return db.Read(sql, Make, parms).ToList();
        }

        public ProjectCostModel GetByID(int id)
        {
            string sql = @"SELECT proj_cost_id, line_num, project_id
	                        , project_num, cost_id, cost_code, orig_amt
	                        , plan_cost, fcst_cost, act_cost
	                        , uf_ctg_amt, uf_cbd_amt, uf_last_forecast
	                        , uf_budget_remain, uf_budget_org, uf_proj_reason
	                        , last_update_date, last_updated_by
	                        , creation_date, created_by
                            , excess_cost, remarks, instock_cost_amt
                            , bg_cost_usaged, bg_cost_actual, bg_cost_usagedinstock
                          FROM prj_project_costs
                         WHERE proj_cost_id = @proj_cost_id";

            object[] parms = { "@proj_cost_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<ProjectCostModel> GetByProjectNum(string prjNum)
        {
            string sql = @"SELECT proj_cost_id, line_num, project_id
	                        , project_num, cost_id, cost_code, orig_amt
	                        , plan_cost, fcst_cost, act_cost
	                        , uf_ctg_amt, uf_cbd_amt, uf_last_forecast
	                        , uf_budget_remain, uf_budget_org, uf_proj_reason
	                        , last_update_date, last_updated_by
	                        , creation_date, created_by
                            , excess_cost, remarks, instock_cost_amt
                            , bg_cost_usaged, bg_cost_actual, bg_cost_usagedinstock
                          FROM prj_project_costs
                         WHERE project_num = @project_num";

            object[] parms = { "@project_num", prjNum };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<ProjectCostModel> GetByProjectID(int prjId)
        {
            string sql = @"SELECT prjc.proj_cost_id, prjc.line_num, prjc.project_id
	                            , prjc.project_num, prjc.cost_id, prjc.cost_code, prjc.orig_amt
	                            , prjc.plan_cost, prjc.fcst_cost, prjc.act_cost
	                            , prjc.uf_ctg_amt, prjc.uf_cbd_amt, prjc.uf_last_forecast
	                            , prjc.uf_budget_remain, prjc.uf_budget_org, prjc.uf_proj_reason
	                            , prjc.last_update_date, prjc.last_updated_by
	                            , prjc.creation_date, prjc.created_by, grp.cost_desc
                                , prjc.excess_cost, prjc.remarks, prjc.instock_cost_amt
                                , prjc.bg_cost_usaged, prjc.bg_cost_actual, prjc.bg_cost_usagedinstock
                            FROM prj_project_costs prjc
                            LEFT JOIN prj_cost_groups grp ON(prjc.cost_id = grp.cost_id)
                            WHERE prjc.project_id = @project_id";

            object[] parms = { "@project_id", prjId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public ProjectCostModel GetByProjectCost(string projectNum, string costCode)
        {
            string sql = @"SELECT prjc.proj_cost_id, prjc.line_num, prjc.project_id
	                            , prjc.project_num, prjc.cost_id, prjc.cost_code, prjc.orig_amt
	                            , prjc.plan_cost, prjc.fcst_cost, prjc.act_cost
	                            , prjc.uf_ctg_amt, prjc.uf_cbd_amt, prjc.uf_last_forecast
	                            , prjc.uf_budget_remain, prjc.uf_budget_org, prjc.uf_proj_reason
	                            , prjc.last_update_date, prjc.last_updated_by
	                            , prjc.creation_date, prjc.created_by, grp.cost_desc
                                , prjc.excess_cost, prjc.remarks, prjc.instock_cost_amt
                                , prjc.bg_cost_usaged, prjc.bg_cost_actual, prjc.bg_cost_usagedinstock
                            FROM prj_project_costs prjc
                            LEFT JOIN prj_cost_groups grp ON(prjc.cost_id = grp.cost_id)
                            WHERE prjc.project_num = @project_num
	                            AND prjc.cost_code = @cost_code";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public double GetCostUsage(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM(amt.amount)  amount
                            FROM
                            (SELECT SUM(ISNULL(pol.encumbrance_amount, rql.encumbrance_amount)) amount
	                            FROM po_requisition_lines_all rql
	                            LEFT JOIN po_lines_all pol ON(rql.po_line_id = pol.po_line_id
								                            AND rql.ref_project_num = pol.ref_project_num
								                            AND rql.cost_code = pol.cost_code
								                            AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'Y')
	                            WHERE rql.cancel_flag = 'N'	
		                            AND rql.ref_project_num = @project_num
		                            AND rql.cost_code = @cost_code
		                            AND rql.encumbrance_flag = 'Y'
                                    AND rql.purchased_flag = 'N'
	                            GROUP BY rql.ref_project_num, rql.cost_code

	                            UNION ALL

	                            SELECT ISNULL(SUM(pol.encumbrance_amount),0) amount
	                            FROM po_lines_all pol 
	                            WHERE pol.ref_project_num = @project_num
		                            AND pol.cost_code = @cost_code
		                            AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'Y'
		                            AND CAST(pol.creation_date as DATE) > CAST('7-31-2019' as DATE)) amt";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public double GetCostUsagePurchaseOnly(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM(pol.encumbrance_amount) amount
                            FROM po_lines_all pol 
                            WHERE pol.ref_project_num = @project_num
                            AND pol.cost_code = @cost_code
                            AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'Y'
                            AND CAST(pol.creation_date as DATE) > CAST('7-31-2019' as DATE)";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public double GetExcessCost(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM(amt.amount) amount FROM
                            (SELECT SUM(ISNULL(pol.extended_amount, rql.extended_amount)) amount
                                                        FROM po_requisition_lines_all rql
                                                        LEFT JOIN po_lines_all pol ON(rql.po_line_id = pol.po_line_id
							                                                        AND rql.ref_project_num = pol.ref_project_num
							                                                        AND rql.cost_code = pol.cost_code
							                                                        AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'N')
                                                        WHERE rql.cancel_flag = 'N'	
	                                                        AND rql.ref_project_num = @project_num
	                                                        AND rql.cost_code = @cost_code
                                                            AND rql.encumbrance_flag = 'N'
                                                            AND rql.purchased_flag = 'N'
                                                        GROUP BY rql.ref_project_num, rql.cost_code
                            UNION ALL
                            SELECT ISNULL(SUM(pol.extended_amount * ISNULL(pol.currency_rate, 1)), 0) amount
                                                        FROM po_lines_all pol 
                                                        WHERE pol.ref_project_num = @project_num
                                                        AND pol.cost_code = @cost_code
                                                        AND CAST(pol.creation_date as DATE) > CAST('7-31-2019' as DATE)
                                                        AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'N') amt";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public double GetExcessCostPurchaseOnly(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM(pol.extended_amount) amount
                            FROM po_lines_all pol 
                            WHERE pol.ref_project_num = @project_num
                            AND pol.cost_code = @cost_code
                            AND CAST(pol.creation_date as DATE) > CAST('7-31-2019' as DATE)
                            AND pol.cancel_flag = 'N' AND pol.encumbrance_flag = 'N'";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public double GetActualCost(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM((mat.transaction_quantity + mat.quantity_adjusted) * mat.actual_cost) amount
                                FROM mtl_material_transactions mat 
                                WHERE mat.transaction_source_name = 'MATERIAL ISSUE'
                                AND mat.attribute1 = @project_num
                                AND mat.attribute2 = @cost_code";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public double GetActualCostInstock(string projectNum, string costCode)
        {
            string sql = @"SELECT SUM((mat.transaction_quantity + mat.quantity_adjusted) * mat.actual_cost) amount
                                FROM mtl_material_transactions mat 
                                WHERE mat.transaction_source_name = 'MATERIAL ISSUE'
                                AND mat.attribute1 = @project_num
                                AND mat.attribute2 = @cost_code
                                AND mat.subinventory_code in ('ST01','WP01', 'SP01', 'S01', 'EAFG', 'PF03')";

            object[] parms = { "@project_num", projectNum, "@cost_code", costCode };
            return db.Read(sql, MakeStat, parms).FirstOrDefault();
        }

        public int Insert(ProjectCostModel model)
        {
            string sql =
                @"INSERT INTO prj_project_costs
                       ( line_num, project_id
                        , project_num, cost_id, cost_code
                        , orig_amt, plan_cost, fcst_cost
                        , act_cost, uf_ctg_amt, uf_cbd_amt
                        , uf_last_forecast, uf_budget_remain, uf_budget_org
                        , uf_proj_reason, last_update_date, last_updated_by
                        , creation_date, created_by
                        , excess_cost, remarks, instock_cost_amt
                        , bg_cost_usaged, bg_cost_actual, bg_cost_usagedinstock)
                    VALUES
                        ( @line_num, @project_id
                        , @project_num, @cost_id, @cost_code
                        , @orig_amt, @plan_cost, @fcst_cost
                        , @act_cost, @uf_ctg_amt, @uf_cbd_amt
                        , @uf_last_forecast, @uf_budget_remain, @uf_budget_org
                        , @uf_proj_reason, @last_update_date, @last_updated_by
                        , @creation_date, @created_by
                        , @excess_cost, @remarks, @instock_cost_amt
                        , @bg_cost_usaged, @bg_cost_actual, @bg_cost_usagedinstock)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ProjectCostModel model)
        {
            string sql =
            @"UPDATE  prj_project_costs 
                   SET  line_num  = @line_num
                      , project_id  = @project_id
                      , project_num  = @project_num
                      , cost_id  = @cost_id
                      , cost_code  = @cost_code
                      , orig_amt  = @orig_amt
                      , plan_cost  = @plan_cost
                      , fcst_cost  = @fcst_cost
                      , act_cost  = @act_cost
                      , uf_ctg_amt  = @uf_ctg_amt
                      , uf_cbd_amt  = @uf_cbd_amt
                      , uf_last_forecast  = @uf_last_forecast
                      , uf_budget_remain  = @uf_budget_remain
                      , uf_budget_org  = @uf_budget_org
                      , uf_proj_reason  = @uf_proj_reason
                      , last_update_date  = @last_update_date
                      , last_updated_by  = @last_updated_by
                      , excess_cost = @excess_cost
                      , remarks = @remarks
                      , bg_cost_usaged = @bg_cost_usaged
                      , bg_cost_actual = @bg_cost_actual
                      , bg_cost_usagedinstock = @bg_cost_usagedinstock
                      , instock_cost_amt= @instock_cost_amt
                 WHERE proj_cost_id = @proj_cost_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ProjectCostModel model)
        {
            string sql = @"DELETE FROM prj_project_costs WHERE proj_cost_id = @proj_cost_id";

            object[] parms = { "@proj_cost_id", model.Id };
            db.Update(sql, parms);
        }

        private static Func<IDataReader, ProjectCostModel> MakeWithStats = reader =>
        {
            var projcost = Make(reader);
            projcost.CostDescription = reader["cost_desc"].AsString();

            return projcost;
        };

        private static Func<IDataReader, double> MakeStat = reader =>
        {
            return reader["amount"].AsDouble();
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, ProjectCostModel> Make = reader =>
             new ProjectCostModel
             {
                 Id = reader["proj_cost_id"].AsInt(),
                 LineNum = reader["line_num"].AsInt(),
                 ProjectId = reader["project_id"].AsInt(),
                 ProjectNum = reader["project_num"].AsString(),
                 CostId = reader["cost_id"].AsInt(),
                 CostCode = reader["cost_code"].AsString(),
                 OrigAmount = reader["orig_amt"].AsDouble(),
                 BudgetCostAmount = reader["plan_cost"].AsDouble(),
                 FcstCostAmount = reader["fcst_cost"].AsDouble(),
                 ActCostAmount = reader["act_cost"].AsDouble(),
                 CTGAmount = reader["uf_ctg_amt"].AsDouble(),
                 CBDAmount = reader["uf_cbd_amt"].AsDouble(),
                 UfLastForecast = reader["uf_last_forecast"].AsDouble(),
                 //UfBudgetRemain = reader["uf_budget_remain"].AsDouble(),
                 MP1Amount = reader["uf_budget_org"].AsDouble(),
                 UfProjectReason = reader["uf_proj_reason"].AsString(),                 
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdateBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ExcessCost = reader["excess_cost"].AsDouble(),
                 Remarks = reader["remarks"].AsString(),
                 BeginCostUsaged = reader["bg_cost_usaged"].AsDouble(),
                 BeginCostActual = reader["bg_cost_actual"].AsDouble(),
                 BeginCostUsagedInstock = reader["bg_cost_usagedinstock"].AsDouble(),
                 InstockCostAmount = reader["instock_cost_amt"].AsDouble()
             };

        private object[] Take(ProjectCostModel model)
        {
            return new object[]
            {
                "@proj_cost_id", model.Id,
                "@line_num", model.LineNum,
                "@project_id", model.ProjectId,
                "@project_num", model.ProjectNum,
                "@cost_id", model.CostId,
                "@cost_code", model.CostCode,
                "@orig_amt", model.OrigAmount,
                "@plan_cost", model.BudgetCostAmount,
                "@fcst_cost", model.FcstCostAmount,
                "@act_cost", model.ActCostAmount,
                "@uf_ctg_amt", model.CTGAmount,
                "@uf_cbd_amt", model.CBDAmount,
                "@uf_last_forecast", model.UfLastForecast,
                "@uf_budget_remain", model.UfBudgetRemain,
                "@uf_budget_org", model.MP1Amount,
                "@uf_proj_reason", model.UfProjectReason,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdateBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@excess_cost", model.ExcessCost,
                "@remarks", model.Remarks,
                "@bg_cost_usaged", model.BeginCostUsaged,
                "@bg_cost_actual", model.BeginCostActual,
                "@bg_cost_usagedinstock", model.BeginCostUsagedInstock,
                "@instock_cost_amt", model.InstockCostAmount
            };
        }
    }
}
