using maciuca.Model;

namespace maciuca;

public partial class MyLists : ContentPage
{
    public MyLists()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        maciucaListView.ItemsSource = await App.Database.GetmaciucaAsync();
    }
    async void OnanimeAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new List
        {
            BindingContext = new maciuca()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new List
            {
                BindingContext = e.SelectedItem as maciuca
            });
        }
    }
}
