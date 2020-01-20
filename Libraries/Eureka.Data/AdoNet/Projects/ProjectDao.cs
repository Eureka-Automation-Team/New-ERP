using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class ProjectDao : IProjectDao
    {
        private static Db db = new Db("ms_sql");

        public List<ProjectModel> GetAll()
        {
            string sql = @"SELECT project_id,project_num,project_desc
		                    ,type,project_date,stat
		                    ,customer_id,customer_num,customer_name
		                    ,item_id,product_code,contract_id
		                    ,contract_code,project_manager_id,project_manager_name
		                    ,project_rev,tax_code,exchange_rate
		                    ,uf_contract_name,uf_estimate_order,uf_sale_person
		                    ,uf_qty_order,uf_note,uf_cbdno
		                    ,uf_project_desc_long,uf_close_flag,uf_boi
		                    ,last_update_date,last_updated_by,creation_date
		                    ,created_by
                         FROM prj_project
                         WHERE stat = 'A'
                         ORDER BY project_date DESC";

            return db.Read(sql, Make).ToList();
        }

        public List<ProjectModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT project_id,project_num,project_desc
		                    ,type,project_date,stat
		                    ,customer_id,customer_num,customer_name
		                    ,item_id,product_code,contract_id
		                    ,contract_code,project_manager_id,project_manager_name
		                    ,project_rev,tax_code,exchange_rate
		                    ,uf_contract_name,uf_estimate_order,uf_sale_person
		                    ,uf_qty_order,uf_note,uf_cbdno
		                    ,uf_project_desc_long,uf_close_flag,uf_boi
		                    ,last_update_date,last_updated_by,creation_date
		                    ,created_by
                         FROM prj_project
                            WHERE cast(project_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            AND stat = 'A'
                            ORDER BY project_date DESC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public ProjectModel GetByID(int id)
        {
            string sql = @"SELECT project_id,project_num,project_desc
		                    ,type,project_date,stat
		                    ,customer_id,customer_num,customer_name
		                    ,item_id,product_code,contract_id
		                    ,contract_code,project_manager_id,project_manager_name
		                    ,project_rev,tax_code,exchange_rate
		                    ,uf_contract_name,uf_estimate_order,uf_sale_person
		                    ,uf_qty_order,uf_note,uf_cbdno
		                    ,uf_project_desc_long,uf_close_flag,uf_boi
		                    ,last_update_date,last_updated_by,creation_date
		                    ,created_by
                         FROM prj_project
                         WHERE project_id = @project_id";

            object[] parms = { "@project_id", id};
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public ProjectModel GetByNum(string number)
        {
            string sql = @"SELECT project_id,project_num,project_desc
		                    ,type,project_date,stat
		                    ,customer_id,customer_num,customer_name
		                    ,item_id,product_code,contract_id
		                    ,contract_code,project_manager_id,project_manager_name
		                    ,project_rev,tax_code,exchange_rate
		                    ,uf_contract_name,uf_estimate_order,uf_sale_person
		                    ,uf_qty_order,uf_note,uf_cbdno
		                    ,uf_project_desc_long,uf_close_flag,uf_boi
		                    ,last_update_date,last_updated_by,creation_date
		                    ,created_by
                         FROM prj_project
                         WHERE project_num = @project_num";

            object[] parms = { "@project_num", number };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ProjectModel model)
        {
            string sql =
                @"INSERT INTO prj_project
                       (project_num, project_desc, type
			            , project_date, stat, customer_id
			            , customer_num, customer_name, item_id
			            , product_code, contract_id, contract_code
			            , project_manager_id, project_manager_name, project_rev
			            , tax_code, exchange_rate, uf_contract_name
			            , uf_estimate_order, uf_sale_person, uf_qty_order
			            , uf_note, uf_cbdno, uf_project_desc_long
			            , uf_close_flag, uf_boi, last_update_date
			            , last_updated_by, creation_date, created_by)
                 VALUES
                       (@project_num, @project_desc, @type
			            , @project_date, @stat, @customer_id
			            , @customer_num, @customer_name, @item_id
			            , @product_code, @contract_id, @contract_code
			            , @project_manager_id, @project_manager_name, @project_rev
			            , @tax_code, @exchange_rate, @uf_contract_name
			            , @uf_estimate_order, @uf_sale_person, @uf_qty_order
			            , @uf_note, @uf_cbdno, @uf_project_desc_long
			            , @uf_close_flag, @uf_boi, @last_update_date
			            , @last_updated_by, @creation_date, @created_by)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ProjectModel model)
        {
            string sql =
            @"UPDATE prj_project
               SET project_num = @project_num
                  ,project_desc = @project_desc
                  ,type = @type
                  ,project_date = @project_date
                  ,stat = @stat
                  ,customer_id = @customer_id
                  ,customer_num = @customer_num
                  ,customer_name = @customer_name
                  ,item_id = @item_id
                  ,product_code = @product_code
                  ,contract_id = @contract_id
                  ,contract_code = @contract_code
                  ,project_manager_id = @project_manager_id
                  ,project_manager_name = @project_manager_name
                  ,project_rev = @project_rev
                  ,tax_code = @tax_code
                  ,exchange_rate = @exchange_rate
                  ,uf_contract_name = @uf_contract_name
                  ,uf_estimate_order = @uf_estimate_order
                  ,uf_sale_person = @uf_sale_person
                  ,uf_qty_order = @uf_qty_order
                  ,uf_note = @uf_note
                  ,uf_cbdno = @uf_cbdno
                  ,uf_project_desc_long = @uf_project_desc_long
                  ,uf_close_flag = @uf_close_flag
                  ,uf_boi = @uf_boi
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                WHERE project_id = @project_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ProjectModel model)
        {
            string sql = @"DELETE FROM prj_project WHERE project_id = @project_id";

            object[] parms = { "@project_id", model.Id };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, ProjectModel> Make = reader =>
             new ProjectModel
             {
                 Id = reader["project_id"].AsInt(),
                 ProjectNum = reader["project_num"].AsString(),
                 ProjectDescription = reader["project_desc"].AsString(),
                 Type = reader["type"].AsString(),
                 ProjectDate = reader["project_date"].AsDateTime(),
                 State = reader["stat"].AsString(),
                 CustomerId = reader["customer_id"].AsInt(),
                 CustomerNum = reader["customer_num"].AsString(),
                 CustomerName = reader["customer_name"].AsString(),
                 ItemId = reader["item_id"].AsInt(),
                 ProductCode = reader["product_code"].AsString(),
                 ContractId = reader["contract_id"].AsInt(),
                 ContractCode = reader["contract_code"].AsString(),
                 ProjectManagerId = reader["project_manager_id"].AsInt(),
                 ProjectManagerName = reader["project_manager_name"].AsString(),
                 ProjectRev = reader["project_rev"].AsDouble(),
                 TaxCode = reader["tax_code"].AsString(),
                 ExchangeRate = reader["exchange_rate"].AsDouble(),
                 UfContractName = reader["uf_contract_name"].AsString(),
                 UfEstimateOrder = reader["uf_estimate_order"].AsString(),
                 UfSalePerson = reader["uf_sale_person"].AsString(),
                 UfQtyOrder = reader["uf_qty_order"].AsDouble(),
                 UfNote = reader["uf_note"].AsString(),
                 UfCbdNo = reader["uf_cbdno"].AsString(),
                 UfProjectDescLong = reader["uf_project_desc_long"].AsString(),
                 UfCloseFlag = reader["uf_close_flag"].AsString(),
                 UfBoi = reader["uf_boi"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdateBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(ProjectModel model)
        {
            return new object[]
            {
                "@project_id", model.Id,
                "@project_num", model.ProjectNum,
                "@project_desc", model.ProjectDescription,
                "@type", model.Type,
                "@project_date", model.ProjectDate,
                "@stat", model.State,
                "@customer_id", model.CustomerId,
                "@customer_num", model.CustomerNum,
                "@customer_name", model.CustomerName,
                "@item_id", model.ItemId,
                "@product_code", model.ProductCode,
                "@contract_id", model.ContractId,
                "@contract_code", model.ContractCode,
                "@project_manager_id", model.ProjectManagerId,
                "@project_manager_name", model.ProjectManagerName,
                "@project_rev", model.ProjectRev,
                "@tax_code", model.TaxCode,
                "@exchange_rate", model.ExchangeRate,
                "@uf_contract_name", model.UfContractName,
                "@uf_estimate_order", model.UfEstimateOrder,
                "@uf_sale_person", model.UfSalePerson,
                "@uf_qty_order", model.UfQtyOrder,
                "@uf_note", model.UfNote,
                "@uf_cbdno", model.UfCbdNo,
                "@uf_project_desc_long", model.UfProjectDescLong,
                "@uf_close_flag", model.UfCloseFlag,
                "@uf_boi", model.UfBoi,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdateBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
