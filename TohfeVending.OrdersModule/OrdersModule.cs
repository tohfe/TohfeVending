using TohfeVending.OrdersModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace TohfeVending.OrdersModule
{
    public class OrdersModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(OrdersList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<OrdersList>();
        }
    }
}