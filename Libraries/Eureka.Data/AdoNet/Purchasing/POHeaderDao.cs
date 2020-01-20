using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POHeaderDao : IPOHeaderDao
    {
        private static Db db = new Db("ms_sql");

        public List<POHeaderModel> GetAll()
        {
            string sql = @"SELECT po.po_header_id, po.po_num, po.po_date
                                , po.type_lookup_code, po.last_update_date, po.last_updated_by
                                , po.creation_date, po.created_by, po.vendor_id
                                , po.vendor_site_id, po.vendor_num, po.ship_to_location_id
                                , po.bill_to_location_id, po.term_id, po.term_code
                                , po.currency_code, po.rate_type, po.rate_date
                                , po.rate, po.authorization_status, po.revision_num
                                , po.revised_date, po.approved_flag, po.approved_date
                                , po.remarks, po.closed_date, po.approval_required_flag
                                , po.cancel_flag, po.status_code, po.tax_code
                                , po.tax_rate, po.sub_total, po.tax_amount
                                , po.discount, po.freight, po.total_amount, po.status
                                , po.received_flag, po.buyer_id, po.submit_flag, po.job_flag
                                , po.revision_notes, po.approver_id
                            FROM po_headers_all po
                            WHERE po.enable_flag = @enable_flag
                            ORDER BY po.po_date DESC";

            object[] parms = { "@enable_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public POHeaderModel GetByID(int id)
        {
            string sql = @"SELECT po.po_header_id, po.po_num, po.po_date
                                , po.type_lookup_code, po.last_update_date, po.last_updated_by
                                , po.creation_date, po.created_by, po.vendor_id
                                , po.vendor_site_id, ven.vendor_number vendor_num, po.ship_to_location_id
                                , po.bill_to_location_id, po.term_id, tem.term_code
                                , po.currency_code, po.rate_type, po.rate_date
                                , po.rate, po.authorization_status, po.revision_num
                                , po.revised_date, po.approved_flag, po.approved_date
                                , po.remarks, po.closed_date, po.approval_required_flag
                                , po.cancel_flag, po.status_code, po.tax_code
                                , po.tax_rate, po.sub_total, po.tax_amount
                                , po.discount, po.freight, po.total_amount, po.status
                                , po.received_flag, po.buyer_id, po.submit_flag
								, ven.vendor_name, tem.description, usr.USER_NAME, po.job_flag
                                , po.revision_notes, po.approver_id, apv.user_name approver_name
                            FROM po_headers_all po
							LEFT JOIN ap_suppliers ven ON(po.vendor_id = ven.vendor_id)
							LEFT JOIN ap_terms tem ON(po.term_id = tem.term_id)
							LEFT JOIN fnd_users usr ON(po.buyer_id = usr.USER_ID)
                            LEFT JOIN fnd_users apv ON(po.approver_id = apv.USER_ID)
                         WHERE po.po_header_id = @po_header_id
                            AND po.enable_flag = @enable_flag";

            object[] parms = { "@po_header_id", id, "@enable_flag", "Y" };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<POHeaderModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT po.po_header_id, po.po_num, po.po_date
                                , po.type_lookup_code, po.last_update_date, po.last_updated_by
                                , po.creation_date, po.created_by, po.vendor_id
                                , po.vendor_site_id, ven.vendor_number vendor_num, po.ship_to_location_id
                                , po.bill_to_location_id, po.term_id, tem.term_code
                                , po.currency_code, po.rate_type, po.rate_date
                                , po.rate, po.authorization_status, po.revision_num
                                , po.revised_date, po.approved_flag, po.approved_date
                                , po.remarks, po.closed_date, po.approval_required_flag
                                , po.cancel_flag, po.status_code, po.tax_code
                                , po.tax_rate, po.sub_total, po.tax_amount
                                , po.discount, po.freight, po.total_amount, po.status
                                , po.received_flag, po.buyer_id, po.submit_flag
								, ven.vendor_name, tem.description, usr.USER_NAME, po.job_flag
                                , po.revision_notes, po.approver_id, apv.user_name approver_name
                            FROM po_headers_all po
							    LEFT JOIN ap_suppliers ven ON(po.vendor_id = ven.vendor_id)
							    LEFT JOIN ap_terms tem ON(po.term_id = tem.term_id)
							    LEFT JOIN fnd_users usr ON(po.buyer_id = usr.USER_ID)
                                LEFT JOIN fnd_users apv ON(po.approver_id = apv.USER_ID)
                            WHERE cast(po.po_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY po.po_date ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public POHeaderModel GetByPONum(string number)
        {
            string sql = @"SELECT po.po_header_id, po.po_num, po.po_date
                                , po.type_lookup_code, po.last_update_date, po.last_updated_by
                                , po.creation_date, po.created_by, po.vendor_id
                                , po.vendor_site_id, ven.vendor_number vendor_num, po.ship_to_location_id
                                , po.bill_to_location_id, po.term_id, tem.term_code
                                , po.currency_code, po.rate_type, po.rate_date
                                , po.rate, po.authorization_status, po.revision_num
                                , po.revised_date, po.approved_flag, po.approved_date
                                , po.remarks, po.closed_date, po.approval_required_flag
                                , po.cancel_flag, po.status_code, po.tax_code
                                , po.tax_rate, po.sub_total, po.tax_amount
                                , po.discount, po.freight, po.total_amount, po.status
                                , po.received_flag, po.buyer_id, po.submit_flag
								, ven.vendor_name, tem.description, usr.USER_NAME, po.job_flag
                                , po.revision_notes, po.approver_id, apv.USER_NAME approver_name
                            FROM po_headers_all po
							    LEFT JOIN ap_suppliers ven ON(po.vendor_id = ven.vendor_id)
							    LEFT JOIN ap_terms tem ON(po.term_id = tem.term_id)
							    LEFT JOIN fnd_users usr ON(po.buyer_id = usr.USER_ID)
                                LEFT JOIN fnd_users apv ON(po.approver_id = apv.USER_ID)
                            WHERE po.po_num = @po_num";

            object[] parms = { "@po_num", number };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public int Insert(POHeaderModel model)
        {
            string sql =
                @"INSERT INTO po_headers_all
                       (po_num
                       ,po_date
                       ,type_lookup_code
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by
                       ,vendor_id
                       ,vendor_site_id
                       ,vendor_num
                       ,ship_to_location_id
                       ,bill_to_location_id
                       ,term_id
                       ,term_code
                       ,currency_code
                       ,rate_type
                       ,rate_date
                       ,rate
                       ,authorization_status
                       ,revision_num
                       ,revised_date
                       ,approved_flag
                       ,approved_date
                       ,remarks
                       ,closed_date
                       ,approval_required_flag
                       ,cancel_flag
                       ,status_code
                       ,tax_code
                       ,tax_rate
                       ,sub_total
                       ,tax_amount
                       ,discount
                       ,freight
                       ,total_amount
                       ,status
                       ,received_flag
                       ,buyer_id
                       ,submit_flag
                       ,job_flag
                       ,revision_notes
                       ,approver_id)
                 VALUES
                       (@po_num
                       ,@po_date
                       ,@type_lookup_code
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by
                       ,@vendor_id
                       ,@vendor_site_id
                       ,@vendor_num
                       ,@ship_to_location_id
                       ,@bill_to_location_id
                       ,@term_id
                       ,@term_code
                       ,@currency_code
                       ,@rate_type
                       ,@rate_date
                       ,@rate
                       ,@authorization_status
                       ,@revision_num
                       ,@revised_date
                       ,@approved_flag
                       ,@approved_date
                       ,@remarks
                       ,@closed_date
                       ,@approval_required_flag
                       ,@cancel_flag
                       ,@status_code
                       ,@tax_code
                       ,@tax_rate
                       ,@sub_total
                       ,@tax_amount
                       ,@discount
                       ,@freight
                       ,@total_amount
                       ,@status
                       ,@received_flag
                       ,@buyer_id
                       ,@submit_flag
                       ,@job_flag
                       ,@revision_notes
                       ,@approver_id)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POHeaderModel model)
        {
            string sql =
            @"UPDATE po_headers_all
                   SET po_num = @po_num
                      ,po_date = @po_date
                      ,type_lookup_code = @type_lookup_code
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,vendor_id = @vendor_id
                      ,vendor_site_id = @vendor_site_id
                      ,vendor_num = @vendor_num
                      ,ship_to_location_id = @ship_to_location_id
                      ,bill_to_location_id = @bill_to_location_id
                      ,term_id = @term_id
                      ,term_code = @term_code
                      ,currency_code = @currency_code
                      ,rate_type = @rate_type
                      ,rate_date = @rate_date
                      ,rate = @rate
                      ,authorization_status = @authorization_status
                      ,revision_num = @revision_num
                      ,revised_date = @revised_date
                      ,approved_flag = @approved_flag
                      ,approved_date = @approved_date
                      ,remarks = @remarks
                      ,closed_date = @closed_date
                      ,approval_required_flag = @approval_required_flag
                      ,cancel_flag = @cancel_flag
                      ,status_code = @status_code
                      ,tax_code = @tax_code
                      ,tax_rate = @tax_rate
                      ,sub_total = @sub_total
                      ,tax_amount = @tax_amount
                      ,discount = @discount
                      ,freight = @freight
                      ,total_amount = @total_amount
                      ,status = @status
                      ,submit_flag = @submit_flag
                      ,job_flag = @job_flag
                      ,received_flag = @received_flag
                      ,revision_notes = @revision_notes
                      ,approver_id = @approver_id
                 WHERE po_header_id = @po_header_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POHeaderModel model)
        {
            string sql = @"DELETE FROM po_headers_all WHERE po_header_id = @po_header_id";

            object[] parms = { "@po_header_id", model.PoHeaderId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, POHeaderModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.VendorName = reader["vendor_name"].AsString();
            row.TermDesc = reader["description"].AsString();
            row.BuyerName = reader["USER_NAME"].AsString();
            row.ApproverName = reader["approver_name"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, POHeaderModel> Make = reader =>
             new POHeaderModel
             {
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoNum = reader["po_num"].AsString(),
                 PODate = reader["po_date"].AsDateTime(),
                 TypeLookupCode = reader["type_lookup_code"].AsString(),
                 VendorId = reader["vendor_id"].AsInt(),
                 VendorSiteId = reader["vendor_site_id"].AsInt(),
                 VendorNum = reader["vendor_num"].AsString(),
                 ShipToLocationId = reader["ship_to_location_id"].AsInt(),
                 BillToLocationId = reader["bill_to_location_id"].AsInt(),
                 TermId = reader["term_id"].AsInt(),
                 TermCode = reader["term_code"].AsString(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 RateType = reader["rate_type"].AsString(),
                 //RateDate = reader["rate_date"].AsDateTime(),
                 RateDate = (reader["rate_date"] != DBNull.Value) ? reader["rate_date"].AsDateTime() : (DateTime?)null,
                 Rate = reader["rate"].AsDouble(),
                 AuthorizationStatus = reader["authorization_status"].AsString(),
                 RevisionNum = reader["revision_num"].AsInt(),
                 //RevisedDate = reader["revised_date"].AsDateTime(),
                 RevisedDate = (reader["revised_date"] != DBNull.Value) ? reader["revised_date"].AsDateTime() : (DateTime?)null,
                 ApprovedFlag = (reader["approved_flag"].AsString() == "Y") ? true : false,
                 //ApprovedDate = reader["approved_date"].AsDateTime(),
                 ApprovedDate = (reader["approved_date"] != DBNull.Value) ? reader["approved_date"].AsDateTime() : (DateTime?)null,
                 Remarks = reader["remarks"].AsString(),
                 //ClosedDate = reader["closed_date"].AsDateTime(),
                 ClosedDate = (reader["closed_date"] != DBNull.Value) ? reader["closed_date"].AsDateTime() : (DateTime?)null,
                 ApprovalRequiredFlag = reader["approval_required_flag"].AsString(),
                 CancelFlag = (reader["cancel_flag"].AsString() == "Y") ? true : false,
                 StatusCode = reader["status_code"].AsString(),
                 TaxCode = reader["tax_code"].AsString(),
                 TaxRate = reader["tax_rate"].AsDouble(),
                 SubTotal = reader["sub_total"].AsDouble(),
                 //TaxAmount = reader["tax_amount"].AsDouble(),
                 Discount = reader["discount"].AsDouble(),
                 Freight = reader["freight"].AsDouble(),
                 //TotalAmount = reader["total_amount"].AsDouble(),
                 Status = reader["status"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ReceivedFlag = (reader["received_flag"].AsString() == "Y") ? true : false,
                 BuyerId = reader["buyer_id"].AsInt(),
                 SubmitFlag = (reader["submit_flag"].AsString() == "Y") ? true : false,
                 JobFlag = (reader["job_flag"].AsString() == "Y") ? true : false,
                 RevisionNote = reader["revision_notes"].AsString(),
                 ApproverId = reader["approver_id"].AsInt()
             };

        private object[] Take(POHeaderModel model)
        {
            return new object[]
            {
                "@po_header_id", model.PoHeaderId,
                "@po_num", model.PoNum,
                "@po_date", model.PODate,
                "@type_lookup_code", model.TypeLookupCode,
                "@vendor_id", model.VendorId,
                "@vendor_site_id", model.VendorSiteId,
                "@vendor_num", model.VendorNum,
                "@ship_to_location_id", model.ShipToLocationId,
                "@bill_to_location_id", model.BillToLocationId,
                "@term_id", model.TermId,
                "@term_code", model.TermCode,
                "@currency_code", model.CurrencyCode,
                "@rate_type", model.RateType,
                "@rate_date", model.RateDate,
                "@rate", model.Rate,
                "@authorization_status", model.AuthorizationStatus,
                "@revision_num", model.RevisionNum,
                "@revised_date", model.RevisedDate,
                "@approved_flag", (model.ApprovedFlag) ? "Y" : "N",
                "@approved_date", model.ApprovedDate,
                "@remarks", model.Remarks,
                "@closed_date", model.ClosedDate,
                "@approval_required_flag", model.ApprovalRequiredFlag,
                "@cancel_flag", (model.CancelFlag) ? "Y" : "N",
                "@status_code", model.StatusCode,
                "@tax_code", model.TaxCode,
                "@tax_rate", model.TaxRate,
                "@sub_total", model.SubTotal,
                "@tax_amount", model.TaxAmount,
                "@discount", model.Discount,
                "@freight", model.Freight,
                "@total_amount", model.TotalAmount,
                "@status", model.Status,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@received_flag", (model.ReceivedFlag) ? "Y" : "N",
                "@buyer_id", model.BuyerId,
                "@submit_flag", (model.SubmitFlag) ? "Y" : "N",
                "@job_flag", (model.JobFlag) ? "Y" : "N",
                "@revision_notes", model.RevisionNote,
                "@approver_id", model.ApproverId
            };
        }

        public List<POReportModel> GetPOReportByID(int id)
        {
            string sql = @"SELECT
                                'Eureka Automation Co.,Ltd. (Head Office)' CompanyNameEN, 'บริษัท ยูเรกา ออโตเมชั่น จำกัด (สำนักงานใหญ่)' CompanyNameTH
	                            , '19 Moo 11 Ladsawai Lamlukka Pathumthani 12150, (THAILAND)' CompanyAddrEN, 'ที่อยู่ 19 ม.11 ต.ลาดสวาย อ.ลำลูกกา จ.ปทุมธานี 12150 (ประเทศไทย)' CompanyAddrTH
	                            , 'Tel. 02-1923737 Fax.02-1923744' CompanyTelEN, 'โทร. 02-1923737 แฟกซ์ 02-1923744' CompanyTelTH
	                            , '0135557021131' CompanyTaxIDEN, 'เลขประจำตัวผู้เสียภาษี 0135557021131' CompanyTaxIDTH
	                            , po.po_header_id, po.po_num, po.po_date, po.vendor_id
	                            , po.vendor_site_id, ven.vendor_number as vendor_num, po.term_id, po.term_code, trm.description term
                                , po.currency_code, po.remarks, po.cancel_flag, po.status_code
	                            , po.tax_code, po.tax_rate, po.tax_amount, po.freight
                                ,(select SUM(extended_amount) from po_lines_all where po_header_id = po.po_header_id and cancel_flag = 'N') sub_total
                                , po.total_amount,po.received_flag, po.buyer_id, po.submit_flag
	                            , ven.vendor_name
                                , (isnull(sev.address_line1, '')+' '+ isnull(sev.address_line2, '')+' '+ isnull(sev.address_line3, '')) vendor_address
	                            , (' Tel. '+isnull(sev.phone1,'')+ ' Fax. '+ isnull(sev.fax1,'')) vendor_telfax, sev.contact_name
	                            , usr.DESCRIPTION buyer_name, sev.vat_registration_num, '' BarCode
	                            , pol.po_line_num, pol.item_code, pol.ref_project_num, pol.item_description
	                            , pol.spec_model, pol.brand_materail, pol.due_date, pol.quantity, isnull(pol.uom,'PCS') uom
	                            , pol.unit_price, pol.extended_amount, pol.bom, po.remarks, po.revision_notes
                                , usr.signature buyer_signature, apv.signature approver_signature, po.buyer_id, po.approver_id
                                , apv.user_name approver_name, po.discount
                            FROM po_headers_all po
                            LEFT JOIN ap_suppliers ven ON(po.vendor_id = ven.vendor_id)
                            LEFT JOIN fnd_users usr ON(po.buyer_id = usr.USER_ID)
                            LEFT JOIN fnd_users apv ON(po.approver_id = apv.user_id)
                            LEFT JOIN ap_supplier_sites_all sev ON(ven.vendor_id = sev.vendor_id)
                            LEFT JOIN po_lines_all pol ON(po.po_header_id = pol.po_header_id AND pol.cancel_flag = 'N')
                            LEFT JOIN ap_terms trm ON(po.term_id = trm.term_id)
                            WHERE po.po_header_id = @po_header_id
                            ORDER BY pol.po_line_num ASC";

            object[] parms = { "@po_header_id", id };
            return db.Read(sql, MakeReport, parms).ToList();
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, POReportModel> MakeReport = reader =>
             new POReportModel
             {
                 CompanyNameEN = reader["CompanyNameEN"].AsString(),
                 CompanyNameTH = reader["CompanyNameTH"].AsString(),
                 CompanyAddrEN = reader["CompanyAddrEN"].AsString(),
                 CompanyAddrTH = reader["CompanyAddrTH"].AsString(),
                 CompanyTelEN = reader["CompanyTelEN"].AsString(),
                 CompanyTelTH = reader["CompanyTelTH"].AsString(),
                 CompanyTaxIDEN = reader["CompanyTaxIDEN"].AsString(),
                 CompanyTaxIDTH = reader["CompanyTaxIDTH"].AsString(),
                 POHeaderId = reader["po_header_id"].AsInt(),
                 PONum = reader["po_num"].AsString(),
                 PODate = reader["po_date"].AsDateTime(),
                 Term = reader["term"].AsString(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 Buyer = reader["buyer_name"].AsString(),
                 VendorName = reader["vendor_name"].AsString(),
                 VendorCode = reader["vendor_num"].AsString(),
                 VendorAddress = reader["vendor_address"].AsString(),
                 VendorTel = reader["vendor_telfax"].AsString(),
                 VendorTaxID = reader["vat_registration_num"].AsString(),
                 VendorContactName = reader["contact_name"].AsString(),
                 SubTotal = reader["sub_total"].AsDouble(),
                 Discount = reader["discount"].AsDouble(),
                 Freight = reader["freight"].AsDouble(),
                 TaxRate = reader["tax_rate"].AsDouble(),
                 //TaxAmount = reader["tax_amount"].AsDouble(),
                 //TotalAmount = reader["total_amount"].AsDouble(),
                 LineNo = reader["po_line_num"].AsInt(),
                 ItemCode = reader["item_code"].AsString(),
                 ProjectNum = reader["ref_project_num"].AsString(),
                 ItemDescription = reader["item_description"].AsString(),
                 BarCode = reader["BarCode"].AsString(),
                 SpecDescription = reader["spec_model"].AsString(),
                 BrandDescription = reader["brand_materail"].AsString(),
                 DueDate = reader["due_date"].AsDateTime(),
                 Quantity = reader["quantity"].AsDouble(),
                 UOM = reader["uom"].AsString(),
                 UnitPrice = reader["unit_price"].AsDouble(),
                 Amount = reader["extended_amount"].AsDouble(),
                 BomNo = reader["bom"].AsString(),
                 Notes = reader["remarks"].AsString(),
                 RevisionNote = reader["revision_notes"].AsString(),
                 BuyerId = reader["buyer_id"].AsInt(),
                 BuyerSignature = reader["buyer_signature"].AsString(),
                 ApproverId = reader["approver_id"].AsInt(),
                 ApproverSignature = reader["approver_signature"].AsString()
             };
    }
}
