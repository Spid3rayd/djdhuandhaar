using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Final_Project_My_design_Dj_dhuandhaar_.Models
{
    public class Encryption_Manager
    {
        public string Encrypt(string encrpt)
        {
            byte[] b;
            string enc;
            b = ASCIIEncoding.ASCII.GetBytes(encrpt);
            enc = Convert.ToBase64String(b);
            return enc;
        }

        //Code for encrpyt data
        public string Decrypt(string decrypt)
        {
            byte[] b;
            string dec;
            b = Convert.FromBase64String(decrypt);
            dec = ASCIIEncoding.ASCII.GetString(b);
            return dec;

        }

    }
}