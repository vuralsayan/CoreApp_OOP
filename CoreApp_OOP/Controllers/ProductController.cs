using CoreApp_OOP.Entity;
using CoreApp_OOP.ProjeContext;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp_OOP.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();    

        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = context.Products.Where(x => x.ProductID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var value = context.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
            value.ProductName = p.ProductName;
            value.ProductPrice = p.ProductPrice;
            value.ProductStock = p.ProductStock;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
