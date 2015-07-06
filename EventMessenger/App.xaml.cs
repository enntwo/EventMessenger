using Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EventMessenger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer _container = new UnityContainer();

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _container.RegisterType<IPlayerRepository, PlayerRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<EditPlayersViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<PostPairingsViewModel>(new ContainerControlledLifetimeManager());
            base.OnStartup(e);
        }
    }
}
