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
                PaykunPayment _payment = new Paykun.PaykunPayment("907827924705710", "9ADEC6FF0C1804049C84F02B0871B3AC", "CA4CF211861A319F3A993FE8A672CC72", _isLive: false);
                TransactionStatusRes response = _payment.GetTransactionStatus(paymentId);
            }
            catch (Exception ex) {
                Console.Out.WriteLine(ex.ToString());
            }

        }
    }
}