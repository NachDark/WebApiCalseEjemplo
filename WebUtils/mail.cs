using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace WebUtils
{
    public class mail
    {


        public void send(mailinfo mymail, string mail, string subject, string body, string args = null, Attachment at = null)
        {
            MailAddress to = new MailAddress(mymail.mail);
            MailAddress from = new MailAddress(mail);

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Testing out email sending";
            email.Body = "Hello all the way from the land of C#  https://localhost:7279/Validator?valid=" + args;
            if (at != null)
            {
                email.Attachments.Add(at);
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(mymail.mail, mymail.pass/*"jnnovnnsrettdwws"*/);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {

                smtp.Send(email);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
