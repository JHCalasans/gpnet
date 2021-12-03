using Acr.UserDialogs;
using appgp.DataAccess;
using appgp.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace appgp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public DelegateCommand AddItemCommand => new DelegateCommand(AddItemAsync);

        public DelegateCommand SincroCommand => new DelegateCommand(SincroAsync);

        public DelegateCommand<Item> SelectCommand => new DelegateCommand<Item>(SelectItem);


        public ObservableCollection<Item> TodosItens { get; set; }

        private AppDbContext _context;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Itens(Estoque)";

            _context = new AppDbContext();

            var itemLista = _context.Itens.ToList();

            TodosItens = new ObservableCollection<Item>(itemLista);
        }

        private async void AddItemAsync()
        {
            await NavigationService.NavigateAsync("AddItemPage");
        }

        private async void SincroAsync()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Sincronizando...", MaskType.Gradient);

                string json = JsonConvert.SerializeObject(TodosItens.ToList());
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await IniciarCliente().PostAsync("adicionarLista", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        await DialogService.DisplayAlertAsync("Aviso", "Sincronizado com sucesso!", "OK");
                    }
                    else
                    {
                        await DialogService.DisplayAlertAsync("Aviso", "Falha ao sincronizar!", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DialogService.DisplayAlertAsync("Aviso", "Falha ao sincronizar!", "OK");
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }


        private async void SelectItem(Item item)
        {
            NavigationParameters navParam = new NavigationParameters
             {
               { "Item", item }
             };
            await NavigationService.NavigateAsync("DetailItemPage", navParam);
        }
    }
}
