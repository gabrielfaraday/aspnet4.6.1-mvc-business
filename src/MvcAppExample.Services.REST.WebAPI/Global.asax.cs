﻿using MvcAppExample.Business.AutoMapper;
using System.Web.Http;

namespace MvcAppExample.Services.REST.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
