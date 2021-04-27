using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Final_Project_My_design_Dj_dhuandhaar_.Models;

namespace Final_Project_My_design_Dj_dhuandhaar_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Db_Connectivity db = new Db_Connectivity();
        Captcha_Generator cg = new Captcha_Generator();
        Encryption_Manager em = new Encryption_Manager();
        SMS_Sender sm = new SMS_Sender();




        public ActionResult Index()
        {
           
                return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login2(string ddlusertype,string TxtEmail,string TxtPass)
        {
            string cmd="select usertype from Tbl_Login where Email='"+TxtEmail+"' and Pass='"+TxtPass+"' and status='1'";
            Db_Connectivity db = new Db_Connectivity();
            DataTable dt = db.GetAllRecord(cmd);
            for(int i=0;i<dt.Rows.Count;i++)
                {
                     if (dt.Rows.Count > 0)
                         {
                             string user = dt.Rows[i]["usertype"] + "";
                             if (user == "user")
                                {
                                    Session["uid"] = TxtEmail;
                                    Response.Redirect("/User/Dashboard");
                                 }
                             else if (user == "Administrator")
                             {
                                 Session["aId"] = TxtEmail;
                                 Response.Redirect("/Admin/Index");
                             }
                             else
                             {
                                 Response.Write("<script>alert('Incorrect Password')</script>");
                             }
               
                         }
                 }

            return View();
        }

       
        [HttpGet]
        public ActionResult NewUser()
        {
            Captcha_Generator cg = new Captcha_Generator();
            string cph=cg.Captcha();
            ViewBag.captcha = cph;
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(string name, string TxtName, string TxtEmail, string TxtMobile,  string TxtPass, string TxtCPass,  string TxtCCaptcha, HttpPostedFileBase Fupic, string TxtCaptcha)

        {
            if(TxtCaptcha==TxtCCaptcha)
            {
                if(TxtPass==TxtCPass)
                {
                    string path = Path.Combine(Server.MapPath("/Content/Profile"),Fupic.FileName);
                    Fupic.SaveAs(path);

                    string cmd1 = "insert into Tbl_registration values('" + TxtName + "','" + TxtEmail + "','" + TxtMobile + "','" + TxtPass + "','" + Fupic.FileName + "','" + DateTime.Now.ToString() + "','1')";

                    string cmd2 = "insert into Tbl_Login values('" + TxtEmail + "','" + TxtPass + "','user','" + DateTime.Now.ToString() + "','1')";

                    bool n1 = db.InsertUpdateAndDelete(cmd1);
                    bool n2 = db.InsertUpdateAndDelete(cmd2);
                    if (n1 == true && n2 == true)
                    {
                        
                        Response.Write("Registration Successfull");
                    }
                    else
                    {
                        Response.Write("Unable to save");
                    }

                }
                else
                {
                    //Password
                }
            }
            else
            {
            //captcha
            
            }

            return View();
        }


        [HttpGet]
        public ActionResult ContactUs()

        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string TxtName,string TxtMobile,string message,string TxtEmail)
        {
            Db_Connectivity db = new Db_Connectivity();

            string cmd2 = "insert into Tbl_Enquiry values('" + TxtName + "','" + TxtEmail + "','" + TxtMobile + "','" + message + "','" + DateTime.Now.ToString() + "')";

            if (db.InsertUpdateAndDelete(cmd2) == true)
            {
                Response.Write("Query Send successfully");
            }
            else
            {
                Response.Write("Error occured Pls try angain later");
            
            }




            //if (sm.SendSms(TxtMobile,message) == true) 
            //{
            //    Response.Write("<script>alert('Message Send')</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Message Not Send Error occured')</script>");
            //}
            return View();
        }

        public ActionResult Bollywood()

        {

         
            return View();
        }
        public ActionResult RNB()
        {
            return View();
        }
          public ActionResult Punjabi()
        {

           
            return View();
        }
          public ActionResult Ghazals()
          {
              return View();
          }
          public ActionResult Wedding()
          {
              return View();
          }
          public ActionResult Artists()
          {
              Db_Connectivity db = new Db_Connectivity();
              string cmd = "select * from Tbl_Notification order by NId desc";
              DataTable dt = db.GetAllRecord(cmd);

              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  if (dt.Rows.Count > 0)
                  {
                      ViewBag.noti += dt.Rows[i]["Notification"] + "<img src='../Content/Img/Avinash.jpeg' style='height:20px;width:30px;'/></br>";

                  }
                  else
                  {
                      ViewBag.notification = "No record found";
                  }
              }

              return View();
          }


    }


}
       
