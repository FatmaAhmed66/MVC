using System.Net;
using System.Net.Mail;

namespace Demo.persentationLayer.Utilities
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("faty662004.gmail.com", "kwbq ogix dlga ycry");
            client.Send("faty662004.gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
