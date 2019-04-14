using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_DXQ_LCH_NTN.Models;

namespace TTN_DXQ_LCH_NTN.Controllers
{
    public class LoginController : Controller
    {
        PetLandModel db = new PetLandModel();

        //LOGIN 
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            
                string userName = Request.Form["us"];
                string password = Request.Form["mk"];

                customer = db.Customers.SingleOrDefault(n => n.UserName == userName && n.Password.Trim() == password);
                if (customer != null)
                {
                    ViewBag.mess = "Đăng nhập thành công";
                    Session["Account"] = customer;
                    return RedirectToAction("Index", "User");
                }
                ViewBag.mess = "Đăng nhập thất bại";  
            return View();
        }

        //Register 

        //GET
        public ActionResult Register()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Register(Customer customer)
        {

            customer.UserName = Request.Form["username"];
            customer.Password = Request.Form["password"];
            customer.Email = Request.Form["email"];
            db.Customers.Add(customer);
            db.SaveChanges();
            return Redirect("Login");
        }
    }
}