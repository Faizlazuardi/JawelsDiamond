using JawelsDiamond.Controller;
using JawelsDiamond.Controllers;
using JawelsDiamond.DataSets;
using JawelsDiamond.Models;
using JawelsDiamond.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JawelsDiamond.Views
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 crystalReport1 = new CrystalReport1();
            CrystalReportViewer1.ReportSource = crystalReport1;
            DataSet1 ds = GetTransactionData(TransactionController.GetAllTransactions());
            crystalReport1.SetDataSource(ds);
        }
        private DataSet1 GetTransactionData(List<TransactionHeader> transactionHeaders)
        {
            DataSet1 ds = new DataSet1();
            var header = ds.TransactionHeaderReport;
            var detail = ds.TransactionDetailReport;
            
            foreach(TransactionHeader t in transactionHeaders)
            {
                var row = header.NewTransactionHeaderReportRow();
                row["TransactionID"] = t.TransactionID;
                row["TransactionDate"] = t.TransactionDate;
                row["Username"] = t.MsUser.UserName;
                
                header.Rows.Add(row);
                foreach(TransactionDetail d in t.TransactionDetails)
                {
                    var det = detail.NewTransactionDetailReportRow();
                    det["TransactionID"] = t.TransactionID;
                    det["ProductName"] = d.MsJewel.JewelName;
                    det["BrandName"] = d.MsJewel.MsBrand.BrandName;
                    det["CategoryName"] = d.MsJewel.MsCategory.CategoryName;
                    det["Quantity"] = d.Quantity;
                    det["Price"] = d.MsJewel.JewelPrice;
                    det["SubTotal"] = d.MsJewel.JewelPrice * d.Quantity;

                    detail.Rows.Add(det);
                }
            }
            
            return ds;
        }
    }
}