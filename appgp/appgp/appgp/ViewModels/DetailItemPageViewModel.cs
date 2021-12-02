using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace appgp.ViewModels
{
    public class DetailItemPageViewModel : ViewModelBase
    {

        public DelegateCommand SaveItemCommand => new DelegateCommand(EditItem);
        public DetailItemPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        private async void EditItem()
        {
           
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
    }
}
