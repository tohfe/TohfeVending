using TohfeVending.HeaderModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace TohfeVending.HeaderModule
{
    public class HeaderModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("HeaderRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}