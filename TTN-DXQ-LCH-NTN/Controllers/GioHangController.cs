﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_DXQ_LCH_NTN.Models;

namespace TTN_DXQ_LCH_NTN.Controllers
{
    public class GioHangController : Controller
    {
        PetLandModel db = new PetLandModel();

        //Lấy giỏ hàng
        public List<ShoppingCart> GetShoppingCarts()
        {
            List<ShoppingCart> lstShoppingCart = Session["ShoppingCart"] as List<ShoppingCart>;//nếu đã tồn tại giỏ hàng thì ép kiểu

            if (lstShoppingCart == null) //nếu session giỏ hàng chưa tồn tại thì khởi tạo lst
            {
                lstShoppingCart= new List<ShoppingCart>();
                Session["ShoppingCart"] = lstShoppingCart;
            }
            return lstShoppingCart;
        }

        //Thêm giỏ hàng
        public ActionResult Add(int ProductID, string strUrl)
        {

                //Nếu truyền vào mã sản phẩm ko có trong database thì trả về trang lỗi
                Product product = db.Products.SingleOrDefault(p => p.ProductID == ProductID);
                if (product == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                //Lấy ra giỏ hàng
                List<ShoppingCart> lstShoppingCart = GetShoppingCarts();
                //Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa, nếu rồi thì cho tăng số lượng, nếu chưa 
                //thì tiến hành thêm sản phẩm vào giỏ hàng
                ShoppingCart item = lstShoppingCart.Find(p => p.ProductID == ProductID);
                if (item == null)
                {
                    item = new ShoppingCart(ProductID);
                    item.Total = Convert.ToInt16(Request.Form["quant[1]"]);
                    lstShoppingCart.Add(item);
                    return Redirect(strUrl);
                }
                else
                {
                    //item.Total += 1;
                    item.Total = Convert.ToInt16(Request.Form["quant[1]"]);
                    return Redirect(strUrl);
                }
        }

        //Cập nhật giỏ hàng
        public ActionResult Update(int ProductID)
        {
            //kiểm tra mã sản phẩm
            Product product = db.Products.SingleOrDefault(p => p.ProductID == ProductID);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra giỏ hàng
            List<ShoppingCart> lstShoppingCart = GetShoppingCarts();
            //Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa, 
            //nếu rồi thì sửa số lượng thành giá trị ô textbox số lượng
            ShoppingCart item = lstShoppingCart.Find(i => i.ProductID == ProductID);
            if (item != null)
            {
                item.Total = Convert.ToInt16(Request.Form["txtSoLuong"].ToString());
                //Total = Convert.ToInt16(Request.Form["txtSoLuong"].ToString());
                //item.Total = Total;
            }
            return RedirectToAction("ShoppingCart");
        }

        //Xóa giỏ hàng
        public ActionResult Delete(int ProductID)
        {
            //kiểm tra mã sản phẩm
            Product product = db.Products.SingleOrDefault(p => p.ProductID == ProductID);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra giỏ hàng
            List<ShoppingCart> lstShoppingCart = GetShoppingCarts();

            //Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa, 
            //nếu rồi thì sửa số lượng thành giá trị ô textbox số lượng
            ShoppingCart item = lstShoppingCart.Find(i => i.ProductID == ProductID);
            if (item != null)
            {
                lstShoppingCart.RemoveAll(p => p.ProductID == ProductID);
            }
            if (lstShoppingCart.Count == 0)
            {
                return RedirectToAction("Store","User");
            }
            return RedirectToAction("ShoppingCart");
        }

        //Trang View giỏ hàng
        public ActionResult ShoppingCart()
        {
            if (Session["ShoppingCart"] == null)
            {
                return RedirectToAction("Store", "User");
            }
            List<ShoppingCart> lstShoppingCart = GetShoppingCarts();
            return View(lstShoppingCart);
        }

        //Tính tổng số lượng
        private int Total()
        {
            int Total = 0;
            List<ShoppingCart> lstShoppingCarts = Session["ShoppingCart"] as List<ShoppingCart>;//nếu đã tồn tại giỏ hàng thì ép kiểu

            if (lstShoppingCarts != null) //nếu session giỏ hàng chưa tồn tại thì khởi tạo lst
            {
                Total = lstShoppingCarts.Sum(p => p.Total);
            }
            return Total;
        }

        //Tổng tiền
        private double TotalPrice()
        {
            double TotalPrice = 0;
            List<ShoppingCart> lstShoppingCarts = Session["ShoppingCart"] as List<ShoppingCart>;//nếu đã tồn tại session giỏ hàng thì ép kiểu

            if (lstShoppingCarts != null) //nếu session giỏ hàng chưa tồn tại thì khởi tạo lst
            {
                TotalPrice = lstShoppingCarts.Sum(p => p.TotalPrice);
            }
            return TotalPrice;
        }
        //Partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (Total() == 0)
            {
                return PartialView();
            }
            ViewBag.Total = Total();
            ViewBag.TotalPrice = TotalPrice();
            return PartialView();
        }
        //Sửa giỏ hàng
        public ActionResult EditShoppingCart()
        {
            if (Session["ShoppingCart"] == null)
            {
                return RedirectToAction("Store", "User");
            }
            List<ShoppingCart> lstShoppingCart = GetShoppingCarts();
            return View(lstShoppingCart);
        }

        //Đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Phải đăng nhập mới mua được hàng
            if (Session["Account"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (Session["ShoppingCart"] == null)
            {
                return RedirectToAction("Store", "User");
            }
            List<ShoppingCart> carts = GetShoppingCarts();
            Order order = new Order();
            Customer customer = (Customer)Session["Account"];
            order.CustomerID = customer.CustomerID;
            order.OrderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();

            //Thêm chi tiết đơn hàng
            foreach(var item in carts)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderID = order.OrderID;
                orderDetail.ProductID = item.ProductID;
                orderDetail.Total = item.Total;
                orderDetail.Price = (decimal)item.Price;
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
            return RedirectToAction("Store","User");
        }
    }
}