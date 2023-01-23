using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreSessionManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreSessionManagementApplication.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDBContext context;
        public ProductController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
