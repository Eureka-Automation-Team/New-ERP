using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POReportModel
    {
        public string CompanyNameEN { get; set; }
        public string CompanyNameTH { get; set; }
        public string CompanyAddrEN { get; set; }
        public string CompanyAddrTH { get; set; }
        public string CompanyTelEN { get; set; }
        public string CompanyTelTH { get; set; }
        public string CompanyTaxIDEN { get; set; }
        public string CompanyTaxIDTH { get; set; }
        public int POHeaderId { get; set; }
        public string PONum { get; set; }
        public DateTime PODate { get; set; }
        public string Term { get; set; }
        public string CurrencyCode { get; set; }
        public string Buyer { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public string VendorAddress { get; set; }
        public string VendorTel { get; set; }
        public string VendorTaxID { get; set; }
        public string VendorContactName { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double SebTotalAfterDiscount
        {
            get { return (SubTotal - Discount); }
        }
        public double TaxRate { get; set; }
        public double TaxAmount
        {
            get { return ((SebTotalAfterDiscount) * TaxRate) / 100; }
        }
        public double Freight { get; set; }
        public double TotalAmount
        {
            get { return SebTotalAfterDiscount + TaxAmount + Freight; }
        }
        public int LineNo { get; set; }
        public string ItemCode { get; set; }
        public string ProjectNum { get; set; }
        public string ItemDescription { get; set; }
        public string BarCode { get; set; }
        public string SpecDescription { get; set; }
        public string BrandDescription { get; set; }
        public DateTime DueDate { get; set; }
        public double Quantity { get; set; }
        public string UOM { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public string BomNo { get; set; }
        public string Notes { get; set; }
        public string RevisionNote { get; set; }
        public int BuyerId { get; set; }
        public string BuyerSignature { get; set; }
        public int ApproverId { get; set; }
        public string ApproverSignature { get; set; }
    }
}
