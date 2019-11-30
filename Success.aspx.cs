using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Paykun;
using Paykun.Json;
public partial class _Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _reqId = this.Request.Params.Get("payment-id");
        //string controlId = this.FindControl(this.Request.Params.Get("__EVENTTARGET")).ID
        //string _reqId = HttpContext.Request.Query["payment-id"].ToString();
        PaykunPayment _payment = new PaykunPayment("<merchantId>", "<accessToken>", "<encKey>", _isLive: false);  // Change _isLive to false for sandbox mode, While using sandbox mode you will need to provide credintials for sandbox and not of live environment
        TransactionStatusRes transRes = _payment.GetTransactionStatus(_reqId);
        if (transRes.status == true && transRes.data.transaction.status == "Success")
        {
            payment_success_detail.Text = "<table>" +
                    "<thead>" +
                        "<tr>" +
                            "<th>Transaction Id</th>" +
                            "<th>Amount</th>" +
                            "<th>OrderId</th>" +
                            "<th>Customer Name</th>" +
                            "<th>Customer Email</th>" +
                            "<th>Mobile</th>" +
                            "<th>Product Name</th>" +
                         "</tr>" +
                    "</thead>" +
                    "<tbody>" +
                        "<tr>" +
                            "<td>" + transRes.data.transaction.payment_id + "</td>" +
                            "<td>" + transRes.data.transaction.order.gross_amount + "</td>" +
                            "<td>" + transRes.data.transaction.order.order_id + "</td>" +
                            "<td>" + transRes.data.transaction.customer.name + "</td>" +
                            "<td>" + transRes.data.transaction.customer.email_id + "</td>" +
                            "<td>" + transRes.data.transaction.customer.mobile_no + "</td>" +
                            "<td>" + transRes.data.transaction.order.product_name + "</td>" +
                         "</tr>" +
                    "</tbody>" +
            "</table>" +
            "<style>table {font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even) {background-color: #dddddd;}</style>";
        }
        else
        {
            payment_success_detail.Text = "Payment Faield";
        }
    }

}