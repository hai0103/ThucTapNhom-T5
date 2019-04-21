using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_DXQ_LCH_NTN.Models;

namespace TTN_DXQ_LCH_NTN.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryOfProductsManage()
        {
            var lstCate = db.CategoryOfProducts.ToList();
            return View(lstCate);
        }

       
    }
}