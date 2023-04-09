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
            MailAddress from = new("laba11forkitkai@mail.ru\r\n", "Artem");
            MailAddress to = new(email);

            MailMessage m = new(from, to);
            m.Subject = "New password";
            m.Body = $"New password - {pass}";

            using (SmtpClient smtp = new("smtp.mail.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("laba11forkitkai@mail.ru\r\n", "Qv7Kezvkps1yLJ8g0faw");
                smtp.EnableSsl = true; 
                smtp.Send(m);
            }
        }
    }
}
