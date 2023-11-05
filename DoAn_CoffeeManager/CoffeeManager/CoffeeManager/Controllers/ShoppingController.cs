using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeManager.Models;

namespace CoffeeManager.Controllers
{
    public class ShoppingController : Controller
    {
        Coffee_managerEntities database = new Coffee_managerEntities();
        // GET: Shopping
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = database.Product.SingleOrDefault(s => s.id_product == id);
            //if (pro != null)
            //{
            //    GetCart().Add(pro);
            //}
            return RedirectToAction("ShowToCard", "Shopping");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "Shopping");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
    }
}