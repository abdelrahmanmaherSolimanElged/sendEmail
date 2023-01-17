namespace sendEmail.Services.MailService
{
    public interface IEmailService
    {
        void SendEmail(MailFields mail);
    }
}
