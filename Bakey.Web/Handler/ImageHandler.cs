using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Bakey.Web.Handler
{
    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var param = context.Request.QueryString["title"];

            string fileName = context.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]) + param;
            string defaultFile = context.Server.MapPath(ConfigurationManager.AppSettings["ImageFolder"]) + "Default.jpg";           
                   

            context.Response.ContentType = "image/jpeg";

            if (File.Exists(fileName))
            {
                context.Response.WriteFile(fileName);
            }
            else
            {
                context.Response.WriteFile(defaultFile);
            }
        }
    }
}