
namespace appgp.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListItens_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            ListItens.SelectedItem = null;
        }
    }
}
