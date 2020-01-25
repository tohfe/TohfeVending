using TohfeVending.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace TohfeVending.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<TohfeVending.Shell.Views.Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        //protected override void InitializeModules()
        //{
        //    ModuleCatalog modulecatalog = CreateModuleCatalog() as ModuleCatalog;

        //    modulecatalog.AddModule<HeaderModule.HeaderModuleModule>();
        //    //modulecatalog.AddModule<OrdersModule.OrdersModuleModule>();
        //    //modulecatalog.AddModule<OrderPreparingModule.OrderPreparingModuleModule>();

        //    //this.ConfigureModuleCatalog(modulecatalog);

        //    base.InitializeModules();
        //}
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HeaderModule.HeaderModuleModule>();
            moduleCatalog.AddModule<OrdersModule.OrdersModuleModule>();
            moduleCatalog.AddModule<OrderPreparingModule.OrderPreparingModuleModule>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
        }
    }
}
