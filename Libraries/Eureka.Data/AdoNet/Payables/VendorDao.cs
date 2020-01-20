using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Payables
{
    public class VendorDao : IVendorDao
    {
        private static Db db = new Db("ms_sql");

        public List<VendorModel> GetAll()
        {
            string sql = @"SELECT v.vendor_id
                              , v.vendor_name
                              , v.vendor_number
                              , v.enabled_flag
                              , v.last_update_date
                              , v.last_updated_by
                              , v.creation_date
                              , v.created_by
                              , v.vendor_type
                              , v.terms_id
                              , v.invoice_currency_code
                              , v.payment_currency_code
                              , v.vat_code
                              , v.start_data_active
                              , v.end_date_active
                              , v.vat_registration_num
                              , v.term_code
                          FROM ap_suppliers v
                         ORDER BY v.vendor_name ASC";

            return db.Read(sql, Make).ToList();
        }

        public VendorModel GetByID(int id)
        {
            string sql = @"SELECT v.vendor_id
                              , v.vendor_name
                              , v.vendor_number
                              , v.enabled_flag
                              , v.last_update_date
                              , v.last_updated_by
                              , v.creation_date
                              , v.created_by
                              , v.vendor_type
                              , v.terms_id
                              , v.invoice_currency_code
                              , v.payment_currency_code
                              , v.vat_code
                              , v.start_data_active
                              , v.end_date_active
                              , v.vat_registration_num
                              , v.term_code
                          FROM ap_suppliers v
                         WHERE v.vendor_id = @vendor_id";

            object[] parms = { "@vendor_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public VendorModel GetByNum(string number)
        {
            string sql = @"SELECT v.vendor_id
                              , v.vendor_name
                              , v.vendor_number
                              , v.enabled_flag
                              , v.last_update_date
                              , v.last_updated_by
                              , v.creation_date
                              , v.created_by
                              , v.vendor_type
                              , v.terms_id
                              , v.invoice_currency_code
                              , v.payment_currency_code
                              , v.vat_code
                              , v.start_data_active
                              , v.end_date_active
                              , v.vat_registration_num
                              , v.term_code
                          FROM ap_suppliers v
                         WHERE v.vendor_number = @vendor_number";

            object[] parms = { "@vendor_number", number };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(VendorModel model)
        {
            string sql =
                @"INSERT INTO ap_suppliers
                       (vendor_name
                       ,vendor_number
                       ,enabled_flag
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by
                       ,vendor_type
                       ,terms_id
                       ,invoice_currency_code
                       ,payment_currency_code
                       ,vat_code
                       ,start_data_active
                       ,end_date_active
                       ,vat_registration_num
                       ,v.term_code)
                 VALUES
                       (@vendor_name
                       ,@vendor_number
                       ,@enabled_flag
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by
                       ,@vendor_type
                       ,@terms_id
                       ,@invoice_currency_code
                       ,@payment_currency_code
                       ,@vat_code
                       ,@start_data_active
                       ,@end_date_active
                       ,@vat_registration_num
                       ,@term_code)";

            return db.Insert(sql, Take(model));
        }

        public void Update(VendorModel model)
        {
            string sql =
            @"UPDATE ap_suppliers
               SET vendor_name = @vendor_name
                  ,vendor_number = @vendor_number
                  ,enabled_flag = @enabled_flag
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,vendor_type = @vendor_type
                  ,terms_id = @terms_id
                  ,invoice_currency_code = @invoice_currency_code
                  ,payment_currency_code = @payment_currency_code
                  ,vat_code = @vat_code
                  ,start_data_active = @start_data_active
                  ,end_date_active = @end_date_active
                  ,vat_registration_num = @vat_registration_num
                  ,term_code = @term_code
             WHERE vendor_id = @vendor_id";

            db.Update(sql, Take(model));
        }

        public void Delete(VendorModel model)
        {
            string sql = @"DELETE FROM ap_suppliers WHERE vendor_id = @vendor_id";

            object[] parms = { "@vendor_id", model.VendorId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, VendorModel> Make = reader =>
             new VendorModel
             {
                 VendorId = reader["vendor_id"].AsInt(),
                 VendorName = reader["vendor_name"].AsString(),
                 VendorNumber = reader["vendor_number"].AsString(),
                 EnabledFlag = reader["enabled_flag"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 VendorType = reader["vendor_type"].AsString(),
                 TermsId = reader["terms_id"].AsInt(),
                 InvoiceCurrencyCode = reader["invoice_currency_code"].AsString(),
                 PaymentCurrencyCode = reader["payment_currency_code"].AsString(),
                 VatCode = reader["vat_code"].AsString(),
                 StartDataActive = reader["start_data_active"].AsDateTime(),
                 EndDateActive = reader["end_date_active"].AsDateTime(),
                 VatRegistrationNum = reader["vat_registration_num"].AsString(),
                 TermCode = reader["term_code"].AsString()
             };

        private object[] Take(VendorModel model)
        {
            return new object[]
            {
                "@vendor_id", model.VendorId,
                "@vendor_name", model.VendorName,
                "@vendor_number", model.VendorNumber,
                "@enabled_flag", model.EnabledFlag,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@vendor_type", model.VendorType,
                "@terms_id", model.TermsId,
                "@invoice_currency_code", model.InvoiceCurrencyCode,
                "@payment_currency_code", model.PaymentCurrencyCode,
                "@vat_code", model.VatCode,
                "@start_data_active", model.StartDataActive,
                "@end_date_active", model.EndDateActive,
                "@vat_registration_num", model.VatRegistrationNum,
                "@term_code", model.TermCode
            };
        }
    }
}
