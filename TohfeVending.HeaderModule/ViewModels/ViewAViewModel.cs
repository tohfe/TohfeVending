using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TohfeVending.Model;

namespace TohfeVending.HeaderModule.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private UserData _userInfo;
        public UserData UserInfo
        {
            get { return _userInfo; }
            set
            {
                SetProperty(ref _userInfo, value);
                OnPropertyChanged(() => Avatar);
            }
        }
        public string Avatar { get => $"/TohfeVending.Shell;component/assets/avatar-{UserInfo.Avatar}.png"; }

        public ViewAViewModel()
        {
            Message = "E-Corp Vending Machine";

            UserInfo = Services.GetMachine().CurrentUser;
        }
    }
}
