using maciuca.Model;

namespace maciuca;

public partial class List : ContentPage
{
	public List()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (maciuca)BindingContext;
        await App.Database.SavemaciucaAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (maciuca)BindingContext;
        await App.Database.DeletemaciucaAsync(slist);
        await Navigation.PopAsync();
    }


    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GenrePage((maciuca)
       this.BindingContext)
        {
            BindingContext = new Genre()
        });

    }
    async void OnChooseButtonClickedCharacter(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CharacterPage((maciuca)
       this.BindingContext)
        {
            BindingContext = new Character()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var ani = (maciuca)BindingContext;

        listView.ItemsSource = await App.Database.GetListGenreAsync(ani.Id);
        CharacterlistView.ItemsSource = await App.Database.GetListCharacterAsync(ani.Id);
    }


}