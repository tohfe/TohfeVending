using TohfeVending.OrderPreparingModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace TohfeVending.OrderPreparingModule
{
    public class OrderPreparingModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GenericOrderPreparing>();
        }
    }
}