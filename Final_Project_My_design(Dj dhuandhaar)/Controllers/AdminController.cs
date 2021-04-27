using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;
using System.IO;
using Final_Project_My_design_Dj_dhuandhaar_.Models;

namespace Final_Project_My_design_Dj_dhuandhaar_.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mtview()
        {
            return View();
        }

        public ActionResult Delete(string del)
        {
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "delete from Tbl_Registration where Email='" + del + "'  ";
            if (db.InsertUpdateAndDelete(cmd) == true)
                Response.Write("<script> var c=confirm('Are you Sure to delete this record');if(c==True){alert('Record Delted Successfully');}</script>");
            else
                Response.Write("<script>alert('Unable to delete record')</script>");
           
            return View();
        }


        //Management
        [HttpGet]
        public ActionResult RegistrationMgmnt()
        {
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "select * from tbl_Registration";
            DataTable dt = db.GetAllRecord(cmd);

            string tbl = "<table id='Regmgmnt' class='display' style='width:100%'>";
            tbl += "<thead><tr><th>Name</th><th>Email</th><th>Mobile</th><th>Password</th><th>MDT</th><th>Delete</th></tr></thead>";
            tbl += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    tbl += "<tr><td>" + dt.Rows[i]["Name"] + "</td><td>" + dt.Rows[i]["Mobilenumber"] + "</td><td>" + dt.Rows[i]["Email"] + "</td><td>" + dt.Rows[i]["Pass"] + "</td><td>" + dt.Rows[i]["MDT"] + "</td><td><a href='/Admin/Delete?del="+dt.Rows[i]["Email"]+"'><span class='fa fa-trash'></span></a></td></tr>";

                }


            }
            tbl += "</tbody>";
            tbl += "</table>";
            ViewBag.show = tbl;
            return View();
        }
        [HttpGet]
        public ActionResult LoginMGmnt()
        {
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "select * from tbl_Login";
            DataTable dt = db.GetAllRecord(cmd);

            string tbl = "<table id='Regmgmnt' class='display' style='width:100%'>";
            tbl += "<thead><tr><th>Email</th><th>PAss</th><th>UsersType</th><th>MDT</th><th>status</th><th>Delete</th></tr></thead>";
            tbl += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    tbl += "<tr><td>" + dt.Rows[i]["Email"] + "</td><td>" + dt.Rows[i]["Pass"] + "</td><td>" + dt.Rows[i]["usertype"] + "</td><td>" + dt.Rows[i]["MDT"] + "</td><td>" + dt.Rows[i]["status"] + "</td><td><a href='/Admin/Delete?del=" + dt.Rows[i]["Email"] + "'><span class='fa fa-trash'></span></a></td></tr>";

                }


            }
            tbl += "</tbody>";
            tbl += "</table>";
            ViewBag.show = tbl;
            return View();
        }

        [HttpGet]
        public ActionResult FeedbackMgmnt()
        {
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "select * from tbl_Feedback";
            DataTable dt = db.GetAllRecord(cmd);

            string tbl = "<table id='Regmgmnt' class='display' style='width:100%'>";
            tbl += "<thead><tr><th>Id</th><th>Name</th><th>Mobile</th><th>WebLike</th><th>Support</th><th>Experience</th><th>Response</th><th>Timestamp</th><th>Delete</th></tr></thead>";
            tbl += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    tbl += "<tr><td>" + dt.Rows[i]["Id"] + "</td><td>" + dt.Rows[i]["Name"] + "</td><td>" + dt.Rows[i]["Mobile"] + "</td><td>" + dt.Rows[i]["Weblike"] + "</td><td>" + dt.Rows[i]["Support"] + "</td><td>" + dt.Rows[i]["Experience"] + "</td><td>" + dt.Rows[i]["Response"] + "</td><td>" + dt.Rows[i]["FDT"] + "</td><td><a href='/Admin/Delete?del=" + dt.Rows[i]["Id"] + "'><span class='fa fa-trash'></span></a></td></tr>";

                }


            }
            tbl += "</tbody>";
            tbl += "</table>";
            ViewBag.show = tbl;
            return View();
        
        
        }


        public ActionResult QueryMgmnt()
        {
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "select * from tbl_Enquiry";
            DataTable dt = db.GetAllRecord(cmd);

            string tbl = "<table id='Regmgmnt' class='display' style='width:100%'>";
            tbl += "<thead><tr><th>Id</th><th>Name</th><th>Email</th><th>Mobile</th><th>Message</th><th>Timesatmp</th><th>Delete</th></tr></thead>";
            tbl += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    tbl += "<tr><td>" + dt.Rows[i]["Id"] + "</td><td>" + dt.Rows[i]["Name"] + "</td><td>" + dt.Rows[i]["Email"] + "</td><td>" + dt.Rows[i]["Mobile"] + "</td><td>" + dt.Rows[i]["Message"] + "</td><td>" + dt.Rows[i]["MDT"] + "</td><td><a href='/Admin/Delete?del=" + dt.Rows[i]["Id"] + "'><span class='fa fa-trash'></span></a></td></tr>";

                }


            }
            tbl += "</tbody>";
            tbl += "</table>";
            ViewBag.show = tbl;
            return View();


        }
        
        public ActionResult AddNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNotification(FormCollection fc)
        {
            Db_Connectivity db = new Db_Connectivity();
            try
            {
                string cmd = "insert into Tbl_Notification values('" + fc[0] + "','" + fc[1] + "','" + DateTime.Now.ToShortDateString() + "')";
                if (db.InsertUpdateAndDelete(cmd) == true)
                {
                    Response.Write("<script>alert('Notification Added Succesfully')</script>");

                }
            }

            catch(Exception ex) 
            {
                Response.Write("<script>alert('Error found pls contact Webmaster')</script>");
            
            }
            return View();
        }


        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string TxtTo,string TxtSubject,string TxtMsg)
        {
            Email_Sender es = new Email_Sender();
            es.SendTo = "akashduttpathak@gmail.com";
            es.Subject = "Testing fro dj-dhuandhaar";
            es.MessageBody = "Only test";

            bool res = es.SendEmail();

            if (res == true)
            {
                Response.Redirect("Email Send");
            }

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return View();
        }
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileupload,string TxtSongname)
            {
            Db_Connectivity db = new Db_Connectivity();
            string path1 = Path.Combine(Server.MapPath("../Content/Songs"),fileupload.FileName);
            fileupload.SaveAs(path1);

            string cmd = "insert into Tbl_Songs values('" + TxtSongname + "','Category','" + fileupload.FileName + "','none','1')";
            db.InsertUpdateAndDelete(cmd);
            return View();
        }

        public ActionResult admininstruction()
        {
            return View();
        }

        

       
       
    }
}
