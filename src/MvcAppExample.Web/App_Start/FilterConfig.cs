using MvcAppExample.CrossCutting.MvcFilters;
using System.Web.Mvc;

namespace MvcAppExample.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
