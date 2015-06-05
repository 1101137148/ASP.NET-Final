using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace ProductWebApp
{
        // Web Api 整合 Spring改繼承Spring.Web.Mvc.SpringMvcApplication
        public class WebApiApplication : Spring.Web.Mvc.SpringMvcApplication //HttpApplication 
        {
            protected void Application_Start()
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
            }
        }
}