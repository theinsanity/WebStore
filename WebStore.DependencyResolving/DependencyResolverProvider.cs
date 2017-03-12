using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebStore.Data;
using WebStore.Data.Contracts.RepositoryInterface;
using WebStore.Services;
using WebStore.Services.Contracts.ServiceInterface;

namespace WebStore.DependencyResolving
{
    public class DependencyResolverProvider
    {
        private static Container _container;
        public static IDependencyResolver GetDependencyResolver()
        {
            if (_container == null)
            {
                SetupDependencyResolver();
            }
            return new SimpleInjectorDependencyResolver(_container);
        }
        private static void SetupDependencyResolver()
        {
            _container = new Container();
          
            RegisterRepositoryDependencyInjection();
            
            //container.RegisterMvcIntegratedFilterProvider();
            _container.Verify();
        }
        
        private static void RegisterRepositoryDependencyInjection()
        {
            _container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            _container.Register<IUserService, UserService>(Lifestyle.Transient);
           
        }
       
    }
}  
