﻿using System.Web;
using System.Web.Mvc;

namespace Bai3_23TH2519
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
