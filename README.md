# dotNet_Core_2.1_Web
.Net core 2.1 for web
# <h3>How To Generate Access token and API Secret :</h3>
You can find your Merchant Id in Paykun Dashboard.

You can generate Or Regenerate Access token and API Secret from login into your paykun admin panel, Then Go To : Settings -> Security -> API Keys. There you will find the generate button if you have not generated api key before.

If you have generated api key before then you will see the date of the api key generate, since you will not be able to retrieve the old api key (For security reasons) we have provided the re-generate option, so you can re-generate api key in case you have lost the old one.

Note : Once you re-generate api key your old api key will stop working immediately. So be cautious while using this option.

# <h3>Prerequisite</h3>
    Merchant Id (Please read 'How To Generate Access token and API Secret :')
    Access Token (Please read 'How To Generate Access token and API Secret :')
    Encryption Key (Please read 'How To Generate Access token and API Secret :')

# <h3>Installation</h3>
Note: Please backup your running source code first.
   1. Download the 'Paykun.dll' file from github.
   2. Add this dll file as a reference in your project
   3. Import this two name spaces 
        1) using Paykun;
        2) using Paykun.Json;
   4. Add 'Newtonsoft.Json' NuGet to your project    
   5. Implementation
        
      ```php
      // Customer details
      string _name = "<Customer Name>";
      string _email = "<Customer Email>";
      string _mono = "<Customer Mobile Number>";

       // Order details
       string _orderId = "ORD" + (new Random()).Next(111111111, 999999999).ToString(); // Order ID must be between 10 To 30 Characters and unique for all transactions
       string _productName = "<Name of the product>";

       //Amount to be paid
       double _amount = 10.0; 

       //Your return success page url
       string _successUrl = "<Success page url>"; //http://www.xyz.com/success

       //Your return failed page url
       string _failureUrl = "<Failure Url>"; //http://www.xyz.com/failed

       //Mandatory
       PaykunPayment _payment = new Paykun.PaykunPayment("<Merhcant Id>", "<Access Token>", "<API Secret>", _isLive: true); // Change _isLive to false for sandbox mode, While using sandbox mode you will need to provide credintials for sandbox and not of live environment

       //Mandatory
       _payment.InitOrder(_orderId, _amount, _productName, _successUrl, _failureUrl);

       //Mandatory
       _payment.AddCustomer(_name, _email, _mono);


       //Add here your shipping detail (Optional)
       //If you want to ignore the shipping or billing address, just make all the params an empty string like 
       //_payment.AddShippingAddress("", "", "", "", "");
       _payment.AddShippingAddress("<address>", "<country>", "<state>", "<city>", "<pincode>");

       //Add here your billing detail (Optional)
       //If you want to ignore the shipping or billing address, just make all the params an empty string like 
       //_payment.AddBillingAddress("", "", "", "", "");
       _payment.AddBillingAddress("<address>", "<country>", "<state>", "<city>", "<pincode>");

       //You can set your custom fields here. for ex. you can set order id for which this transaction is initiated
       //You will get the same order id when you will call the method  _payment.GetTransactionStatus(_reqId)
       _payment.SetCustomField(_orderId, "", "", "", "");

       /**
        * if you want to render your custom form then use _payment.getRequestData(), this will return you with all the require params for the request.
        * create form from the 'PkCustomForm' object and make it auto submit or as per your requirements
        * */
       //PkCustomForm requestData = _payment.getRequestData();

       /*To render the direct form*/
       string _res = _payment.Submit();
       //_res => use this html to render default payment form. if you want custom form then
       // uncomment this line of code and comment out submit method
       //PkCustomForm requestData = _payment.getRequestData(); ==> For custom form    
       //Message = _res;
       
        ```
       
       
       
   Success/Failure page implementation
   ```php         
           //Add this code to your success or failure url page and you will get all the detail about the current transaction
           //You will get transaction Id in the success or failed url provided from your side.
           //Suppose you have provided success url like http://localhost:8080/transaction_success?payment-id=56156-59572-62823-64618
           //Get this transaction Id from the success or failed url and call this below function to get the current transaction detail.
    
           string _reqId = "<assign here your payment-id  returned in success or failed url>";
           PaykunPayment _payment = new Paykun.PaykunPayment("<Merhcant Id>", "<Access Token>", "<API Secret>");
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
   ```           
#<h3> In case of any query, please contact to support@paykun.com.</h3>