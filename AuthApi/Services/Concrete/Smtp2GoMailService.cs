using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AuthApi.Services.Abstract;

namespace AuthApi.Services.Concrete
{
    public class Smtp2GoMailService:IMailService
    {
        
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var mail = new MailMessage();
            var client = new SmtpClient("mail.smtp2go.com", 2525) //Port 8025, 587 and 25 can also be used.
            {
                Credentials = new NetworkCredential("**", "**"),
                EnableSsl = true
            };
            mail.From = new MailAddress("**");
            mail.To.Add(toEmail);
            mail.Subject = subject;
            var plainView = AlternateView.CreateAlternateViewFromString(subject, null, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString(content, null, "text/html");
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            client.Send(mail);
        }
    }
}
