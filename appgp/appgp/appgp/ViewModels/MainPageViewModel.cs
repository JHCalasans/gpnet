using appgp.DataAccess;
using appgp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appgp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public DelegateCommand AddItemCommand => new DelegateCommand(AddItemAsync);

        public DelegateCommand SincroCommand => new DelegateCommand(AddItemAsync);

        public ObservableCollection<Estoque> TodosItens { get; set; }

        private AppDbContext _context;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Itens(Estoque)";

            _context = new AppDbContext();

            var itemLista = _context.Itens.ToList();

            TodosItens = new ObservableCollection<Estoque>(itemLista);
        }

        private async void AddItemAsync()
        {
            await NavigationService.NavigateAsync("AddItemPage");
        }
    }
}
