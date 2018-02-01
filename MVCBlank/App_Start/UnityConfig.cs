using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVCBlank.Services;
using Unity.Mvc5;

namespace MVCBlank
{
    public sealed class UnityConfig
    {
        private static readonly UnityConfig _instance = new UnityConfig();
        static UnityConfig(){}
        private UnityConfig(){}

        public static UnityConfig Instance { get{ return _instance; } }
        public void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IErrorLogService, ErrorLogService>();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
        }
    }
}