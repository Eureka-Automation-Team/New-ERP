using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;

namespace Eureka.Data.AdoNet.Commons
{
    public class TaxCodeDao : ITaxCodeDao
    {
        private static Db db = new Db("ms_sql");

        public List<TaxCodeModel> GetAll()
        {
            string sql = @"SELECT tax_id,tax_code,description
                              ,tax_rate,last_update_date
                              ,last_updated_by,creation_date
                              ,created_by
                          FROM gl_taxs_code
                          ORDER BY tax_code";

            return db.Read(sql, Make).ToList();
        }

        public TaxCodeModel GetByCode(string code)
        {
            string sql = @"SELECT tax_id,tax_code,description
                              ,tax_rate,last_update_date
                              ,last_updated_by,creation_date
                              ,created_by
                          FROM gl_taxs_code
                          WHERE tax_code = @tax_code";

            object[] parms = { "@tax_code", code };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(TaxCodeModel model)
        {
            string sql =
                @"INSERT INTO gl_taxs_code
                       (tax_code
                       ,description
                       ,tax_rate
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by)
                 VALUES
                       (@tax_code
                       ,@description
                       ,@tax_rate
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by)";

            return db.Insert(sql, Take(model));
        }

        public void Update(TaxCodeModel model)
        {
            string sql =
            @"UPDATE gl_taxs_code
               SET tax_code = @tax_code
                  ,description = @description
                  ,tax_rate = @tax_rate
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,creation_date = @creation_date
                  ,created_by = @created_by
             WHERE tax_id = @tax_id";

            db.Update(sql, Take(model));
        }

        public void Delete(TaxCodeModel model)
        {
            string sql =
            @"DELETE FROM gl_taxs_code
               WHERE tax_id = @tax_id";

            db.Update(sql, Take(model));
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, TaxCodeModel> Make = reader =>
             new TaxCodeModel
             {
                 TaxId = reader["tax_id"].AsInt(),
                 TaxCode = reader["tax_code"].AsString(),
                 Description = reader["description"].AsString(),
                 TaxRate = reader["tax_rate"].AsDouble(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(TaxCodeModel model)
        {
            return new object[]
            {
                "@tax_id", model.TaxId,
                "@tax_code", model.TaxCode,
                "@description", model.Description,
                "@tax_rate", model.TaxRate,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
