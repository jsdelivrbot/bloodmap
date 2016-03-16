using BloodMap.Service.Contract;
using BloodMap.Service.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace BloodMap.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IAccountService, AccountService>();

            container.RegisterTypes(
               AllClasses.FromLoadedAssemblies(),
               WithMappings.FromMatchingInterface,
               WithName.Default,
               WithLifetime.ContainerControlled);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}