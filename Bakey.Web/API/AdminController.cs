using Bakery.BL;
using Bakery.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Bakey.Web.API
{
    public class AdminController : ApiController
    {
        IBakeryService _service;

        public AdminController(IBakeryService service)
        {
            _service = service;
        }       


        public IEnumerable<ProductViewModel> GetProductsByCategory(int id)
        {
            return _service.GetAllProductByCategory(id);
        }

     
        public async Task<HttpResponseMessage> PostFile(int id)
        {
           
            // Check if the request contains multipart/form-data. 
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]);
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                StringBuilder sb = new StringBuilder(); 

                // Read the form data and return an async task. 
                await Request.Content.ReadAsMultipartAsync(provider);

                var upload = HttpContext.Current.Request.Files[0];

                string fileName = Path.GetFileName(upload.FileName);

                var product = new ProductViewModel();
                product.Name = provider.FormData.Get("name");
                product.Price = decimal.Parse(provider.FormData.Get("price"));
                product.CatId = id;

                string category = _service.GetAllCategories().First(c => c.Id == product.CatId).Name;
              
                product.Image = sb.Append(category).Append(@"\").Append(fileName).ToString();           

                
                // папка для данной категории
                string pathForImage = root + category;
                // полное имя файла картинки
                string fullFileNameForImage = root + product.Image;

                if (!Directory.Exists(pathForImage))
                    Directory.CreateDirectory(pathForImage);

                upload.SaveAs(fullFileNameForImage);

                _service.CreateProduct(product);

               File.Delete(provider.FileData[0].LocalFileName);
                

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }


        [ValidateModel]
        public IHttpActionResult Put(ProductViewModel prod)
        {
            _service.EditProduct(prod);
            return Ok();

        }

        public ProductViewModel GetProduct(int id)
        {           
            return _service.GetProduct(id);
        }


        public void Delete(int id)
        {
            var prod = _service.GetProduct(id);
            string fileName = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]) + prod.Image;
            if (File.Exists(fileName))
                File.Delete(fileName);
            
            _service.DeleteProduct(id);
        }



    }
}
