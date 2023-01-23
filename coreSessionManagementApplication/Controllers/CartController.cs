using coreSessionManagementApplication.Helpers;
using coreSessionManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace coreSessionManagementApplication.Controllers
{
    public class CartController : Controller
    {
        public Random a = new Random();

        ApplicationDBContext context;
        private Task<IActionResult> something;

        public CartController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                return View("emptycart");
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.Total = cart.Sum(item => item.Product.Price * item.Quantity);
                return View();
            }
        }
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = context.Products.Find(id), Quantity = 1 });
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExists(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = context.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        public int isExists(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Success()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            double total = cart.Sum(item => item.Product.Price * item.Quantity);
            ViewBag.Total = total;
            int id = a.Next(100000000);
            ViewBag.id = id;
            
            ExecuteNonQuery1(id,total);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Success1(int id,double Price)
        //{
            
            

        //    //order order1 = new order();
            
        //    //var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        //    //ViewBag.cart = cart;

        //    //double total = cart.Sum(item => item.Product.Price * item.Quantity);
        //    //ViewBag.Total = total;
        //    //ViewBag.id = a.Next(100000000);
        //    //order1.Price = total;

            
        //    //context.Add(order1);
        //    //await context.SaveChangesAsync();
            
        //    //return View();
        //}
        static SqlConnection ConnectToDB()
        {
            string cs = @"server=H5CG125CW45;Database=JoesPizzaDB;Trusted_Connection=True;";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }
        public static int ExecuteNonQuery1(int id,double Price)
        {
            string query = $"insert into orderdetails (orderid,Price) values ({id},{Price})";
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            return cmd.ExecuteNonQuery();
        }
        
        public IActionResult Success1()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;

            ViewBag.Total = cart.Sum(item => item.Product.Price * item.Quantity);

            ViewBag.id = a.Next(100000000);
            return View();
        }
        public IActionResult Home()
        {
            List<Item> cart = new List<Item>();
            SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("index", "product");
        }
       
    }

    
}
