using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TohfeVending.Model;

namespace TohfeVending.OrdersModule.ViewModels
{
    public class OrderItemViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;

        private Beverage _beverage;
        public Beverage Beverage
        {
            get { return _beverage; }
            set { SetProperty(ref _beverage, value); }
        }

        public string Name { get => Beverage.Name; }
        public string Image { get => $"/TohfeVending.Shell;component/assets/{Beverage.Name.Replace(" ", "_")}.jpg"; }

        public DelegateCommand<Beverage> NavigateCommand { get; private set; }

        public OrderItemViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<Beverage>(Navigate);
        }

        private void Navigate(Beverage selectedItem)
        {
            if (selectedItem != null)
            {
                var parameters = new NavigationParameters();
                parameters.Add("SelectedBaverage", selectedItem);
                _regionManager.RequestNavigate("ContentRegion", "GenericOrderPreparing", parameters);
            }
        }
    }
}
