using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Logger
{
    public  class EmailLogger : ILogger
    {
        public void LogMessage(string message)
        {
            var to = new List<string> { "chayan.adhikari@thomsonreuters.com" };
            

            var cc = new List<string>();
            SendEmail(to, cc, "Log Message", message);
        }
        public static void SendEmail(List<string> emailToAddress, List<string> ccemailTo, string subject, string body)
        {
            try
            {

                SmtpClient smtpClient = new SmtpClient("relay.westlan.com", 25);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("chayan.adhikari@thomsonreuters.com");
                    message.Subject = subject == null ? "" : subject;
                    message.Body = body == null ? "" : body;

                    message.IsBodyHtml = true;
                    if (emailToAddress != null && emailToAddress.Count > 0)
                    {
                        foreach (string email in emailToAddress)
                        {
                            message.To.Add(email);
                        }
                    }

                    if (ccemailTo != null && ccemailTo.Count > 0)
                    {
                        foreach (string emailCc in ccemailTo)
                        {
                            message.CC.Add(emailCc);
                        }
                    }

                    smtpClient.Send(message);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
