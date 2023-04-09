using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace app11
{
    internal static class EmailSender
    {
        public static void SendNewPass(string email, string pass)
        {
            MailAddress from = new("forrandom111222@gmail.com","Artem");
            MailAddress to = new(email);

            MailMessage m = new(from, to);
            m.Subject = "New password";
            m.Body = $"New password - {pass}";
            m.IsBodyHtml = true;

            SmtpClient smtp = new ("", "");
            smtp.Credentials = new NetworkCredential("forrandom111222@gmail.com", "uD15hM59X#rR");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
