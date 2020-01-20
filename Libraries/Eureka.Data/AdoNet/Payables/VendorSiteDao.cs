using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Payables
{
    public class VendorSiteDao : IVendorSiteDao
    {
        private static Db db = new Db("ms_sql");

        public List<VendorSiteModel> GetAll()
        {
            string sql = @"SELECT v.vendor_site_id, v.vendor_id
                            , v.last_update_date, v.last_updated_by
                            , v.creation_date, v.created_by
                            , v.pay_site_flag, v.address_line1
                            , v.address_line2, v.address_line3
                            , v.city, v.state
                            , v.province, v.zip
                            , v.country, v.phone1
                            , v.phone2, v.fax1
                            , v.fax2, v.ship_to_location_id
                            , v.bill_to_location_id, v.vat_code
                            , v.terms_id, v.invoice_currency_code
                            , v.vat_registration_num
                              FROM ap_supplier_sites_all v
                         ORDER BY v.vendor_id ASC";

            return db.Read(sql, Make).ToList();
        }

        public VendorSiteModel GetByID(int id)
        {
            string sql = @"SELECT v.vendor_site_id, v.vendor_id
                            , v.last_update_date, v.last_updated_by
                            , v.creation_date, v.created_by
                            , v.pay_site_flag, v.address_line1
                            , v.address_line2, v.address_line3
                            , v.city, v.state
                            , v.province, v.zip
                            , v.country, v.phone1
                            , v.phone2, v.fax1
                            , v.fax2, v.ship_to_location_id
                            , v.bill_to_location_id, v.vat_code
                            , v.terms_id, v.invoice_currency_code
                            , v.vat_registration_num
                              FROM ap_supplier_sites_all v
                         WHERE v.vendor_site_id = @vendor_site_id";

            object[] parms = { "@vendor_site_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<VendorSiteModel> GetByVendorID(int id)
        {
            string sql = @"SELECT v.vendor_site_id, v.vendor_id
                            , v.last_update_date, v.last_updated_by
                            , v.creation_date, v.created_by
                            , v.pay_site_flag, v.address_line1
                            , v.address_line2, v.address_line3
                            , v.city, v.state
                            , v.province, v.zip
                            , v.country, v.phone1
                            , v.phone2, v.fax1
                            , v.fax2, v.ship_to_location_id
                            , v.bill_to_location_id, v.vat_code
                            , v.terms_id, v.invoice_currency_code
                            , v.vat_registration_num
                              FROM ap_supplier_sites_all v
                         WHERE v.vendor_id = @vendor_id";

            object[] parms = { "@vendor_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<VendorSiteModel> GetByVendorNum(string number)
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
                          FROM ap_suppliers v
                         WHERE v.vendor_number = @vendor_number";

            object[] parms = { "@vendor_number", number };
            return db.Read(sql, Make, parms).ToList();
        }

        public int Insert(VendorSiteModel model)
        {
            string sql =
                @"INSERT INTO ap_supplier_sites_all
                           (vendor_id
                           ,last_update_date
                           ,last_updated_by
                           ,creation_date
                           ,created_by
                           ,pay_site_flag
                           ,address_line1
                           ,address_line2
                           ,address_line3
                           ,city
                           ,state
                           ,province
                           ,zip
                           ,country
                           ,phone1
                           ,phone2
                           ,fax1
                           ,fax2
                           ,ship_to_location_id
                           ,bill_to_location_id
                           ,vat_code
                           ,terms_id
                           ,invoice_currency_code
                           ,vat_registration_num)
                     VALUES
                           (@vendor_id
                           ,@last_update_date
                           ,@last_updated_by
                           ,@creation_date
                           ,@created_by
                           ,@pay_site_flag
                           ,@address_line1
                           ,@address_line2
                           ,@address_line3
                           ,@city
                           ,@state
                           ,@province
                           ,@zip
                           ,@country
                           ,@phone1
                           ,@phone2
                           ,@fax1
                           ,@fax2
                           ,@ship_to_location_id
                           ,@bill_to_location_id
                           ,@vat_code
                           ,@terms_id
                           ,@invoice_currency_code
                           ,@vat_registration_num)";

            return db.Insert(sql, Take(model));
        }

        public void Update(VendorSiteModel model)
        {
            string sql =
            @"UPDATE ap_supplier_sites_all
                   SET vendor_id = @vendor_id
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,pay_site_flag = @pay_site_flag
                      ,address_line1 = @address_line1
                      ,address_line2 = @address_line2
                      ,address_line3 = @address_line3
                      ,city = @city
                      ,state = @state
                      ,province = @province
                      ,zip = @zip
                      ,country = @country
                      ,phone1 = @phone1
                      ,phone2 = @phone2
                      ,fax1 = @fax1
                      ,fax2 = @fax2
                      ,ship_to_location_id = @ship_to_location_id
                      ,bill_to_location_id = @bill_to_location_id
                      ,vat_code = @vat_code
                      ,terms_id = @terms_id
                      ,invoice_currency_code = @invoice_currency_code
                      ,vat_registration_num = @vat_registration_num
                 WHERE vendor_site_id = @vendor_site_id";

            db.Update(sql, Take(model));
        }

        public void Delete(VendorSiteModel model)
        {
            string sql = @"DELETE FROM ap_supplier_sites_all WHERE vendor_site_id = @vendor_site_id";

            object[] parms = { "@vendor_site_id", model.VendorSiteId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, VendorSiteModel> Make = reader =>
             new VendorSiteModel
             {
                 VendorSiteId = reader["vendor_site_id"].AsInt(),
                 VendorId = reader["vendor_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 PaySiteFlag = reader["pay_site_flag"].AsString(),
                 AddressLine1 = reader["address_line1"].AsString(),
                 AddressLine2 = reader["address_line2"].AsString(),
                 AddressLine3 = reader["address_line3"].AsString(),
                 City = reader["city"].AsString(),
                 State = reader["state"].AsString(),
                 Province = reader["province"].AsString(),
                 Zip = reader["zip"].AsString(),
                 Country = reader["country"].AsString(),
                 Phone1 = reader["phone1"].AsString(),
                 Phone2 = reader["phone2"].AsString(),
                 Fax1 = reader["fax1"].AsString(),
                 Fax2 = reader["fax2"].AsString(),
                 ShipToLocationId = reader["ship_to_location_id"].AsInt(),
                 BillToLocationId = reader["bill_to_location_id"].AsInt(),
                 VatCode = reader["vat_code"].AsString(),
                 TermsId = reader["terms_id"].AsInt(),
                 InvoiceCurrencyCode = reader["invoice_currency_code"].AsString(),
                 VatRegistrationNum = reader["vat_registration_num"].AsString()
             };

        private object[] Take(VendorSiteModel model)
        {
            return new object[]
            {
                "@vendor_site_id", model.VendorSiteId,
                "@vendor_id", model.VendorId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@pay_site_flag", model.PaySiteFlag,
                "@address_line1", model.AddressLine1,
                "@address_line2", model.AddressLine2,
                "@address_line3", model.AddressLine3,
                "@city", model.City,
                "@state", model.State,
                "@province", model.Province,
                "@zip", model.Zip,
                "@country", model.Country,
                "@phone1", model.Phone1,
                "@phone2", model.Phone2,
                "@fax1", model.Fax1,
                "@fax2", model.Fax2,
                "@ship_to_location_id", model.ShipToLocationId,
                "@bill_to_location_id", model.BillToLocationId,
                "@vat_code", model.VatCode,
                "@terms_id", model.TermsId,
                "@invoice_currency_code", model.InvoiceCurrencyCode,
                "@vat_registration_num", model.VatRegistrationNum
            };
        }
    }
}
