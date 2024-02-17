using maciuca.Data;
using maciuca.Model;
using Microsoft.Maui.Controls;
namespace maciuca
{
    public partial class maciucaListPage : ContentPage
    {
        public maciucaListPage()
        {
            InitializeComponent();
        }

        

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            maciucaListView.ItemsSource = await App.Database.GetmaciucaAsync();
        }
        async void OnmaciucaAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddmaciucaPage
            {
                BindingContext = new maciuca()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddmaciucaPage
                {
                    BindingContext = e.SelectedItem as maciuca
                });
            }
        }



    }
}