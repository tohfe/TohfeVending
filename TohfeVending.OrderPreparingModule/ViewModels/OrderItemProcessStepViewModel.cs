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
    public enum FunctionStatusType { NotStarted = 1, InProgeress = 2, Done = 3 }

    public class OrderItemProcessStepViewModel : BindableBase
    {
        private AbstractMachineFunction _selectedFunction;
        public AbstractMachineFunction SelectedFunction
        {
            get { return _selectedFunction; }
            private set { SetProperty(ref _selectedFunction, value); }
        }
        public string Image { get => $"/TohfeVending.Shell;component/assets/icon_{(int)FunctionStatus}.png"; }
        public string Lable { get => SelectedFunction.GetLable(); }

        FunctionStatusType _functionStatus;
        public FunctionStatusType FunctionStatus
        {
            get => _functionStatus;
            set
            {
                SetProperty(ref _functionStatus, value);
                OnPropertyChanged(() => Image);
            }
        }


        public OrderItemProcessStepViewModel(AbstractMachineFunction selectedFunction)
        {
            SelectedFunction = selectedFunction;
            FunctionStatus = FunctionStatusType.NotStarted;
        }

        internal void Start()
        {
            FunctionStatus = FunctionStatusType.InProgeress;
        }

        internal void Done()
        {
            FunctionStatus = FunctionStatusType.Done;
        }
    }
}
