using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TohfeVending.OrdersModule.ViewModels
{
    public class OrdersListViewModel : BindableBase
    {

        private IList<OrderItemViewModel> _orders;
        public IList<OrderItemViewModel> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }
        public OrdersListViewModel(IRegionManager regionManager)
        {
            Orders = TohfeVending.Model.Services.GetMachine().Beverages.Select(
                x => new OrderItemViewModel(regionManager) { Beverage = x }
            ).ToList();
        }
    }
}
