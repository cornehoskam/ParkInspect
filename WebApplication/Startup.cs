﻿using Microsoft.Owin;
using Owin;
using WebApplication;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}