using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_CRUD_Application_Ajax
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
