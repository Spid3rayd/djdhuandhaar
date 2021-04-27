using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Final_Project_My_design_Dj_dhuandhaar_.Models
{
    public class Email_Sender
    {
        public string SendTo { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public string CC { get; set; }

        public string AttachmentFile { get; set; }

        public bool SendEmail()
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage();
            MailAddress from = new MailAddress("acspfzd@gmail.com");


            MailAddress to = new MailAddress("akashduttpathak@gmail.com");


            //network cridentials settings starts here
            NetworkCredential nc = new NetworkCredential("acspfzd@gmail.com","8090516186a");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = nc;
            //network cridentials settings Ends here


            // MailMessage Settigns starts here..

            msg.Sender = from;
            msg.Subject = Subject;
            msg.To.Add(to);
            msg.From = from;
            msg.Body = MessageBody;

            if (CC != null)
            {
                Attachment att = new Attachment (HttpContext.Current.Server.MapPath(AttachmentFile));
                msg.Attachments.Add(att);
            }


            //Mail Message Settings end here...


            //Send now(66 88 3 33 7777)
            smtp.Send(msg);






            return true;
        }

    }

      
}