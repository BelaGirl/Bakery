using Bakery.BL;
using Bakery.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Bakey.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        //BakeryService _service = new BakeryService();
      
        IBakeryService _service;

        public AdminController(IBakeryService serv)
        {
            _service = serv;
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(CreateProductViewModel createProd, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                string path = HttpContext.Request.UrlReferrer.AbsolutePath;

                ProductViewModel prod = new ProductViewModel();
                prod.Name = createProd.Name;
                prod.Price = createProd.Price;
                prod.CatId = Convert.ToInt32(path.Split('/').Last());                                    // find id in the route
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                
                
                string category = _service.GetAllCategories().First(c => c.Id == prod.CatId).Name;

            
                StringBuilder sb = new StringBuilder();
                prod.Image = sb.Append(category).Append(@"\").Append(fileName).ToString(); 
                _service.CreateProduct(prod);

                // директория для картинок
                string mainFolder = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
                // папка для данной категории
                string pathForImage = mainFolder + category;
                // полное имя файла картинки
                string fullFileNameForImage = mainFolder + prod.Image;

                if (!System.IO.Directory.Exists(pathForImage))
                    System.IO.Directory.CreateDirectory(pathForImage);

                upload.SaveAs(fullFileNameForImage);           

                return Content(path);
            }           


            return PartialView(createProd);
        }



        public ActionResult Edit(int id)
        {            
            return PartialView(_service.GetProduct(id));
        }


        [HttpPost]
        public ActionResult Edit(ProductViewModel prod, HttpPostedFileBase upload)
        {

            if (!ModelState.IsValid)
            {
                return PartialView(prod);                
            }

            _service.EditProduct(prod);

            if (upload != null)
            {
                string fileName = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]) + prod.Image;
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);

                upload.SaveAs(fileName);
            }

            string path = HttpContext.Request.UrlReferrer.AbsolutePath;

            return Content(path);         

            
        }



        public ActionResult Delete(int id)
        {
            var prod = _service.GetProduct(id);
            string fileName = HttpContext.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]) + prod.Image;
            if(System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);

            string path = HttpContext.Request.UrlReferrer.AbsolutePath;
            _service.DeleteProduct(id);

            return Redirect(path);
        }
    }
}