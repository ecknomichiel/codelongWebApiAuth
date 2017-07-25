using System.Web;
using System.Web.Mvc;

namespace WebApi_Identity_CodeAlong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
