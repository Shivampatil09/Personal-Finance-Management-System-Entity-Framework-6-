using System.Web;
using System.Web.Mvc;

namespace Personal_Finance__Mangmentr_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
