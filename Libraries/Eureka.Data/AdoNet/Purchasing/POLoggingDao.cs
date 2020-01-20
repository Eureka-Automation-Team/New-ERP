using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POLoggingDao : IPOLoggingDao
    {
        private static Db db = new Db("ms_sql");

        public List<POLoggingModel> GetAll()
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            ORDER BY lg.loging_id DESC";

            return db.Read(sql, Make).ToList();
        }

        public List<POLoggingModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            WHERE cast(lg.creation_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY lg.loging_id DESC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public POLoggingModel GetByID(int id)
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            WHERE lg.loging_id = @loging_id";

            object[] parms = { "@loging_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<POLoggingModel> GetByPoId(int id)
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            WHERE lg.po_header_id = @po_header_id";

            object[] parms = { "@po_header_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLoggingModel> GetByPrId(int id)
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            WHERE lg.requisition_header_id = @requisition_header_id";

            object[] parms = { "@requisition_header_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLoggingModel> GetByUserId(int id)
        {
            string sql = @"SELECT lg.loging_id, lg.loging_source, lg.action_source
	                            , lg.action_by, lg.last_update_date, lg.last_updated_by
	                            , lg.creation_date, lg.created_by, lg.action_description
	                            , lg.po_header_id, lg.po_line_id, lg.requisition_header_id
	                            , lg.requisition_line_id
                            FROM po_loggings lg
                            WHERE lg.action_by = @action_by";

            object[] parms = { "@action_by", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public int Insert(POLoggingModel model)
        {
            string sql =
                @"INSERT INTO po_loggings
                       (loging_source
                       ,action_source
                       ,action_by
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by
                       ,action_description
                       ,po_header_id
                       ,po_line_id
                       ,requisition_header_id
                       ,requisition_line_id)
                 VALUES
                       (@loging_source
                       ,@action_source
                       ,@action_by
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by
                       ,@action_description
                       ,@po_header_id
                       ,@po_line_id
                       ,@requisition_header_id
                       ,@requisition_line_id)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POLoggingModel model)
        {
            string sql =
            @"UPDATE po_loggings
               SET loging_source = @loging_source
                  ,action_source = @action_source
                  ,action_by = @action_by
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,creation_date = @creation_date
                  ,created_by = @created_by
                  ,action_description = @action_description
                  ,po_header_id = @po_header_id
                  ,po_line_id = @po_line_id
                  ,requisition_header_id = @requisition_header_id
                  ,requisition_line_id = @requisition_line_id
             WHERE loging_id = @loging_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POLoggingModel model)
        {
            string sql = @"DELETE FROM po_loggings WHERE loging_id = @loging_id";

            object[] parms = { "@loging_id", model.LogingId };
            db.Update(sql, parms);
        }

        private static Func<IDataReader, POLoggingModel> Make = reader =>
         new POLoggingModel
         {
             LogingId = reader["loging_id"].AsInt(),
             LogingSource = reader["loging_source"].AsString(),
             ActionSource = reader["action_source"].AsString(),
             ActionBy = reader["action_by"].AsInt(),
             ActionDescription = reader["action_description"].AsString(),
             PoHeaderId = reader["po_header_id"].AsInt(),
             PoLineId = reader["po_line_id"].AsInt(),
             RequisitionHeaderId = reader["requisition_header_id"].AsInt(),
             RequisitionLineId = reader["requisition_line_id"].AsInt(),
             LastUpdateDate = reader["last_update_date"].AsDateTime(),
             LastUpdatedBy = reader["last_updated_by"].AsInt(),
             CreationDate = reader["creation_date"].AsDateTime(),
             CreatedBy = reader["created_by"].AsInt()
         };

        private object[] Take(POLoggingModel model)
        {
            return new object[]
            {
                "@loging_id", model.LogingId,
                "@loging_source", model.LogingSource,
                "@action_source", model.ActionSource,
                "@action_by", model.ActionBy,
                "@action_description", model.ActionDescription,
                "@po_header_id", model.PoHeaderId,
                "@po_line_id", model.PoLineId,
                "@requisition_header_id", model.RequisitionHeaderId,
                "@requisition_line_id", model.RequisitionLineId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
