using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_DXQ_LCH_NTN.Models;
using PagedList;
using PagedList.Mvc;

namespace TTN_DXQ_LCH_NTN.Controllers
{
    public class UserController : Controller
    {
        PetLandModel db = new PetLandModel();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            var blog = from b in db.Blogs select b;
            return View(blog.ToList());
        }

        public ActionResult BlogInfoPartial()
        {
            var lstBlog = db.Blogs.Where(a=>a.New==1).ToList();
            return PartialView(lstBlog);
        }

        public ActionResult Store()
        {
            var lstCategory = db.CategoryOfProducts.ToList();
            return View(lstCategory);
        }
        public PartialViewResult NewProductPartial()
        {
            var lstNewProduct = db.Products.Take(12).ToList();
            return PartialView(lstNewProduct);
        }
        public PartialViewResult Product(int ?categoryOfProductID,int ?pageIndex)
        {
            var items = new List<Product>();
            int _pageIndex = pageIndex ?? 1;
            if (categoryOfProductID == null)
            {
                items = db.Products.ToList();
            }
            else
            {
                items = (from pr in db.Products
                        where pr.CategoryOfProductID == categoryOfProductID
                        select pr).ToList();
            }

            return PartialView(items.OrderBy(x=>x.CategoryOfProductID).ToPagedList(_pageIndex,12));
        }

        //Partial View Blog
        public PartialViewResult listBlog(int ? pageIndex)
        {
            var items = db.Blogs.ToList();
            int _pageIndex = pageIndex ?? 1;
            return PartialView(items.OrderBy(x=>x.BlogID).ToPagedList(_pageIndex,2));
        }

        public ActionResult BlogPartial()
        {
            var lstBlog = db.Blogs.Where(a=>a.New==1).Take(3).ToList();
            return PartialView(lstBlog);
        }

        public PartialViewResult ListDevicePartial()
        {
            var lstDec = db.CategoryOfProducts.Where(a => a.CategoryOfProductID > 9).ToList();
            return PartialView(lstDec);
        }
        public PartialViewResult ListAnimalPartial()
        {
            var lstAni = db.CategoryOfProducts.Where(a => a.CategoryOfProductID <= 9).ToList();
            return PartialView(lstAni);
        }

        public ActionResult ProductDetail(int ProductID)
        {
            Product product = db.Products.SingleOrDefault(p => p.ProductID == ProductID);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        } 

        public ActionResult BlogDetail(int BlogID)
        {
            Blog blog = db.Blogs.SingleOrDefault(p => p.BlogID == BlogID);
            if(blog == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(blog);
        }
    }

}