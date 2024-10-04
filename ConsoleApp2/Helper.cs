using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Helper
    {
        public static bool SendNotification(string to, string title, string message1)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("vishalp951295@gmail.com", "aoll ijcd ityg matl")
            };
            using (var message = new MailMessage("vishalp951295@gmail.com", to)
            {
                Subject = title,
                Body = message1,
                IsBodyHtml = true,
            })
            {
                smtp.Send(message);
            }
            return true;
        }
    }
}
