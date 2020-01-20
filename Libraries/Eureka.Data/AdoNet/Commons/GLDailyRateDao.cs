using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;

namespace Eureka.Data.AdoNet.Commons
{
    public class GLDailyRateDao : IGLDailyRateDao
    {
        private static Db db = new Db("ms_sql");

        public List<GLDailyRateModel> GetAll()
        {
            string sql = @"SELECT curr.currency_code from_currency,
                               rate.to_currency,
                               rate.conversion_date,
                               rate.conversion_rate,
                               rate.conversion_type,
                               rate.status_code,
                               rate.last_update_date,
                               rate.last_updated_by,
                               rate.creation_date,
                               rate.created_by
                          FROM fnd_currencies curr
                               INNER JOIN (  SELECT from_currency,
                                                    to_currency,
                                                    MAX (conversion_date) conversion_date,
                                                    MAX (conversion_rate) conversion_rate,
                                                    MAX (conversion_type) conversion_type,
                                                    MAX (status_code) status_code,
                                                    MAX (last_update_date) last_update_date,
                                                    MAX (last_updated_by) last_updated_by,
                                                    MAX (creation_date) creation_date,
                                                    MAX (created_by) created_by
                                               FROM dbo.gl_daily_rates
                                           GROUP BY from_currency, to_currency) rate
                                  ON (curr.currency_code = rate.from_currency)";

            return db.Read(sql, Make).ToList();
        }

        public GLDailyRateModel GetByFormCurrency(string currCode)
        {
            string sql = @"SELECT curr.currency_code from_currency,
                               rate.to_currency,
                               rate.conversion_date,
                               rate.conversion_rate,
                               rate.conversion_type,
                               rate.status_code,
                               rate.last_update_date,
                               rate.last_updated_by,
                               rate.creation_date,
                               rate.created_by
                          FROM fnd_currencies curr
                               INNER JOIN (  SELECT from_currency,
                                                    to_currency,
                                                    MAX (conversion_date) conversion_date,
                                                    MAX (conversion_rate) conversion_rate,
                                                    MAX (conversion_type) conversion_type,
                                                    MAX (status_code) status_code,
                                                    MAX (last_update_date) last_update_date,
                                                    MAX (last_updated_by) last_updated_by,
                                                    MAX (creation_date) creation_date,
                                                    MAX (created_by) created_by
                                               FROM dbo.gl_daily_rates
                                           GROUP BY from_currency, to_currency) rate
                                  ON (curr.currency_code = rate.from_currency)
                            WHERE curr.currency_code = @currency_code";

            object[] parms = { "@currency_code", currCode };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(GLDailyRateModel model)
        {
            string sql =
                @"INSERT INTO gl_daily_rates
                       (from_currency
                       ,to_currency
                       ,conversion_date
                       ,conversion_type
                       ,conversion_rate
                       ,status_code
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by)
                 VALUES
                       (@from_currency
                       ,@to_currency
                       ,@conversion_date
                       ,@conversion_type
                       ,@conversion_rate
                       ,@status_code
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by)";

            return db.Insert(sql, Take(model));
        }

        //creates a Members object with order statistics based on DataReader              
        private static Func<IDataReader, GLDailyRateModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            //row.ConversionDate = (reader["start_date_active"] != DBNull.Value) ? reader["start_date_active"].AsDateTime() : (DateTime?)null;
            //row.ConversionRate = reader["bom_number"].AsDouble();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, GLDailyRateModel> Make = reader =>
             new GLDailyRateModel
             {
                 RateTransId = reader["rate_trans_id"].AsInt(),
                 FromCurrency = reader["from_currency"].AsString(),
                 ToCurrency = reader["to_currency"].AsString(),
                 ConversionDate = (reader["conversion_date"] != DBNull.Value) ? reader["conversion_date"].AsDateTime() : (DateTime?)null,
                 ConversionRate = reader["conversion_rate"].AsDouble(),
                 ConversionType = reader["conversion_type"].AsString(),
                 StatusCode = reader["status_code"].AsString(),
                 LastUpdateDate = (reader["last_update_date"] != DBNull.Value) ? reader["last_update_date"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = (reader["creation_date"] != DBNull.Value) ? reader["creation_date"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(GLDailyRateModel model)
        {
            return new object[]
            {
                "@rate_trans_id", model.RateTransId,
                "@from_currency", model.FromCurrency,
                "@to_currency", model.ToCurrency,
                "@conversion_date", model.ConversionDate,
                "@conversion_rate", model.ConversionRate,
                "@conversion_type", model.ConversionType,
                "@status_code", model.StatusCode,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
