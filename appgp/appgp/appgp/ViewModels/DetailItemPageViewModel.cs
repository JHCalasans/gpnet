using appgp.DataAccess;
using appgp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace appgp.ViewModels
{
    public class DetailItemPageViewModel : ViewModelBase
    {

        public DelegateCommand EditItemCommand => new DelegateCommand(EditItem);

        public DelegateCommand DeleteItemCommand => new DelegateCommand(DeleteItem);

        private Item _itemObj;

        private AppDbContext _context;

        public Item ItemObj
        {
            get { return _itemObj; }
            set { SetProperty(ref _itemObj, value); }

        }

        private String _nome;

        public String Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }

        }

        private int _quantidade;

        public int Quantidade
        {
            get { return _quantidade; }
            set { SetProperty(ref _quantidade, value); }

        }
        public DetailItemPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            _context = new AppDbContext();
        }

        private async void EditItem()
        {
            ItemObj.Nome = Nome;
            ItemObj.Quantidade = Quantidade;
            _context.Itens.Update(ItemObj);
            _context.SaveChanges();
            await DialogService.DisplayAlertAsync("Aviso", "Item alterado com sucesso!", "OK");
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        private async void DeleteItem()
        {
            _context.Itens.Remove(ItemObj);
            _context.SaveChanges();
            await DialogService.DisplayAlertAsync("Aviso", "Item removido com sucesso!", "OK");
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("Item"))
            {
              ItemObj = (Item)parameters["Item"];
              Nome = ItemObj.Nome;
              Quantidade = ItemObj.Quantidade;
            }
        }
    }
}
