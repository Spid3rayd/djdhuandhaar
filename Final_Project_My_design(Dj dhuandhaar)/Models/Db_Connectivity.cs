using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Final_Project_My_design_Dj_dhuandhaar_.Models
{
    public class Db_Connectivity
    {

        SqlConnection con = new SqlConnection(@"Data Source=SPID3R\SQLEXPRESS;Initial Catalog="Gui Login";Integrated Security=True");
        public bool InsertUpdateAndDelete(string command)
        {
            SqlCommand cmd=new SqlCommand(command,con);
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            int n=cmd.ExecuteNonQuery();
            if(n>0)
            {
                return true;
            }
            else
            {
                return false;
            }


            
        }
        public DataTable GetAllRecord(string command)
        {   
            SqlDataAdapter sa=new SqlDataAdapter(command,con);
            DataTable dt=new DataTable();
            sa.Fill(dt);
            return dt;
        }

    }
}