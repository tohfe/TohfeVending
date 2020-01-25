using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace TohfeVending.Shell
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<TohfeVending.Shell.Views.Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HeaderModule.HeaderModule>();
            moduleCatalog.AddModule<OrdersModule.OrdersModule>();
            moduleCatalog.AddModule<OrderPreparingModule.OrderPreparingModule>();
        }
    }
}
