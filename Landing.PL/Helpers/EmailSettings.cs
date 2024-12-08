using Landing.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace Landing.PL.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
           var client= new  SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("amrhoji77@gmail.com", "vhht hplm dpam wzqo");
            client.Send("amrhoji77@gmail.com",email.Recivers,email.Subject,email.Body);
        }

    }
}
