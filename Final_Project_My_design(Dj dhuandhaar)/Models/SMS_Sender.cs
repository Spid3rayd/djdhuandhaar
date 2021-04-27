using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Final_Project_My_design_Dj_dhuandhaar_.Models
{
    public class SMS_Sender
    {
        string user, password, sender, priorty, stype;
        public SMS_Sender()
        {
            user = "MTECHL";
            password = "erdirector";
            sender = "MTECHL";
            priorty = "ndnd";
            stype = "normal";
        }
        public bool SendSms(string TxtMobile, string msg)
        {
            string url = "http://trans.smsfresh.co/api/sendmsg.php?user=" + user + "&pass=" + password + "&sender=" + sender + "&phone=" + TxtMobile + "&text=" + msg + "&priority=" + priorty + "&stype=" + stype + "";
            WebClient client = new WebClient();
            string s = client.DownloadString(url);
            char ch = s[0];
            if (ch == 'S')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}