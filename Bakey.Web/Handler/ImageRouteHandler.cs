﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Bakey.Web.Handler
{
    public class ImageRouteHandler : IRouteHandler
    {
      
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ImageHandler();
        }
    }
}