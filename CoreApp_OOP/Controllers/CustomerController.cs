using CoreApp_OOP.Entity;
using CoreApp_OOP.ProjeContext;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp_OOP.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            if (p.CustomerName.Length >= 3 && p.CustomerCity != "" && p.CustomerCity.Length >= 3) //Örnek (hatalı kullanım)
            {
                context.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

            
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            context.Customers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            var value = context.Customers.Where(x => x.CustomerID == p.CustomerID).FirstOrDefault();
            value.CustomerName = p.CustomerName;
            value.CustomerCity = p.CustomerCity;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
