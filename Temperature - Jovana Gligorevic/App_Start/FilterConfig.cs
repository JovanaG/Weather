﻿using System.Web;
using System.Web.Mvc;

namespace Temperature___Jovana_Gligorevic
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
