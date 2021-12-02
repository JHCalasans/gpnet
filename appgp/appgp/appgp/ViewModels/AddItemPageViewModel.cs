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
    public class AddItemPageViewModel : ViewModelBase
    {

        public DelegateCommand SaveItemCommand => new DelegateCommand(SaveItem);

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

        private AppDbContext _context;

        public AddItemPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            _context = new AppDbContext();
        }

        private async void SaveItem()
        {
            Item item = new Item() { Nome = this.Nome, Quantidade = this.Quantidade };

            _context.Itens.Add(item);
            _context.SaveChanges();

            await DialogService.DisplayAlertAsync("Aviso", "Item adicionado com sucesso!", "OK");

            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
    }
}
