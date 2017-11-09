using Redbox_JSON_Parser.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Redbox_JSON_Parser
{
    class ErrorEmailHandler
    {
        private ScreenBuddyException Exception;

        public ErrorEmailHandler(ScreenBuddyException ex)
        {
            Exception = ex;
            CreateMessage();    
        }

        public void CreateMessage()
        {
            var fromAddress = new MailAddress("screenbuddy69@gmail.com", "ScreenBuddyErrorEmailer");
            var toAddress = new MailAddress("jonathanpedregon@gmail.com", "ScreenBuddyDevTeam");
            const string fromPassword = "pedregon";
            string subject = Exception.SubjectLine;
            string body = Exception.Body;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
