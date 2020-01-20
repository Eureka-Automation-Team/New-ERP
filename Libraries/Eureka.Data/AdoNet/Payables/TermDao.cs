using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Payables;

namespace Eureka.Data.AdoNet.Payables
{
    public class TermDao : ITermDao
    {
        private static Db db = new Db("ms_sql");

        public List<TermModel> GetAll()
        {
            string sql = @"SELECT term_id,term_code,description,due_day
                                  ,last_update_date,last_updated_by
                                  ,creation_date,created_by
                              FROM ap_terms";

            return db.Read(sql, Make).ToList();
        }

        public TermModel GetByCode(string code)
        {
            string sql = @"SELECT term_id,term_code,description,due_day
                                  ,last_update_date,last_updated_by
                                  ,creation_date,created_by
                              FROM ap_terms
                         WHERE term_code = @term_code";

            object[] parms = { "@term_code", code };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public TermModel GetByID(int id)
        {
            string sql = @"SELECT term_id,term_code,description,due_day
                                  ,last_update_date,last_updated_by
                                  ,creation_date,created_by
                              FROM ap_terms
                         WHERE term_id = @term_id";

            object[] parms = { "@term_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(TermModel model)
        {
            string sql =
                @"INSERT INTO ap_terms
                       (term_code
                       , description
                       , due_day
                       , last_update_date
                       , last_updated_by
                       , creation_date
                       , created_by)
                 VALUES
                       (@term_code
                       , @description
                       , @due_day
                       , @last_update_date
                       , @last_updated_by
                       , @creation_date
                       , @created_by)";

            return db.Insert(sql, Take(model));
        }

        public void Update(TermModel model)
        {
            string sql =
            @"UPDATE ap_terms
                   SET term_code = @term_code
                      ,description = @description
                      ,due_day = @due_day
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                 WHERE term_id = @term_id";

            db.Update(sql, Take(model));
        }

        public void Delete(TermModel model)
        {
            string sql = @"DELETE FROM ap_terms WHERE term_id = @term_id";

            object[] parms = { "@term_id", model.TermId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, TermModel> Make = reader =>
             new TermModel
             {
                 TermId = reader["term_id"].AsInt(),
                 TermCode = reader["term_code"].AsString(),
                 Description = reader["description"].AsString(),
                 DueDay = reader["due_day"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(TermModel model)
        {
            return new object[]
            {
                "@term_id", model.TermId,
                "@term_code", model.TermCode,
                "@description", model.Description,
                "@due_day", model.DueDay,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,             
            };
        }
    }
}
