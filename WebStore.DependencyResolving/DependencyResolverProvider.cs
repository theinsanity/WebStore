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
        private Container _container;
        private readonly string _connectionString;

        public DependencyResolverProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public  IDependencyResolver GetDependencyResolver()
        {
            if (_container == null)
            {
                SetupDependencyResolver();
            }
            return new SimpleInjectorDependencyResolver(_container);
        }
        private  void SetupDependencyResolver()
        {
            _container = new Container();
          
            RegisterRepositoryDependencyInjection();
            
            //container.RegisterMvcIntegratedFilterProvider();
            _container.Verify();
        }
        
        private void RegisterRepositoryDependencyInjection()
        {
            _container.Register<IAuctionRepository>(() => new AuctionRepository(_connectionString));
            _container.Register<IUserRepository>(() => new UserRepository(_connectionString));
            _container.Register<IUserService, UserService>(Lifestyle.Transient);
            _container.Register<IBCryptHashService, BCryptHashService>(Lifestyle.Transient);
            _container.Register<IAuctionService, AuctionService>(Lifestyle.Transient);
        }
       
    }
}  
