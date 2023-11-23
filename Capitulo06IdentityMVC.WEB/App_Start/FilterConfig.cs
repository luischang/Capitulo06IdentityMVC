using System.Web;
using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
