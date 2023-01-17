
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;

namespace sendmail.Services.MailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(MailFields mail)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            message.To.Add(MailboxAddress.Parse(mail.To));
            message.Subject = mail.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = mail.Message };
            ISmtpClient smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value,int.Parse(_config.GetSection("EmailPort").Value), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(message);
            smtp.Disconnect(true);


        }
    }
}
