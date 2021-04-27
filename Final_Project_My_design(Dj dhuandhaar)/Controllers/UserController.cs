    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Final_Project_My_design_Dj_dhuandhaar_.Models;

namespace Final_Project_My_design_Dj_dhuandhaar_.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        //db Manger
        Db_Connectivity db = new Db_Connectivity();



        public ActionResult Dashboard(string txtoldpass, string txtnewpass, string txtconfirmpass)
        {
           


            string id = Session["uid"] + "";
           // Response.Write(id);
            if (id != null && id != "")
            {
                string cmd = "select Name,Picture from Tbl_Registration where Email='" + id + "'";

                DataTable dt = db.GetAllRecord(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ViewBag.name = dt.Rows[i]["Name"] + "";
                    ViewBag.pic = dt.Rows[i]["Picture"] + "";

                
                }

            }
            else
            {
              Response.Redirect("/Home/Login2");
            }

            if (txtnewpass == txtconfirmpass)
            {
                string cmd = "update Tbl_Login set Pass='" + txtnewpass + "' where Email='" + id + "' and Pass='" + txtoldpass + "'";
                if (db.InsertUpdateAndDelete(cmd) == true)
                {
                    Response.Write("<script>alert('Pass Changed Successdully')</script>");

                }
                
            }
            else
            {
                Response.Write("<script>alert('Password not Matched')</script>)");

            }





            return View();
        }

        public ActionResult ChnagePassword(string txtoldpass, string txtnewpass, string txtconfirmpass)
        {
            string id = Session["uid"] + "";
            if (txtnewpass == txtconfirmpass)
            {
                string cmd = "update Tbl_Login set Pass='" + txtnewpass + "' where Email='" + id + "' and Pass='" + txtoldpass + "'";
                if (db.InsertUpdateAndDelete(cmd) == true)
                {
                    Response.Write("<script>alert('Pass Changed Successdully')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Password not changed')</script>)");
                }
            }
            else 
            {
                Response.Write("<script>alert('Password not Matched')</script>)");
                
            }


            return View();
        
        }

        public ActionResult Test()
        {

            return View();
        }

        public ActionResult bollywoodalbum()

        {

            string id = Session["uid"] + "";
            // Response.Write(id);
            if (id != null && id != "")
            {
                string cmd = "select * from Tbl_Registration where Email='" + id + "'";

                DataTable dt = db.GetAllRecord(cmd);
                if (dt.Rows.Count>0)
                {
                    ViewBag.name = dt.Rows[0]["Name"] + "";
                    ViewBag.mobile = dt.Rows[0]["Mobilenumber"] + "";
                    ViewBag.pic = dt.Rows[0]["Picture"] + "";
                    ViewBag.email = dt.Rows[0]["Email"] + "";


                }

            }
            else
            {
                Response.Redirect("/Home/Login2");
            }
            return View();
        }

        public ActionResult Myprofile()
        {
           
            string id = Session["uid"] + "";
            // Response.Write(id);
            if (id != null && id != "")
            {
                string cmd = "select * from Tbl_Registration where Email='" + id + "'";

                DataTable dt = db.GetAllRecord(cmd);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.name = dt.Rows[0]["Name"] + "";
                    ViewBag.mobile = dt.Rows[0]["Mobilenumber"] + "";
                    ViewBag.pic = dt.Rows[0]["Picture"] + "";
                    ViewBag.email = dt.Rows[0]["Email"] + "";


                }

            }
            else
            {
               // Response.Redirect("/Home/Login2");
            }



            return View();

        }

        public JsonResult profile(string Name, string Email, string Number)
        {
            string msg = "";
            Db_Connectivity db = new Db_Connectivity();
            string cmd = "update Tbl_Registration set Name='" + Name + "','" + Number + "' where Email='"+Email+"' ";
            if (db.InsertUpdateAndDelete(cmd))
            {
                msg = "record Update Succesfully";
            }
            else
            {
                msg="Unable to save";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("/Home/Login2");
            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        
        
        }

        [HttpPost]
        public ActionResult Feedback(string TxtName, string TxtMobile, string TxtSel, string Support, string Experience, string Response1)
        {
            Db_Connectivity db = new Db_Connectivity();
            string id = Session["uid"] + "";
            // Response.Write(id);
          
                string cmd1 = "select Name,Picture from Tbl_Registration where Email='" + id + "'";

                DataTable dt = db.GetAllRecord(cmd1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ViewBag.name = dt.Rows[i]["Name"] + "";
                    ViewBag.pic = dt.Rows[i]["Picture"] + "";


                }

            
            string cmd = "insert into Tbl_Feedback values('" + TxtName + "','" + TxtMobile + "','" + TxtSel + "','" + Support + "','" + Experience + "','" + Response1 + "','"+DateTime.Now.ToString()+"')";


            bool n1 = db.InsertUpdateAndDelete(cmd);

            if (n1 == true)
            {
                Response.Write("<script>alert('Feedback Send Succenfully')</script>");

            }
            else
            { 
            
            }

            return View();
        }

        public ActionResult Review()
        {
            return View();
        }
    }
}
