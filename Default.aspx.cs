using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Paykun;
public partial class _Default : System.Web.UI.Page
{
    public string Message { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ProcessPayment_Click(object sender, EventArgs e)
    {
        //Response.Write(name.Text);
        string _orderId = "ORD" + (new Random()).Next(111111111, 999999999).ToString();
        //Your return success page url
        string _successUrl = "http://localhost:61002/Success.aspx";
                                                                
        string _failureUrl = "http://localhost:61002/Failed.aspx";

        // Change _isLive to false for sandbox mode, While using sandbox mode you will need to provide credintials for sandbox and not of live environment
        PaykunPayment _payment = new PaykunPayment("<merchantId>", "<accessToken>", "<encKey>", _isLive: false); 

        //Mandatory
        _payment.InitOrder(_orderId, Double.Parse(amount.Text) , product_name.Text, _successUrl, _failureUrl);

        //Mandatory
        _payment.AddCustomer(name.Text, email.Text, contact.Text);

        //Add here your shipping detail (Optional)
        //If you want to ignore the shipping or billing address, just make all the params an empty string like 
        _payment.AddShippingAddress("", "", "", "", "");
        //_payment.AddShippingAddress("address", "country", "state", "city", "pincode");

        //Add here your billing detail (Optional)
        //If you want to ignore the shipping or billing address, just make all the params an empty string like 
        _payment.AddBillingAddress("", "", "", "", "");
        //_payment.AddBillingAddress("address", "country", "state", "city", "pincode");

        //You can set your custom fields here. for ex. you can set order id for which this transaction is initiated
        //You will get the same order id when you will call the method  _payment.GetTransactionStatus(_reqId)
        _payment.SetCustomField(_orderId, "", "", "", "");

        Message = _payment.Submit();
        //Response.Write(Message);
        PaymentinnerForm.Text = Message;

    }
}