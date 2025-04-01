using System.Net.Mail;
using System.Net;

namespace lizaaaaaaa.SMTP
{
    public class EmailSender
    {
        public void sendMail(string to, string subject, string content)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential("k.maminaishvili@gmail.com", "ykws duyg kznm rhiu");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("k.maminaishvili@gmail.com"); 
            mailMessage.To.Add(to);                                          
            mailMessage.Subject = subject;                                  
            mailMessage.Body = content;                                      
            mailMessage.IsBodyHtml = true; 
            smtpClient.Send(mailMessage);                      
        }

    }
}
