﻿using System.Web;
using System.Web.Mvc;

namespace TTN_DXQ_LCH_NTN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
