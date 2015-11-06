using System.Net.Mail;

namespace SoftLogik.Email
{
  public class SmtpEmailSender : IEmailSender
  {
    private SmtpClient _client;

    public void SendMail(MailMessage mail)
    {
      if (_client == null)
        _client = new SmtpClient();

      _client.Send(mail);
    }
  }
}