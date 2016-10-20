using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Bakery.BL;
using Bakery.DAL.Interfaces;
using Bakery.DAL.Repositories;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;

namespace Bakery.Dependency
{
    public  class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
                                        
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());
            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies());

            // регистрируем сопоставление типов
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<BakeryMapper>().As<IBakeryMapper>();
            builder.RegisterType<BakeryService>().As<IBakeryService>();

            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }

    }
}
