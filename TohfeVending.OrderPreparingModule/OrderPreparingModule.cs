﻿using TohfeVending.OrderPreparingModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace TohfeVending.OrderPreparingModule
{
    public class OrderPreparingModule : IModule
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