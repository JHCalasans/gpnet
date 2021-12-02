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

        public DelegateCommand SaveItemCommand => new DelegateCommand(EditItem);

        public DelegateCommand DeleteItemCommand => new DelegateCommand(DeleteItem);

        private Item _item;

        private AppDbContext _context;

        public Item Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }

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
            _context.Itens.Update(Item);
            _context.SaveChanges();
            await DialogService.DisplayAlertAsync("Aviso", "Item alterado com sucesso!", "OK");
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        private async void DeleteItem()
        {
            _context.Itens.Remove(Item);
            _context.SaveChanges();
            await DialogService.DisplayAlertAsync("Aviso", "Item removido com sucesso!", "OK");
            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("Item"))
            {
              Item = (Item)parameters["Item"];
              Nome = Item.Nome;
              Quantidade = Item.Quantidade;
            }
        }
    }
}
