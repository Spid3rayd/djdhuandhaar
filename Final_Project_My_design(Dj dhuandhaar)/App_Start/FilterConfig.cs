using System.Web;
using System.Web.Mvc;

namespace Final_Project_My_design_Dj_dhuandhaar_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}