using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;

namespace Eureka.Data.AdoNet.Commons
{
    public class CurrencyDao : ICurrencyDao
    {
        private static Db db = new Db("ms_sql");

        public List<CurrencyModel> GetAll()
        {
            string sql = @"SELECT cur.*
                          FROM fnd_currencies cur
                          WHERE cur.enabled_flag = 'Y'";

            return db.Read(sql, Make).ToList();
        }

        /// <summary>
        /// From another to THB
        /// </summary>
        /// <param name="currCode"></param>
        /// <returns></returns>
        public CurrencyModel GetByFormCurrency(string currCode)
        {
            string sql = @"SELECT cur.*, rate.conversion_date, rate.conversion_rate
                                FROM fnd_currencies cur
                                LEFT JOIN
	                                (select TOP(1)* from gl_daily_rates where from_currency = @currency_code AND to_currency = 'THB' order by conversion_date desc) rate 
	                                ON(cur.currency_code = rate.from_currency)
                                WHERE cur.enabled_flag = 'Y'
                                AND cur.currency_code = @currency_code";

            object[] parms = { "@currency_code", currCode };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        /// <summary>
        /// From THB to another
        /// </summary>
        /// <param name="currCode"></param>
        /// <returns></returns>
        public CurrencyModel GetByToCurrency(string currCode)
        {
            string sql = @"SELECT cur.*, rate.conversion_date, rate.conversion_rate
                                FROM fnd_currencies cur
                                LEFT JOIN
	                                (select TOP(1)* from gl_daily_rates where from_currency = 'THB' AND to_currency = @currency_code order by conversion_date desc) rate 
	                                ON(cur.currency_code = rate.from_currency)
                                WHERE cur.enabled_flag = 'Y'
                                AND cur.currency_code = 'THB'";

            object[] parms = { "@currency_code", currCode };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public int Insert(CurrencyModel model)
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
        private static Func<IDataReader, CurrencyModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.ConversionDate = (reader["conversion_date"] != DBNull.Value) ? reader["conversion_date"].AsDateTime() : (DateTime?)null;
            row.ConversionRate = reader["conversion_rate"].AsDouble();

            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, CurrencyModel> Make = reader =>
             new CurrencyModel
             {
                 CurrencyId = reader["currency_id"].AsInt(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 Description = reader["description"].AsString(),
                 EnableFlag = (reader["enabled_flag"].AsString() == "Y") ? true : false,
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 StartDateActive = (reader["start_date_active"] != DBNull.Value) ? reader["start_date_active"].AsDateTime() : (DateTime?)null,
                 EndDateActive = (reader["end_date_active"] != DBNull.Value) ? reader["end_date_active"].AsDateTime() : (DateTime?)null,
             };

        private object[] Take(CurrencyModel model)
        {
            return new object[]
            {
                "@currency_id", model.CurrencyId,
                "@currency_code", model.CurrencyCode,
                "@description", model.Description,
                "@enabled_flag", (model.EnableFlag) ? "Y" : "N",
                "@start_date_active", model.StartDateActive,
                "@end_date_active", model.EndDateActive,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
