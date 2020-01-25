using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TohfeVending.Model;

namespace TohfeVending.OrderPreparingModule.ViewModels
{
    public class GenericOrderPreparingViewModel : BindableBase, INavigationAware
    {
        readonly IRegionManager _regionManager;
        IList<OrderItemProcessStepViewModel> _processes;
        Beverage _selectedBeverage;
        bool _isInProgress = false;

        public Beverage SelectedBeverage
        {
            get { return _selectedBeverage; }
            set
            {
                SetProperty(ref _selectedBeverage, value);

                OnPropertyChanged(() => Image);

                Processes = _selectedBeverage.ProcessesInOrder
                                .Select(x => new OrderItemProcessStepViewModel(x))
                                .Where(x => !string.IsNullOrEmpty(x.Lable))
                                .ToList();

                Task.Run(() => StartTheProcess());
            }
        }
        public IList<OrderItemProcessStepViewModel> Processes
        {
            get { return _processes; }
            set { SetProperty(ref _processes, value); }
        }
        public string Image { get => $"/TohfeVending.Shell;component/assets/{SelectedBeverage?.Name.Replace(" ", "_")}.jpg"; }
        public DelegateCommand BackCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        public bool IsInProgress
        {
            get { return _isInProgress; }
            set
            {
                SetProperty(ref _isInProgress, value);
                CancelCommand.RaiseCanExecuteChanged();
                BackCommand.RaiseCanExecuteChanged();
            }
        }

        public GenericOrderPreparingViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CancelCommand = new DelegateCommand(CancelTheProcess, () => IsInProgress);
            BackCommand = new DelegateCommand(Back, () => !IsInProgress);

            TohfeVending.Model.Services.GetMachine().OnFunctionStart += GenericOrderPreparingViewModel_OnFunctionStart;
            TohfeVending.Model.Services.GetMachine().OnFunctionDone += GenericOrderPreparingViewModel_OnFunctionDone; ;
        }

        void GenericOrderPreparingViewModel_OnFunctionStart(object sender, AbstractMachineFunction e)
        {
            Processes.FirstOrDefault(x => x.SelectedFunction == e)?.Start();
        }

        void GenericOrderPreparingViewModel_OnFunctionDone(object sender, AbstractMachineFunction e)
        {
            IsInProgress = TohfeVending.Model.Services.GetMachine().VendingMachineStatus != VendingMachineStatusType.StandBy;

            if (IsInProgress)
                Processes.FirstOrDefault(x => x.SelectedFunction == e)?.Done();

        }

        async Task StartTheProcess()
        {
            IsInProgress = true;

            await SelectedBeverage.Make();
        }
        async void CancelTheProcess()
        {
            IsInProgress = false;

            await TohfeVending.Model.Services.GetMachine().Stop();
        }
        async void Back()
        {
            await TohfeVending.Model.Services.GetMachine().Restart();

            NavigateToOrdersList();
        }

        void NavigateToOrdersList()
        {
            _regionManager.RequestNavigate("ContentRegion", "OrdersList");
        }


        #region INavigationAware

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var beverage = navigationContext.Parameters["SelectedBaverage"] as Beverage;
            if (beverage != null)
            {
                SelectedBeverage = beverage;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        #endregion
    }
}
