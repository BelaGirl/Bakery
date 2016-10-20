using Bakery.BL;
using Bakery.ViewModel;
using Bakey.Web.IdentityExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Bakey.Web.Controllers
{
    public class HomeController : Controller
    {
        //BakeryService _service = new BakeryService();               

        IBakeryService _service;

        public HomeController(IBakeryService serv)
        {
            _service = serv;
        }

        public ActionResult Index()
        {            
            return View(_service.GetAllCategories());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Products(int id)
        {
            if (User.Identity.GetRole()!="Admin")
                return View("Products",_service.GetAllProductByCategory(id));

            return View("ProductsForAdmin", _service.GetAllProductByCategory(id));
        }



        public ActionResult SearchProd(string searchName)
        {
            if (string.IsNullOrEmpty(searchName))
                return RedirectToAction("Index", "Home");

            var foundProd = _service.SearchProductByName(searchName);
            if (foundProd.Count()==0)
                return View("Empty");

            return View(foundProd);
        }
    }
}