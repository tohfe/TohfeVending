using Prism.Mvvm;
using Prism.Regions;

namespace TohfeVending.Shell.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        //private string _title = "Prism Application";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}
        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
