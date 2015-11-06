using System.Net.Mail;

namespace SoftLogik.Email
{
  public interface IEmailSender
  {
    void SendMail(MailMessage mail);
  }
}