using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paykun;
using Paykun.Json;

namespace testWebApp.Pages
{
    public class registerModel : PageModel
    {
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void OnPost()
        {
            // Customer details
            string _name = "Testing";
            string _email = "test@gmail.com";
            string _mono = "9999999999";

            // Order details
            string _orderId = (new Random()).Next(111111111, 999999999).ToString();
            string _productName = "Testing product";

            //Amount to be paid
            double _amount = 10.0; 

            //Your return success page url`
            string _successUrl = "https://localhost:5001/success"; //http://www.xyz.com/success

            //Your return failed page url
            string _failureUrl = "https://localhost:5001/success"; //http://www.xyz.com/failed

            //Mandatory
            //_isLive:false false for testing environment and true for live environment
            //Fill all the required detials here
            PaykunPayment _payment = new Paykun.PaykunPayment("<merchantId>", "<AccessToken>", "<EncryptionKey>", _isLive:false); 

            //Mandatory
            _payment.InitOrder(_orderId, _amount, _productName, _successUrl, _failureUrl);

            //Mandatory
            _payment.AddCustomer(_name, _email, _mono);


            //Add here your shipping detail (Optional)
            //If you want to ignore the shipping or billing address, just make all the params an empty string like 
            _payment.AddShippingAddress("", "", "", "", "");
            //_payment.AddShippingAddress("<address>", "<country>", "<state>", "<city>", "<pincode>");

            //Add here your billing detail (Optional)
            //If you want to ignore the shipping or billing address, just make all the params an empty string like 
            _payment.AddBillingAddress("", "", "", "", "");
            //_payment.AddBillingAddress("<address>", "<country>", "<state>", "<city>", "<pincode>");

            //You can set your custom fields here. for ex. you can set order id for which this transaction is initiated
            //You will get the same order id when you will call the method  _payment.GetTransactionStatus(_reqId)
            _payment.setCustomField("123", "", "", "", "");

            /**
             * if you want to render your custom form then use _payment.getRequestData(), this will return you with all the require params for the request.
             * create form from the 'PkCustomForm' object and make it auto submit or as per your requirements
             * */
            //PkCustomForm requestData = _payment.getRequestData();

            /*To render the direct form*/
            string _res = _payment.Submit();
            Message = _res;


            /*
             |-------------------------------------------------------------------------------------------------------------------------------
             |-------------------------------------------------------------------------------------------------------------------------------
             | Add this below code to your success or failure page
             |-------------------------------------------------------------------------------------------------------------------------------
             |-------------------------------------------------------------------------------------------------------------------------------
             */
            //Add this code to your success or failure url page and you will get all the detail about the current transaction
            //You will get transaction Id in the success or failed url provided from your side.
            //Suppose you have provided success url like http://localhost:8080/transaction_success?payment-id=56156-59572-62823-64618
            //Get this transaction Id from the success or failed url and call this below function to get the current transaction detail.
            //PaykunPayment _payment = new Paykun.PaykunPayment("<Merhcant Id>", "<Access Token>", "<API Secret>", false);
            /*string _reqId = "<assign here your payment-id  returned in success or failed url>";
            TransactionStatusRes transRes = _payment.GetTransactionStatus(_reqId);

            if (transRes.status == true)
            { //Request status

                //handle your response here
                if (transRes.data.transaction.status == "Failed")
                {
                    //Failed transaction

                }
                else if (transRes.data.transaction.status == "Initialized")
                { //Initialized transaction

                }
                else if (transRes.data.transaction.status == "Success")
                { //Success transaction

                }
            }
            else {
                //Request error get here your error description
                string error = transRes.errors.errorMessage;
            }
            
            //This code should be added in success or failed page
            */
        }
    }
}