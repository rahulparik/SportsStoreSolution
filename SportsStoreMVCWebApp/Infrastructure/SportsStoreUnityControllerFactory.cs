using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using System.Data.Entity;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsStoreMVCWebApp.DataContexts;
using SportsStoreDomainLibrary.Abstract;
using SportsStoreDomainLibrary.Concrete;
using SportsStoreMVCWebApp.Models;
using LoggingLibrary;

namespace SportsStoreMVCWebApp.Infrastructure
{
    public class SportsStoreUnityControllerFactory: DefaultControllerFactory
    {
        IUnityContainer _container;
        public SportsStoreUnityControllerFactory()
        {
            _container = new UnityContainer();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : _container.Resolve(controllerType) as IController;

            //return base.GetControllerInstance(requestContext, controllerType);
        }

        private void AddBindings()
        {

            //_container.RegisterType<IProductRepository, MockProduct>();
            _container.RegisterType<IProductRepository, EFProductRepository>();
            _container.RegisterType<ILogger, Logger>();

            //All these are for IdentitySecurity
            _container.RegisterType<UserManager<ApplicationUser>>();
            _container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            _container.RegisterType<DbContext, ApplicationDbContext>();
            _container.RegisterType <Controllers.AccountController>(new InjectionConstructor());

        }
    }
}