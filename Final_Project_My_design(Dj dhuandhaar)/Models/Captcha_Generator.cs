﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project_My_design_Dj_dhuandhaar_.Models
{
    public class Captcha_Generator
    {
        public string Captcha()
        {
            char ch1, ch2, ch3, ch4, ch5,ch6;
            string cph="";
            Random rm = new Random();
            ch1 = (char)(rm.Next(65, 90));
            ch2 = (char)(rm.Next(48, 55));
            ch3 = (char)(rm.Next(97, 122));
            ch4 = (char)(rm.Next(65, 90));
            ch5 = (char)(rm.Next(50, 55));
            ch6 = (char)(rm.Next(50, 55));
            cph = ch1 +""+ ch2 +""+ ch3+"" + ch4 +""+ ch5+""+ch6;
            return cph;
        }
    }
}