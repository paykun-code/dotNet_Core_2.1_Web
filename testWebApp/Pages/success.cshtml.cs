using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Paykun;
using Paykun.Json;

namespace testWebApp.Pages
{
    public class successModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                string paymentId = HttpContext.Request.Query["payment-id"].ToString();
                PaykunPayment _payment = new Paykun.PaykunPayment("", "", "", _isLive: false);
                TransactionStatusRes response = _payment.GetTransactionStatus(paymentId);
            }
            catch (Exception ex) {
                Console.Out.WriteLine(ex.ToString());
            }

        }
    }
}